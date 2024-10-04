using System.Net;

namespace Notes2Quiz.Web.API.DTO
{
    public class JsonResponse<T> : IResponse<T>
        where T : class
    {
        #region Properties
        public T ResponseObject { get; }
        public IEnumerable<FeedbackMessage> FeedbackMessages { get; }
        public HttpStatusCode StatusCode { get; }
        #endregion

        #region ctor
        public JsonResponse(T responseObject, IEnumerable<FeedbackMessage> feedbackMessages, HttpStatusCode statusCode)
        {
            ResponseObject = responseObject;
            FeedbackMessages = feedbackMessages ?? throw new ArgumentNullException(nameof(feedbackMessages));
            StatusCode = statusCode;
        }
        #endregion
    }
}
