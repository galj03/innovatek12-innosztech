using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Services;
using Notes2Quiz.Web.API.DTO;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    /// <summary>
    /// This controller handles quiz-related API calls.
    /// </summary>
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
        [HttpPost("pdf")]
        public async Task<ActionResult<IQuiz>> ParsePdf()
        {
            string text;
            var file = Request.Form.Files.FirstOrDefault();
            {
                using var stream = file.OpenReadStream();
                PdfReader reader = new PdfReader(stream);
                PdfDocument pdfDoc = new PdfDocument(reader);
                StringWriter textString = new StringWriter();

                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    textString.WriteLine(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
                }

                text = textString.ToString();
            }

            var quiz = await _quizService.GenerateQuizFromText(text);
            return CreatedAtAction(nameof(ParseText), quiz);
        }

        [HttpPost("text")]
        public async Task<ActionResult<IQuiz>> ParseText([Required] TextInputDTO text)
        {
            var quiz = await _quizService.GenerateQuizFromText(text.Text);
            return CreatedAtAction(nameof(ParseText), quiz);
        }

        [HttpPost("images")]
        public async Task<ActionResult<IQuiz>> ParseImages([Required] IImageCollection images)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
