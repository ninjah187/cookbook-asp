using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Cookbook.Exceptions;
using Cookbook.Models;
using Cookbook.Security;
using Ninject;

namespace Cookbook.Services
{
    public class UserService : IUserService
    {
        [Inject]
        public IUserRepository Repository { get; set; }

        [Inject]
        public IKeySaltManager HashManager { get; set; }

        [Inject]
        public HttpSessionState SessionState { get; set; }

        public void Login(string login, string password)
        {
            var user = Repository.GetByLogin(login);
            
            if (user == null)
            {
                throw new NoSuchUserInDatabaseException(login);
            }

            if (HashManager.Authenticate(password, user.PasswordKey, user.PasswordSalt))
            {
                SessionState["LoggedUser"] = user;
            }
            else
            {
                throw new WrongPasswordException();
            }
        }

        public void Logout()
        {
            SessionState["LoggedUser"] = null;
        }

        public void Create(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool VerifyUserAdminPriviliges()
        {
            var user = (User) SessionState["LoggedUser"];

            if (user != null && user.Role == UserRole.Admin)
            {
                return true;
            }

            return false;
        }
    }
}