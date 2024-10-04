namespace Notes2Quiz.BL.Models
{
    //TODO: consider only storing data
    public interface IPdf
    {
        string Name { get; }
        byte[] Data { get; }
    }
}
