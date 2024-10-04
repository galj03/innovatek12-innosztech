using System.ComponentModel.DataAnnotations;

namespace Notes2Quiz.Web.API.DTO
{
    public class AuthenticateRequest
    {
        #region Properties
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        #endregion

        #region ctor
        public AuthenticateRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
        #endregion
    }
}
