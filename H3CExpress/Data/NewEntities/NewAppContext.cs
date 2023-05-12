using System.Data.Entity;

namespace H3CExpress.Data.NewEntities
{
    public partial class NewAppContext : DbContext
    {
        public NewAppContext()
            : base("name=NewAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewAppContext, Configuration>());
        }

        public virtual DbSet<classes> classes { get; set; }
        public virtual DbSet<ClassUser> ClassUser { get; set; }
        public virtual DbSet<courses> courses { get; set; }
        public virtual DbSet<HoaDons> HoaDons { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<classes>()
                .HasMany(e => e.ClassUser)
                .WithRequired(e => e.classes)
                .HasForeignKey(e => e.ClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassUser>()
                .Property(e => e.EstimateTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ClassUser>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<courses>()
                .HasMany(e => e.classes)
                .WithRequired(e => e.courses)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<courses>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.courses)
                .HasForeignKey(e => e.MaHang);

            modelBuilder.Entity<roles>()
                .HasMany(e => e.users)
                .WithRequired(e => e.roles)
                .HasForeignKey(e => e.roleId);


            modelBuilder.Entity<users>()
                .HasMany(e => e.ClassUser)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<users>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.MaNV);
        }
    }
}
