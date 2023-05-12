namespace H3CExpress.Data.NewEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassUser")]
    public partial class ClassUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public double? FirstScore { get; set; }

        public double? SecondScore { get; set; }

        [StringLength(50)]
        public string EstimateTitle { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public virtual classes classes { get; set; }

        public virtual users users { get; set; }
    }
}
