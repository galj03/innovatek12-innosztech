using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using Notes2Quiz.Web.API.DTO;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    /// <summary>
    /// This controller handles quiz-related API calls.
    /// </summary>
    public interface IQuizController
    {
        Task<ActionResult<IQuiz>> ParsePdf();

        Task<ActionResult<IQuiz>> ParseText([Required] TextInputDTO text);

        Task<ActionResult<IQuiz>> ParseImages([Required] IImageCollection images);
    }
}
