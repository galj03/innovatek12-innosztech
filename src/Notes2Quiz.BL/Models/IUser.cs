namespace Notes2Quiz.BL.Models
{
    /// <summary>
    /// This model represents a user.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// The user name.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// The user's password.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// The user's authentication token.
        /// </summary>
        string Token { get; }
    }
}
