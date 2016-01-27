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
    public class ProductsController : Controller
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        public ActionResult Index()
        {
            if (UserService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var userProducts = ProductService.Repository.GetByUser(UserService.LoggedUser);

            return View(userProducts.OrderBy(p => p.Category).ToList());
        }

        public ActionResult Create()
        {
            if (UserService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(string productName, string productEnergy, ProductCategory productCategory)
        {
            var product = new Product()
            {
                Name = productName,
                KcalPer100Grams = float.Parse(productEnergy),
                Category = productCategory
            };
            
            ProductService.Repository.AddToUser(product, UserService.LoggedUser);

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Remove(int productId)
        {
            ProductService.Repository.Remove(productId, UserService.LoggedUser);

            return RedirectToAction("Index", "Products");
        }
    }
}