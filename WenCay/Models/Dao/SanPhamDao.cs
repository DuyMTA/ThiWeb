using System.Collections.Generic;
using System.Data;
using System.Linq;
using WenCay.Models.Entity;

namespace Model.Dao
{
    public class SanPhamDao
    {
        ModelWebCay db = null;
        public SanPhamDao()
        {
            db = new ModelWebCay();
        }
        public List<THELOAI> ListTheLoai()
        {
            return db.THELOAIs.ToList();
        }
        public IEnumerable<SANPHAM> ListSanPham(int id)
        {
            if (id == 0) { return db.SANPHAMs.OrderByDescending(x => x.TenSP).Take(9).ToList(); }
            else { return db.SANPHAMs.OrderByDescending(x => x.TenSP).Where(x => x.MaTheLoai == id).Take(9).ToList(); }
        }
        public SANPHAM SanPhamDetail(int id=1)
        {
            return db.SANPHAMs.Find(id.ToString());
        }
        public string TenTheLoai(int id=0)
        {
            if (id == 0) { return "Tất cả"; }
            var sanpham = db.SANPHAMs.Find(id);
            var theloai= db.THELOAIs.Find(sanpham.MaTheLoai);
            return theloai.TenTheLoai   ;
        }
        public List<SANPHAM> ListSanPhamTheLoaiPhanTrang(int id, ref int totalRecord,int page=1,int pageSize=6,int sort=0)
        {
            totalRecord = db.SANPHAMs.Count();
            List< SANPHAM> list = new List<SANPHAM>();
            switch (sort)
            {
                case 0:
                    list = db.SANPHAMs.OrderBy(x => x.TenSP).ToList();
                    break;
                case 1:
                    list = db.SANPHAMs.OrderByDescending(x => x.TenSP).ToList();
                    break;
                case 2:
                    list = db.SANPHAMs.OrderBy(x => x.GiaGoc).ToList();
                    break;
                case 3:
                    list = db.SANPHAMs.OrderByDescending(x => x.GiaGoc).ToList();
                    break;
                default:
                    break;
            }
            
            if (id == 0) 
            {
                return list.Skip((page-1)*pageSize).Take(pageSize).ToList(); 
            }
            else 
            {
                totalRecord = db.SANPHAMs.Where(x => x.MaTheLoai == id).Count();
                return list.Where(x => x.MaTheLoai == id).Skip((page - 1) * pageSize).Take(pageSize).ToList(); 
            }
        }
        public IDictionary<THELOAI, int> DisplayCategory()
        {
            int soluong = 0;
            var theloai = db.THELOAIs.ToList();
            IDictionary<THELOAI, int> danhmuc = new Dictionary<THELOAI, int>();
            foreach (var item in theloai)
            {
                var sanphamX = db.DanhMucSanPhams.Find(item.MaTheLoai);
                if (sanphamX == null) { soluong = 0; }
                else { soluong = (int) sanphamX.Tong; }
                danhmuc.Add(item, soluong);
            }
            return danhmuc;
        }

    }
}
