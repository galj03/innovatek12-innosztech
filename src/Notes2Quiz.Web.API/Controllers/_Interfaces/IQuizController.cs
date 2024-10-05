using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    public interface IQuizController
    {
        Task<ActionResult<TempDTO>> Temp([Required] TempDTO text);

        Task<ActionResult<IQuiz>> ParsePdf([Required] IPdf pdf);

        Task<ActionResult<IQuiz>> ParseText([Required] string text);

        Task<ActionResult<IQuiz>> ParseImages([Required] IImageCollection images);
    }
}
