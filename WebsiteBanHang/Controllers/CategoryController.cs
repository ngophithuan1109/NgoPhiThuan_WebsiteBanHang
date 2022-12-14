using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Category
        public ActionResult Index()
        {
            var ListCategory = objWebsiteBanHangEntities.Categories.ToList();
            return View(ListCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var ListProduct = objWebsiteBanHangEntities.Products.Where(n => n.CategoryId == Id).ToList();
            return View(ListProduct);
        }
    }
}