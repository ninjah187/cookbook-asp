using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Cookbook.Models;
using Cookbook.Security;

namespace Cookbook.Controllers
{
    public class UsersController : Controller
    {
        //[HttpPost]
        public ActionResult Create(string login, string password)
        {
            User user = null;
            using (var context = new AppDbContext())
            {
                user = new User();
                user.Login = login;

                var hashManager = new PBKDF2HashManager();
                var keySaltPair = hashManager.GetKeyAndSalt(password);

                user.PasswordKey = keySaltPair.Key;
                user.PasswordSalt = keySaltPair.Salt;

                context.Users.Add(user);
                context.SaveChanges();
            }

            return View(user);
        }

        public ActionResult Read(int id)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.Single(u => u.Id == id);
                //var user = context.Users.Last();
                return View(user);
            }
        }
    }
}