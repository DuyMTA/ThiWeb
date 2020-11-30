using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenCay.Models;
using WenCay.Models.Entity;
using WenCay.Models.Function;
using WenCay.Models.Dao;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace WenCay.Controllers
{
    
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart !=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.ID == item.SanPham.ID);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(int IdSP, int SoLuong)
        {
            var product = new ProductDao().ViewDetail(IdSP);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.SanPham.ID==IdSP))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.ID == IdSP)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }
                } else
                {
                    //tao moi doi tuong cart item
                    var item = new CartItem();
                    item.SanPham = product;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                // gan vao session
                Session[CartSession] = list;
            }
            else
            {
                //tao moi doi tuong cart item
                var item = new CartItem();
                item.SanPham = product;
                item.SoLuong = SoLuong;
                var list = new List<CartItem>();
                list.Add(item);

                // gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new HOADON();
            order.Ngay = DateTime.Now;
            order.DiaChi = address;
            order.DienThoai = mobile;
            order.TenKH = shipName;
            order.email = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new HOADON_CHITIET();
                    orderDetail.IdSP = item.SanPham.ID;
                    orderDetail.MaHD = id;
                    orderDetail.TongTien = item.SanPham.Gia;
                    orderDetail.SoLuong = item.SoLuong;
                    detailDao.Insert(orderDetail);

                    total += (item.SanPham.Gia.GetValueOrDefault(0) * item.SoLuong);
                }
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
    
}