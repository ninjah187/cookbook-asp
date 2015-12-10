using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using Cookbook.Models;
using Cookbook.Security;

namespace Cookbook.Services
{
    public interface IUserService
    {
        void Login(string login, string password);
        void Logout();
        void Create(string login, string password);

        /// <summary>
        /// Verifies if currently logged user is admin.
        /// </summary>
        bool VerifyUserAdminPriviliges();

        IUserRepository Repository { get; }
        IKeySaltManager HashManager { get; }
        HttpSessionState SessionState { get; }
    }
}
