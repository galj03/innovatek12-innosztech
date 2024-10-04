using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    public interface IAuthService
    {
        IUser Authenticate(string username, string password);
    }
}
