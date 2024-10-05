using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Notes2Quiz.BL.Application;
using Notes2Quiz.BL.Impl.Models;
using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Models.Factories;
using Notes2Quiz.BL.Services;
using System.Security.Claims;
using System.Text;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class UserService : IUserService
    {
        #region Fields
        private readonly IUserFactory _userFactory;
        private readonly IApplicationSettings _appSettings;
        private readonly IEnumerable<IUser> _users = new List<IUser> //TODO: replace with db and registration
        {
            new User("admin", "admin")
        };
        #endregion

        #region ctor
        public UserService(IUserFactory userFactory, IApplicationSettings applicationSettings)
        {
            _userFactory = userFactory ?? throw new ArgumentNullException(nameof(userFactory));
            _appSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
        }
        #endregion

        #region IAuthService members
        public IUser? Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null) { return null; }

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token); //TODO: assign token
        }

        public IUser? GetByUsername(string username)
        {
            return _users.SingleOrDefault(x => x.Username == username);
        }
        #endregion

        #region Private methods
        private string GenerateJwtToken(IUser user)
        {
            var tokenHandler = new JsonWebTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(Constants.User.USER_NAME, user.Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
        #endregion
    }
}
