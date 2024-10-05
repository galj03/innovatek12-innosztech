using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Models.Factories;

namespace Notes2Quiz.BL.Impl.Models.Factories
{
    internal class QuizFactory : IQuizFactory
    {
        public IQuiz CreateQuiz(string title, IEnumerable<IQuestion> questions)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }

            if (questions is null)
            {
                throw new ArgumentNullException(nameof(questions));
            }

            return new Quiz(title, questions);
        }
    }
}
