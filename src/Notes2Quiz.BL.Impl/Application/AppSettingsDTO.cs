namespace Notes2Quiz.BL.Impl.Application
{
    internal class AppSettingsDTO
    {
        #region Properties
        public string ApiKey { get; set; }
        public string Secret { get; set; }
        #endregion

        #region ctor
        public AppSettingsDTO()
        { }
        #endregion
    }
}
