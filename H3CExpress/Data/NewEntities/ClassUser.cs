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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public float? ListeningScore { get; set; }

        public float? ReadingScore { get; set; }

        public float? SpeakingScore { get; set; }

        public float? WritingScore { get; set; }

        [StringLength(50)]
        public string EstimateTitle { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public virtual classes classes { get; set; }

        public virtual users users { get; set; }
    }
}
