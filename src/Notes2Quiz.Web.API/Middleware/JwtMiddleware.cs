using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Notes2Quiz.BL.Application;
using Notes2Quiz.BL.Impl;
using Notes2Quiz.BL.Services;
using System.Text;

namespace Notes2Quiz.Web.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<IApplicationSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await AttachUserToContext(context, userService, token);
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JsonWebTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var validationResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                });

                var username = validationResult.ClaimsIdentity.Claims.First(x => x.Type == Constants.User.USER_NAME).Value;

                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetByUsername(username);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
