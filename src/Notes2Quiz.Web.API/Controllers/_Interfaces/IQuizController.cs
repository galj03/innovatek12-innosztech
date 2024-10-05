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
        /// <summary>
        /// Creates and returns a quiz from the data found in the given pdf file.
        /// </summary>
        /// <returns>A quiz object.</returns>
        Task<ActionResult<IQuiz>> ParsePdf([Required][FromForm] FileInputDTO fileInputDTO);

        /// <summary>
        /// Creates and returns a quiz from the data found in the given json object.
        /// </summary>
        /// <returns>A quiz object.</returns>
        Task<ActionResult<IQuiz>> ParseText([Required] TextInputDTO text);

        /// <summary>
        /// Creates and returns a quiz from the data found on the given images.
        /// </summary>
        /// <returns>A quiz object.</returns>
        Task<ActionResult<IQuiz>> ParseImages([Required] IEnumerable<IFormFile> images);
    }
}
