namespace WenCay.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            HOADON_CHITIET = new HashSet<HOADON_CHITIET>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        public int? GiamGia { get; set; }

        public int? ThanhTien { get; set; }

        public bool? TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public int? MaKH { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(30)]
        public string TenKH { get; set; }

        [StringLength(10)]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON_CHITIET> HOADON_CHITIET { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
