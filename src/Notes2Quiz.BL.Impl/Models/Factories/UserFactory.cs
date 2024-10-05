using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Models.Factories;

namespace Notes2Quiz.BL.Impl.Models.Factories
{
    internal class UserFactory : IUserFactory
    {
        public IUser CreateUser(string username, string password, string token)
        {
            return new User(username, password, token);
        }
    }
}
