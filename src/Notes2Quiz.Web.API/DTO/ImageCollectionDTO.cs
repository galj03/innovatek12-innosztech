namespace Notes2Quiz.Web.API.DTO
{
    public class ImageCollectionDTO
    {
        #region Properties
        public IEnumerable<IFormFile> Images { get; set; }
        #endregion

        #region ctor
        public ImageCollectionDTO()
        { }
        #endregion
    }
}
