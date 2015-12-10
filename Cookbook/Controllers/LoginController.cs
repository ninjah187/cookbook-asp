using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Security;
using Cookbook.Services;
using Ninject;

namespace Cookbook.Controllers
{
    public class LoginController : Controller
    {
        [Inject]
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate(string login, string password)
        {
            UserService.Login(login, password);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            UserService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}