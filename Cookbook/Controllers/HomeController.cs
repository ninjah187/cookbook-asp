using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.ExtensionMethods;
using Cookbook.Models;
using Cookbook.Services;
using Ninject;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            if (UserService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(UserService.LoggedUser);
        }
    }
}