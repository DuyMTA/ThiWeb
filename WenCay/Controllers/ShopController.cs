using Model.Dao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WenCay.Models.Entity;

namespace WenCay.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(int id=0, int page=1,int pageSize=6)
        {
            int totalRecord = 0;
            int sort = Convert.ToInt32(Request["sort"]);
            var model= new SanPhamDao().ListSanPhamTheLoaiPhanTrang(id,ref totalRecord,page,pageSize,sort);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.Theloai = id;
            ViewBag.TenTheLoai = new SanPhamDao().TenTheLoai(id);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Pre= page - 1;
            ViewBag.SortBy = sort;
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            IDictionary<THELOAI, int> model = new SanPhamDao().DisplayCategory();
            int x = 0;
            foreach (var item in model) { x = x + item.Value; }
            ViewBag.Tong = x;
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult ShopDetails(int id=1)
        {
            var sp = new SanPhamDao();
            var model = sp.SanPhamDetail(id);
            ViewBag.theloai = sp.TenTheLoai(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult ShopCart(int id = 1)
        {
            var model = new SanPhamDao().SanPhamDetail(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult ShopCheckout(int id = 0)
        {
            var model = new SanPhamDao().SanPhamDetail(id);
            return View(model);
        }
        
    }
}