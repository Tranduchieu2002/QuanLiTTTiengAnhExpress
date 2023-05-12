namespace H3CExpress.Data.NewEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDons
    {
        [Key]
        public int SoHoaDon { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayLap { get; set; }

        public double? ThanhTien { get; set; }

        public int? MaKH { get; set; }

        public int? MaHang { get; set; }

        public int? MaNV { get; set; }

        public virtual courses courses { get; set; }

        public virtual users users { get; set; }
    }
}
