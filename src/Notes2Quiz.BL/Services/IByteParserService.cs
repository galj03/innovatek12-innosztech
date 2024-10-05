namespace Notes2Quiz.BL.Services
{
    public interface IByteParserService
    {
        string ParseBytesToString(byte[] bytes);
        IEnumerable<string> ParseByteCollectionToStringCollection(IEnumerable<byte[]> byteCollection);
    }
}
