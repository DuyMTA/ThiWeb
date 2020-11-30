using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using WenCay.Models.Entity;

namespace WenCay.Models.Dao
{
    public class ProductDao
    {
        ModelWebCay db = null;
        public ProductDao()
        {
            db = new ModelWebCay();
        }

        public SANPHAM ViewDetail(int id)
        {
            return db.SANPHAMs.Find(id);
        }
    }
}