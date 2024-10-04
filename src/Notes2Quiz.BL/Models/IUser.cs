namespace Notes2Quiz.BL.Models
{
    public interface IUser
    {
        string Username { get; }
        string Password { get; }
        string Token { get; }
    }
}
