using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenCay.Models.Dao;
using WenCay.Models.Entity;

namespace WenCay.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Send(string name, string mobile, string address, string email, string content)
        {
            var feedback = new FeedBack();
            feedback.Ten = name;
            feedback.email = email;
            feedback.Ngay = DateTime.Now;
            feedback.mobie = mobile;
            feedback.NoiDung = content;
            feedback.DiaChi = address;

            var id = new ContactDao().InsertFeedBack(feedback);
            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
                //send mail
            }

            else
                return Json(new
                {
                    status = false
                });

        }
    }
}