using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Impl.Models
{
    internal class User : IUser
    {
        #region Properties
        public string Username { get; }
        public string Password { get; }
        public string Token { get; }
        #endregion

        #region ctor
        public User(string username, string password, string token="")
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
            }

            Username = username;
            Password = password;
            Token = token;
        }
        #endregion
    }
}
