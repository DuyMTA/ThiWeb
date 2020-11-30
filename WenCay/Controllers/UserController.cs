using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenCay.Models.Dao;
using WenCay.Models.Entity;
using WenCay.Models.Function;
using WenCay.Common;

namespace WenCay.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        //public ActionResult Login(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();
        //        var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
        //        if (result == 1)
        //        {
        //            var user = dao.GetById(model.UserName);
        //            var userSession = new UserLogin();
        //            userSession.UserName = user.Login;
        //            userSession.UserID = user.ID;
        //            Session.Add(CommonConstants.USER_SESSION, userSession);
        //            return Redirect("/");
        //        }
        //        else if (result == 0)
        //        {
        //            ModelState.AddModelError("", "Tài khoản không tồn tại.");
        //        }
        //        else if (result == -1)
        //        {
        //            ModelState.AddModelError("", "Tài khoản đang bị khoá.");
        //        }
        //        else if (result == -2)
        //        {
        //            ModelState.AddModelError("", "Mật khẩu không đúng.");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "đăng nhập không đúng.");
        //        }
        //    }
        //    return View(model);
        //}
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new KHACHHANG();
                    user.HoTen = model.Name;
                    user.Login = model.UserName;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.DienThoai = model.Phone;
                    user.Email = model.Email;
                    user.DiaChi = model.Address;
                    user.NgaySinh = model.NgaySinh;
                    user.GioiTinh = model.GioiTinh;
                    //user.Status = true;
                    //if (!string.IsNullOrEmpty(model.ProvinceID))
                    //{
                    //    user.ProvinceID = int.Parse(model.ProvinceID);
                    //}
                    //if (!string.IsNullOrEmpty(model.DistrictID))
                    //{
                    //    user.DistrictID = int.Parse(model.DistrictID);
                    //}

                    var result = dao.insert(user);
                    if (result >= 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
    }
}