using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using Notes2Quiz.Web.API.DTO;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    public interface IQuizController
    {
        Task<ActionResult<TextInputDTO>> Temp([Required] TextInputDTO text);

        Task<ActionResult<IQuiz>> ParsePdf([Required] IPdf pdf);

        Task<ActionResult<IQuiz>> ParseText([Required] TextInputDTO text);

        Task<ActionResult<IQuiz>> ParseImages([Required] IImageCollection images);
    }
}
