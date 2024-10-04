namespace Notes2Quiz.BL.Models
{
    public interface IQuiz
    {
        string Title { get; }
        //TODO: consider expanding with category
        IEnumerable<IQuestion> Questions { get; }
    }
}
