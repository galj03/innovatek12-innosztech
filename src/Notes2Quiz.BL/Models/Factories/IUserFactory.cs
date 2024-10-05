namespace Notes2Quiz.BL.Models.Factories
{
    public interface IUserFactory
    {
        IUser CreateUser(string username, string password, string token);
    }
}
