using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    public interface IQuizService
    {
        Task<IQuiz> GenerateQuizFromText(string input, string quizName = "");
    }
}
