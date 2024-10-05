using Notes2Quiz.BL.Models;
using Notes2Quiz.Web.API.DTO;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    public interface IQuizController
    {
        Task<IResponse<string>> Temp([Required] string text);

        Task<IResponse<IQuiz>> ParsePdf([Required] IPdf pdf);

        Task<IResponse<IQuiz>> ParseText([Required] string text);

        Task<IResponse<IQuiz>> ParseImages([Required] IImageCollection images);
    }
}
