namespace WenCay.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        [StringLength(50)]
        public string NoiDung { get; set; }

        public int? IDKhachHang { get; set; }

        [StringLength(30)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string mobie { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
