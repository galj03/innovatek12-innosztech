using System.Drawing;

namespace Notes2Quiz.BL.Services
{
    public interface IBitmapParserService
    {
        string ParseBitmapsToString(IEnumerable<Bitmap> bitmaps);
    }
}
