namespace Notes2Quiz.BL.Models
{
    public interface IPdf
    {
        string Name { get; }
        byte[] Data { get; }
    }
}
