namespace Notes2Quiz.Web.API.DTO
{
    /// <summary>
    /// This model wraps an image collection.
    /// </summary>
    public class ImageCollectionDTO
    {
        #region Properties
        /// <summary>
        /// The image collection.
        /// </summary>
        public IEnumerable<IFormFile> Images { get; set; }
        #endregion

        #region ctor
        public ImageCollectionDTO()
        { }
        #endregion
    }
}
