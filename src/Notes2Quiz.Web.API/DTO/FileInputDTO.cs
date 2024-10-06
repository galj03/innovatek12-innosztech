namespace Notes2Quiz.Web.API.DTO
{
    public class FileInputDTO
    {
        #region Properties
        public IFormFile File { get; set; }
        #endregion

        #region ctor
        public FileInputDTO()
        { }
        #endregion
    }
}
