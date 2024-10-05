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
        private readonly IUserService _userService;
        #endregion

        #region ctor
        public AuthController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        #endregion

        #region Endpoints
        [HttpPost("")]
        public ActionResult<string> Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model.Username, model.Password);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return response.Token;
        }
        #endregion
    }
}
