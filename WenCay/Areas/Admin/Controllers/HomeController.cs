using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenCay.Common;
using WenCay.Models.Dao;
using WenCay.Models.Function;

namespace WenCay.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        
    }
}