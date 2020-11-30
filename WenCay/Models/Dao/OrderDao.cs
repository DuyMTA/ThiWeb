using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WenCay.Models.Entity;

namespace WenCay.Models.Dao
{
    public class OrderDao
    {
        ModelWebCay db = null;
        public OrderDao()
        {
            db = new ModelWebCay();
        }
        public int Insert(HOADON order)
        {
            db.HOADONs.Add(order);
            db.SaveChanges();
            return order.MaHD;
        }
    }
}