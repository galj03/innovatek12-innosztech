namespace Notes2Quiz.BL.Models
{
    public interface IImageCollection
    {
        string Name { get; }
        IEnumerable<byte[]> Images { get; }
    }
}
