namespace Notes2Quiz.BL.Application
{
    /// <summary>
    /// Contains secret, user-specific settings
    /// </summary>
    public interface IApplicationSettings
    {
        /// <summary>
        /// The api key.
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// The secret to validate and sign authentication tokens.
        /// </summary>
        string Secret { get; }
    }
}
