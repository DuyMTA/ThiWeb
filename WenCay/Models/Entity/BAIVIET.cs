namespace WenCay.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIVIET")]
    public partial class BAIVIET
    {
        [Key]
        [StringLength(50)]
        public string MaBV { get; set; }

        public int? MaAD { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(50)]
        public string ThoiGian { get; set; }

        [StringLength(50)]
        public string TenNguoiViet { get; set; }

        [StringLength(500)]
        public string LoiDan { get; set; }

        [StringLength(20)]
        public string LienQuan { get; set; }

        public int? ID { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        public virtual ADMIN ADMIN { get; set; }
    }
}
