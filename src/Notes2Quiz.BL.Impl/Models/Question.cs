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
        public IEnumerable<string> CorrectAnswers { get; }
        #endregion

        #region ctor
        public Question(
            string questionText,
            QuestionType questionType,
            IEnumerable<string> possibleAnswers,
            IEnumerable<string> correctAnswers)
        {
            if (string.IsNullOrWhiteSpace(questionText))
            {
                throw new ArgumentException($"'{nameof(questionText)}' cannot be null or whitespace.", nameof(questionText));
            }

            QuestionText = questionText;
            QuestionType = questionType;
            PossibleAnswers = possibleAnswers ?? throw new ArgumentNullException(nameof(possibleAnswers));
            CorrectAnswers = correctAnswers ?? throw new ArgumentNullException(nameof(correctAnswers));
        }
        #endregion
    }
}
