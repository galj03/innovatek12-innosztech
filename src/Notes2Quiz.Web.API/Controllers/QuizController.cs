using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using Notes2Quiz.Web.API.DTO;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        //#region Fields
        //private readonly ILogger<QuizController> _logger;
        //#endregion

        //#region ctor
        //public QuizController(ILogger<QuizController> logger)
        //{
        //    _logger = logger;
        //}
        //#endregion

        #region Endpoints
        [HttpPost("pdf")]
        public async Task<IResponse<IQuiz>> ParsePdf([Required] IPdf pdf)
        {
            throw new NotImplementedException();
        }

        [HttpPost("text")]
        public async Task<IResponse<IQuiz>> ParseText([Required] string text)
        {
            throw new NotImplementedException();
        }

        [HttpPost("images")]
        public async Task<IResponse<IQuiz>> ParseImages([Required] IImageCollection images)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
