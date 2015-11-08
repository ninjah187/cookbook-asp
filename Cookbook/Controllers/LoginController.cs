using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Security;

namespace Cookbook.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate(string login, string password)
        {
            var hashManager = new PBKDF2HashManager();
            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login);

                if (user != null && hashManager.Authenticate(password, user.PasswordKey, user.PasswordSalt))
                {
                    Session["LoggedUser"] = user;
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}