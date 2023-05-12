namespace H3CExpress.Data.NewEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using static DevExpress.XtraEditors.Mask.MaskSettings;

    public partial class classes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public classes()
        {
            ClassUser = new HashSet<ClassUser>();
        }

        public int course_id { get; set; }

        public int? schedule_id { get; set; }

        public int id { get; set; }

        public int? teacher_id { get; set; }

        public DateTime start_time { get; set; }

        public DateTime end_time { get; set; }

        public TimeSpan learning_time { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public virtual courses courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassUser> ClassUser { get; set; }

        [ForeignKey("teacher_id")]
        public virtual users Teacher { get; set; }

        [ForeignKey("schedule_id")]
        public virtual Schedules Schedules { get; set; }

    }
}
