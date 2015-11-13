using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Models;

namespace Cookbook.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Index()
        {
            var user = (User) Session["LoggedUser"];
            if (VerifyUserAccessPriviliges(user) == false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Products()
        {
            var user = (User) Session["LoggedUser"];
            if (VerifyUserAccessPriviliges(user) == false)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var context = new AppDbContext())
            {
                return View(context.Products.ToList());
            }
        }

        public ActionResult Users()
        {
            var user = (User)Session["LoggedUser"];
            if (VerifyUserAccessPriviliges(user) == false)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var context = new AppDbContext())
            {
                return View(context.Users.ToList());
            }

        }

        private bool VerifyUserAccessPriviliges(User user)
        {
            if (user == null || user.Role != UserRole.Admin)
            {
                return false;
            }
            return true;
        }
    }
}