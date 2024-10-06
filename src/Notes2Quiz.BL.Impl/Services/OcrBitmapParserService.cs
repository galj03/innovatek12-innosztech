using Notes2Quiz.BL.Services;
using System.Drawing;
using Tesseract;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class OcrBitmapParserService : IBitmapParserService
    {
        #region Inherited members
        public string ParseBitmapsToString(IEnumerable<Bitmap> bitmaps)
        {
            if (bitmaps is null)
            {
                throw new ArgumentNullException(nameof(bitmaps));
            }

            var str = "";

            using (var engine = new TesseractEngine($@"{AppDomain.CurrentDomain.BaseDirectory}/tessdata", "eng", EngineMode.Default))
            {
                foreach (var bitmap in bitmaps)
                {
                    using (var img = PixConverter.ToPix(bitmap))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            str += text + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
            }

            return str;
        }
        #endregion
    }
}
