using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.Web.API.DTO;

namespace Notes2Quiz.Web.API.Controllers
{
    public interface IAuthController
    {
        ActionResult<string> Authenticate(AuthenticateRequest model);
    }
}
