using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Services
{
    internal abstract class AByteParserService : IByteParserService
    {
        #region Inherited members
        public IEnumerable<string> ParseByteCollectionToStringCollection(IEnumerable<byte[]> byteCollection)
        {
            if (byteCollection is null)
            {
                throw new ArgumentNullException(nameof(byteCollection));
            }

            var result = new List<string>();

            foreach (byte[] byteArray in byteCollection)
            {
                result.Add(ParseBytesToString(byteArray));
            }

            return result;
        }

        public abstract string ParseBytesToString(byte[] bytes);
        #endregion
    }
}
