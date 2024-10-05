using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Services;
using Notes2Quiz.Web.API.DTO;

namespace Notes2Quiz.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase, IAuthController
    {
        #region Fields
        private readonly IAuthService _authService;
        #endregion

        #region ctor
        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        #endregion

        #region Endpoints
        [HttpPost("")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _authService.Authenticate(model.Username, model.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        #endregion
    }
}
