using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Impl.Models
{
    internal class Quiz : IQuiz
    {
        #region Properties
        public string Title { get; }
        public IEnumerable<IQuestion> Questions { get; }
        #endregion

        #region ctor
        public Quiz(string title, IEnumerable<IQuestion> questions)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }

            Title = title;
            Questions = questions ?? throw new ArgumentNullException(nameof(questions));
        }
        #endregion
    }
}
