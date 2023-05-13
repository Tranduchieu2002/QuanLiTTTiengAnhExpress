namespace H3CExpress.Data.NewEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class users
    {
        public enum Gender
        {
            Unknown,
            Male,
            Female
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            classes = new HashSet<classes>();
            ClassUser = new HashSet<ClassUser>();
            HoaDons = new HashSet<HoaDons>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public Gender gender { get; set; }

        public int roleId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<classes> classes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassUser> ClassUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDons> HoaDons { get; set; }

        public virtual roles roles { get; set; }
    }
}
