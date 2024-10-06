namespace Notes2Quiz.BL.Models
{
    /// <summary>
    /// This model represents a quiz.
    /// </summary>
    public interface IQuiz
    {
        /// <summary>
        /// The quiz title.
        /// </summary>
        string Title { get; }

        //TODO: consider expanding with category

        /// <summary>
        /// The quiz questions.
        /// </summary>
        IEnumerable<IQuestion> Questions { get; }
    }
}
