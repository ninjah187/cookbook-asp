using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Models;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = (User) Session["LoggedUser"];

            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(user);
        }
    }
}