using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WenCay.Models.Entity;

namespace WenCay.Models.Dao
{
    public class OrderDetailDao
    {
        ModelWebCay db = null;
        public OrderDetailDao()
        {
            db = new ModelWebCay();
        }
        public bool Insert(HOADON_CHITIET detail)
        {
            try
            {
                db.HOADON_CHITIET.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}