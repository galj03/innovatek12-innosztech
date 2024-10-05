using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    public interface IQuizService
    {
        IQuiz GenerateQuizFromText(string input, string quizName = "");

        Task<string> DummyMethod(string input);
    }
}
