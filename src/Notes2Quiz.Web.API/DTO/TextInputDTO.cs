namespace Notes2Quiz.Web.API.DTO
{
    /// <summary>
    /// This model wraps a simple text value.
    /// </summary>
    public class TextInputDTO
    {
        #region Properties
        /// <summary>
        /// The text value.
        /// </summary>
        public string Text { get; }
        #endregion

        #region ctor
        public TextInputDTO(string text)
        {
            Text = text;
        }
        #endregion
    }
}
