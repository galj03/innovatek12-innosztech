using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    public interface IUserService
    {
        IUser? Authenticate(string username, string password);
        IUser? GetByUsername(string username);
    }
}
