using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenCay.Models;
using WenCay.Models.Entity;

namespace WenCay.Controllers
{
    public class PagesController : Controller
    {
        ModelWebCay db = new ModelWebCay();
        // GET: Pages
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Blog()
        {
            var blog = db.BAIVIETs.ToList();
            ViewBag.blog = blog;
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult BlogDetail()
        {
            if (Request.Url.Segments.Count() == 3)
            {
                return RedirectToAction("Blog");
            }
            var id = Request.Url.Segments[3];
            var blog = db.BAIVIETs.Where(x => x.ID.ToString() == id).FirstOrDefault(); 
            ViewBag.blog = blog;
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Shop()
        {
            var model = db.SANPHAMs.ToList();
            return View(model);
        }
        public ActionResult ShopDetails()
        {
            //var product = new SANPHAM()
            if (Request.Url.Segments.Count() == 3)
            {
                return RedirectToAction("Shop");
            }
            var id = Request.Url.Segments[3];
            var product = db.SANPHAMs.Where(x => x.ID.ToString() == id).FirstOrDefault(); ;
            ViewBag.product = product;
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}