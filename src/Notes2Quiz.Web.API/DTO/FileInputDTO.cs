namespace Notes2Quiz.Web.API.DTO
{
    /// <summary>
    /// This model wraps a file instance.
    /// </summary>
    public class FileInputDTO
    {
        #region Properties
        /// <summary>
        /// The file instance.
        /// </summary>
        public IFormFile File { get; set; }
        #endregion

        #region ctor
        public FileInputDTO()
        { }
        #endregion
    }
}
