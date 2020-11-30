using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WenCay.Models.Entity;

namespace WenCay.Models.Dao
{
    public class UserDao
    {
        ModelWebCay db = null;

        public UserDao()
        {
            db = new ModelWebCay();
        }

        public int insert(KHACHHANG entity)
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool update(ADMIN entity)
        {
            try
            {
                var ad = db.ADMINs.Find(entity.MaAD);

                ad.Ten = entity.Ten;
                ad.Login = entity.Login;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public IEnumerable<ADMIN> ListAllPaging(int page = 1, int pageSize = 1)
        {
            return db.ADMINs.OrderByDescending(x => x.MaAD).ToPagedList(page, pageSize);
        }
        public KHACHHANG GetById(string UserName)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.Login == UserName);
        }
        public ADMIN ViewDetail(int ma)
        {
            return db.ADMINs.Find(ma);
        }
        public int Login(string UserName, string PassWord)
        {
            var result = db.ADMINs.SingleOrDefault(x => x.Login == UserName);
            if (result == null)
            {
                return 0;
            }
            else if (result.Trangthai == false)
            {
                return -1;
            }
            else
            {
                if (result.Password == PassWord)
                    return 1;
                else
                    return -2;
            }
        }
        public bool delete(int ma)
        {
            try
            {
                var admin = db.ADMINs.Find(ma);
                db.ADMINs.Remove(admin);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.KHACHHANGs.Count(x => x.Login == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.KHACHHANGs.Count(x => x.Email == email) > 0;
        }
    }
}