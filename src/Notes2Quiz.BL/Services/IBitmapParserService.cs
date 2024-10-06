using System.Drawing;

namespace Notes2Quiz.BL.Services
{
    /// <summary>
    /// This service supplies bitmap-related queries.
    /// </summary>
    public interface IBitmapParserService
    {
        /// <summary>
        /// Extracts a string out of a bitmap collection.
        /// </summary>
        /// <param name="bitmaps">The bitmap collection.</param>
        /// <returns>A string value.</returns>
        string ParseBitmapsToString(IEnumerable<Bitmap> bitmaps);
    }
}
