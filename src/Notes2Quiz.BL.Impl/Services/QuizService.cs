using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class QuizService : IQuizService
    {
        public async Task<string> DummyMethod(string input)
        {
            await Task.Run(() => { Thread.Sleep(5000); });
            var result = $"Hello, {input}!";
            return result;
        }

        public IQuiz GenerateQuizFromText(string input, string quizName = "")
        {
            //TODO: if quizName is null or whitespace, then generate a name for it
            throw new NotImplementedException();
        }
    }
}
