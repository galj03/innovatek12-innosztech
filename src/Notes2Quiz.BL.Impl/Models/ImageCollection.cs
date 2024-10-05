using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Impl.Models
{
    internal class ImageCollection : IImageCollection
    {
        #region Properties
        public string Name { get; }
        public IEnumerable<byte[]> Images { get; }
        #endregion

        #region ctor
        public ImageCollection(string name, IEnumerable<byte[]> images)
        {
            Name = name;
            Images = images ?? throw new ArgumentNullException(nameof(images));
        }
        #endregion
    }
}
