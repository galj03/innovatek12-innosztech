using Notes2Quiz.BL.Enums;
using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Impl.Models
{
    internal class Question : IQuestion
    {
        #region Properties
        public string QuestionText { get; }
        public QuestionType QuestionType { get; }
        public IEnumerable<string> PossibleAnswers { get; }
        public string CorrectAnswer { get; }
        #endregion

        #region ctor
        public Question(
            string questionText,
            QuestionType questionType,
            IEnumerable<string> possibleAnswers,
            string correctAnswer)
        {
            if (string.IsNullOrWhiteSpace(questionText))
            {
                throw new ArgumentException($"'{nameof(questionText)}' cannot be null or whitespace.", nameof(questionText));
            }

            if (string.IsNullOrWhiteSpace(correctAnswer))
            {
                throw new ArgumentException($"'{nameof(correctAnswer)}' cannot be null or whitespace.", nameof(correctAnswer));
            }

            QuestionText = questionText;
            QuestionType = questionType;
            PossibleAnswers = possibleAnswers ?? throw new ArgumentNullException(nameof(possibleAnswers));
            CorrectAnswer = correctAnswer;
        }
        #endregion
    }
}
