using Notes2Quiz.BL.Application;

namespace Notes2Quiz.BL.Impl.Application
{
    internal class ApplicationSettings : IApplicationSettings
    {
        #region Properties
        public string Secret { get; set; }
        #endregion

        #region ctor
        public ApplicationSettings(string secret)
        {
            Secret = secret;
        }
        #endregion
    }
}
