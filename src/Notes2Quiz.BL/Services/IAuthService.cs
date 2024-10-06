using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Services
{
    /// <summary>
    /// This service supplies authentication-related queries.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user by username and password.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns>An IUser instance.</returns>
        IUser Authenticate(string username, string password);
    }
}
