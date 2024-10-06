namespace Notes2Quiz.BL.Models.Factories
{
    /// <summary>
    /// This factory creates IQuiz instances.
    /// </summary>
    public interface IQuizFactory
    {
        /// <summary>
        /// Creates an IQuiz instance.
        /// </summary>
        /// <param name="title">The quiz title.</param>
        /// <param name="questions">The questions for the quiz.</param>
        /// <returns>An IQuiz instance.</returns>
        IQuiz CreateQuiz(string title, IEnumerable<IQuestion> questions);
    }
}
