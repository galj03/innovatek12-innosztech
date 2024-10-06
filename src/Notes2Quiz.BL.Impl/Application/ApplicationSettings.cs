using Notes2Quiz.BL.Application;
using System.Text.Json;

namespace Notes2Quiz.BL.Impl.Application
{
    public class ApplicationSettings : IApplicationSettings
    {
        #region Properties
        public string ApiKey { get; }
        public string Secret { get; }
        #endregion

        #region ctor
        public ApplicationSettings(string apiKey, string secret)
        {
            ApiKey = apiKey;
            Secret = secret;
        }

        public ApplicationSettings()
        {
            string json = "";
            if (File.Exists(Constants.Config.CONFIG_PATH))
            {
                json = File.ReadAllText(Constants.Config.CONFIG_PATH);
            }
            var obj = JsonSerializer.Deserialize<AppSettingsDTO>(json);

            ApiKey = obj?.ApiKey;
            Secret = obj?.Secret;
        }
        #endregion
    }
}
