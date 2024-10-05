using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class PdfByteParserService : AByteParserService, IByteParserService
    {
        public override string ParseBytesToString(byte[] bytes)
        {
            //TODO: use iText8:
            //public static string ExtractTextFromPdf(byte[] pdfBytes)
            //{
            //    using (MemoryStream stream = new MemoryStream(pdfBytes))
            //    {
            //        PdfReader reader = new PdfReader(stream);
            //        PdfDocument pdfDoc = new PdfDocument(reader);
            //        StringWriter text = new StringWriter();

            //        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            //        {
            //            text.WriteLine(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
            //        }

            //        return text.ToString();
            //    }
            //}
            throw new NotImplementedException();
        }
    }
}
