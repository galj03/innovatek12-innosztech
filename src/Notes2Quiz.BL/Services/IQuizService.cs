using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    public interface IQuizService
    {
        IQuiz GenerateQuizFromText(string input, string quizName = "");

        string DummyMethod(string input);
    }
}
