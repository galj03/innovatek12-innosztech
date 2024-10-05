namespace Notes2Quiz.BL.Models.Factories
{
    public interface IQuizFactory
    {
        IQuiz CreateQuiz(string title, IEnumerable<IQuestion> questions);
    }
}
