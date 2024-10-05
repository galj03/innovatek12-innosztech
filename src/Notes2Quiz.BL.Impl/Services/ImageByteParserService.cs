using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class ImageByteParserService : AByteParserService, IByteParserService
    {
        public override string ParseBytesToString(byte[] bytes)
        {
            //TODO: OCR library
            throw new NotImplementedException();
        }
    }
}
