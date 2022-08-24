using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities1 = new WebsiteBanHangEntities();
        // GET: Product
        public ActionResult Index(int Id)
        {
            var objProduct = objWebsiteBanHangEntities1.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}