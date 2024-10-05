namespace Notes2Quiz.BL.Models.Factories
{
    public interface IQuestionFactory
    {
        IQuestion CreateOneCorrectAnswerQuestion(string question, IEnumerable<string> possibleAnswers, string correctAnswer);
        IQuestion CreateOneCorrectAnswerQuestion(string question, IEnumerable<string> possibleAnswers, IEnumerable<string> correctAnswers);
    }
}
