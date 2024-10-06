namespace Notes2Quiz.BL.Models.Factories
{
    /// <summary>
    /// This factory creates various IQuestion instances.
    /// </summary>
    public interface IQuestionFactory
    {
        /// <summary>
        /// This method creates questions with only one correct answer.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <param name="possibleAnswers">The collection of possible answers.</param>
        /// <param name="correctAnswer">The correct answer.</param>
        /// <returns>An IQuestion instance.</returns>
        IQuestion CreateOneCorrectAnswerQuestion(string question, IEnumerable<string> possibleAnswers, string correctAnswer);

        /// <summary>
        /// This method creates questions with only one correct answer.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <param name="possibleAnswers">The collection of possible answers.</param>
        /// <param name="correctAnswers">The collection of correct answers.</param>
        /// <returns>An IQuestion instance.</returns>
        IQuestion CreateOneCorrectAnswerQuestion(string question, IEnumerable<string> possibleAnswers, IEnumerable<string> correctAnswers);
    }
}
