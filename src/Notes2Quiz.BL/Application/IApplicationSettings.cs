namespace Notes2Quiz.BL.Application
{
    public interface IApplicationSettings
    {
        string ApiKey { get; }
        string Secret { get; }
    }
}
