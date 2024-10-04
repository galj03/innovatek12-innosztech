using Microsoft.AspNetCore.Mvc;
using Notes2Quiz.BL.Models;
using Notes2Quiz.Web.API.DTO;
using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfParserController : ControllerBase
    {
        #region Fields
        private readonly ILogger<PdfParserController> _logger;
        #endregion

        #region ctor
        public PdfParserController(ILogger<PdfParserController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Endpoints
        [HttpPost("")]
        public async Task<IResponse<IQuiz>> ParsePdf([Required] IPdf pdf)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
