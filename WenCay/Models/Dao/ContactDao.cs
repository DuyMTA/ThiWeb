using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using WenCay.Models.Entity;

namespace WenCay.Models.Dao
{
    public class ContactDao
    {
        ModelWebCay db = null;
        public ContactDao()
        {
            db = new ModelWebCay();
        }

        //public Contact GetActiveContact()
        //{
        //    return db.Contacts.Single(x => x.Status == true);
        //}

        public int InsertFeedBack(FeedBack fb)
        {
            db.FeedBacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}