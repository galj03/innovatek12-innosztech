﻿using Notes2Quiz.BL.Models;
using Notes2Quiz.BL.Services;

namespace Notes2Quiz.BL.Impl.Services
{
    internal class AuthService : IAuthService
    {
        #region Inherited members
        public IUser Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
