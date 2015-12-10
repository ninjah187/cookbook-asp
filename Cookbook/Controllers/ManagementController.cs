using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Models;
using Cookbook.Services;
using Ninject;

namespace Cookbook.Controllers
{
    public class ManagementController : Controller
    {
        [Inject]
        public IProductRepository ProductRepository { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            if (UserService.VerifyUserAdminPriviliges() == false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Products()
        {
            if (UserService.VerifyUserAdminPriviliges() == false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ProductRepository.GetAll());
        }

        public ActionResult Users()
        {
            if (UserService.VerifyUserAdminPriviliges() == false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(UserService.Repository.GetAll());
        }
    }
}