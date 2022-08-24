using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using static WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Category
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var listCategory = new List<Category>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currenFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                listCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
                // return View(listProduct);
            }
            else
            {
                listCategory = objWebsiteBanHangEntities.Categories.ToList();
            }
            ViewBag.CurenFilter = SearchString;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            listCategory = listCategory.OrderByDescending(n => n.Id).ToList();
            return View(listCategory.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category objCategory)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {

                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                   
                    objWebsiteBanHangEntities.Categories.Add(objCategory);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objCate)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == objCate.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Categories.Remove(objCategory);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Edit(Category objCategory)
        {
            if (objCategory.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objCategory.Avatar = fileName;
                objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebsiteBanHangEntities.Entry(objCategory).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();

            return RedirectToAction("Index");
        }
        void LoadData()
        {
            Common objCommon = new Common();
            var listCat = objWebsiteBanHangEntities.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(listCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");
            var listBrand = objWebsiteBanHangEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(listBrand);

            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

           
        }
    }
}