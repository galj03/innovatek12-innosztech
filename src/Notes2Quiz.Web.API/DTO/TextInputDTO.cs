namespace Notes2Quiz.Web.API.DTO
{
    public class TextInputDTO
    {
        #region Properties
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
