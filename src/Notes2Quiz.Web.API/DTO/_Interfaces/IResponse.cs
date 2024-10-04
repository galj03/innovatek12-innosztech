using System.Net;

namespace Notes2Quiz.Web.API.DTO
{
    public interface IResponse<T>
        where T : class
    {
        T ResponseObject { get; }
        IEnumerable<FeedbackMessage> FeedbackMessages { get; }
        HttpStatusCode StatusCode { get; }
    }
}
