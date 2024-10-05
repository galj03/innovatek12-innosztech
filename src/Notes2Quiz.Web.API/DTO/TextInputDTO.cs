namespace Notes2Quiz.Web.API.DTO
{
    public class TextInputDTO
    {
        public string Text { get; }

        public TextInputDTO(string text)
        {
            Text = text;
        }
    }
}
