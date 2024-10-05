using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class OcrByteParserService : AByteParserService, IByteParserService
    {
        #region Inherited members
        public override string ParseBytesToString(byte[] bytes)
        {
            //TODO: OCR library
            throw new NotImplementedException();
        }
        #endregion
    }
}
