using Notes2Quiz.BL.Enums;

namespace Notes2Quiz.BL.Models
{
    /// <summary>
    /// This model represents a quiz question.
    /// </summary>
    public interface IQuestion
    {
        /// <summary>
        /// The question.
        /// </summary>
        string QuestionText { get; }

        /// <summary>
        /// The question type.
        /// </summary>
        QuestionType QuestionType { get; }

        /// <summary>
        /// The possible answers to choose from.
        /// </summary>
        IEnumerable<string> PossibleAnswers { get; }

        /// <summary>
        /// The correct answers.
        /// </summary>
        IEnumerable<string> CorrectAnswers { get; }
    }
}
