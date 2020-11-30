using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WenCay.Models.Entity;

namespace WenCay.Models.Function
{
    [Serializable]
    public class CartItem
    {
        
        public SANPHAM SanPham { set; get; }
        public int SoLuong { set; get; }
    }
}