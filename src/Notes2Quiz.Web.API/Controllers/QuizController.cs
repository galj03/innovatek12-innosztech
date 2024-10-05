using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Services;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase, IQuizController
    {
        #region Fields
        private readonly IQuizService _quizService;
        //private readonly ILogger<QuizController> _logger;
        #endregion

        #region ctor
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService ?? throw new ArgumentNullException(nameof(quizService));
        }
        #endregion

        #region Endpoints
        [HttpGet("dummy")]
        public async Task<ActionResult<string>> Temp([Required] string text)
        {
            var value = await _quizService.DummyMethod(text);
            return value;
        }

        [HttpPost("pdf")]
        public async Task<ActionResult<IQuiz>> ParsePdf([Required] IPdf pdf)
        {
            throw new NotImplementedException();
        }

        [HttpPost("text")]
        public async Task<ActionResult<IQuiz>> ParseText([Required] string text)
        {
            throw new NotImplementedException();
        }

        [HttpPost("images")]
        public async Task<ActionResult<IQuiz>> ParseImages([Required] IImageCollection images)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
