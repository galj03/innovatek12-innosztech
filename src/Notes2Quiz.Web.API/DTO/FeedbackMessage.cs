using Notes2Quiz.Web.API.Enums;

namespace Notes2Quiz.Web.API.DTO
{
    public class FeedbackMessage
    {
        #region Properties
        public Severity Severity { get; }
        public string Message { get; }
        #endregion

        #region ctor
        public FeedbackMessage(Severity severity, string message)
        {
            Severity = severity;
            Message = message;
        }
        #endregion
    }
}
