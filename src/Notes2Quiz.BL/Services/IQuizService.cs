using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    /// <summary>
    /// This service supplies quiz-related queries.
    /// </summary>
    public interface IQuizService
    {
        /// <summary>
        /// Generates quiz instances from the given input notes.
        /// </summary>
        /// <param name="input">The input notes.</param>
        /// <param name="quizName">The quiz name. If not given, a default name will be assigned.</param>
        /// <returns>An IQuiz instance.</returns>
        Task<IQuiz> GenerateQuizFromText(string input, string quizName = "");
    }
}
