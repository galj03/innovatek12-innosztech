using Notes2Quiz.BL.Enums;
using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Models.Factories;

namespace Notes2Quiz.BL.Impl.Models.Factories
{
    internal class QuestionFactory : IQuestionFactory
    {
        #region Inherited members
        public IQuestion CreateOneCorrectAnswerQuestion(string question, IEnumerable<string> possibleAnswers, string correctAnswer)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException($"'{nameof(question)}' cannot be null or whitespace.", nameof(question));
            }

            if (possibleAnswers is null)
            {
                throw new ArgumentNullException(nameof(possibleAnswers));
            }

            if (string.IsNullOrWhiteSpace(correctAnswer))
            {
                throw new ArgumentException($"'{nameof(correctAnswer)}' cannot be null or whitespace.", nameof(correctAnswer));
            }

            return CreateQuestion(question, QuestionType.OneCorrectAnswer, possibleAnswers, [correctAnswer]);
        }

        public IQuestion CreateOneCorrectAnswerQuestion(string question, IEnumerable<string> possibleAnswers, IEnumerable<string> correctAnswers)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException($"'{nameof(question)}' cannot be null or whitespace.", nameof(question));
            }

            if (possibleAnswers is null)
            {
                throw new ArgumentNullException(nameof(possibleAnswers));
            }

            if (correctAnswers is null)
            {
                throw new ArgumentNullException(nameof(correctAnswers));
            }

            return CreateQuestion(question, QuestionType.MultipleCorrectAnwsers, possibleAnswers, correctAnswers);
        }
        #endregion

        #region Private methods
        private IQuestion CreateQuestion(
            string question,
            QuestionType questionType,
            IEnumerable<string> possibleAnswers,
            IEnumerable<string> correctAnswers)
        {
            return new Question(question, questionType, possibleAnswers, correctAnswers);
        }
        #endregion
    }
}
