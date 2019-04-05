using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hirent.Models;
namespace Hirent.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null,false);
            ViewBag.MainCategories = Models.Category.GetCategory(null,false).Count>4? Models.Category.GetCategory(null,false).Take(4): Models.Category.GetCategory(null,false);
            ViewBag.MainProducts = Models.Product.GetProduct(null,false).Count>12? Models.Product.GetProduct(null, false).Take(12): Models.Product.GetProduct(null, false);
            return PartialView();
        }

        public ActionResult Category(int id)
        {
            ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null,false);
            ViewBag.CategoryName = Models.Category.GetCategory(id,false).First().Name;
            var products = Models.Product.GetProductByCategoryId(id, false);
            return PartialView(products);
        }
        public ActionResult Search(string query)
        {
            var product = Product.GetProductByQuery(query, false);
            ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null, false);
            ViewBag.CategoryName = string.Format(@"Search results for ""{0}""", query);
            return PartialView("Category", product);
        }
        public ActionResult About()
        {
            ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null, false);
            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null, false);
            return PartialView();
        }

        public ActionResult ProductPartial(int id)
        {
            var product = Product.GetProduct(id, false).First();
            return PartialView(product);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguages().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}