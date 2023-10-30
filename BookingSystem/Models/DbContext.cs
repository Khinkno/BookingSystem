using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<UserInfo> user { get; set; }

        public DbSet<Packages> packages { get; set; }

        public DbSet<UserPackage> UserPackage { get; set; }

        public DbSet<ClassSchedule> classSchedule { get; set; }

        public DbSet<booking> booking { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInfo>()
            .Property(a => a.userid).IsConcurrencyToken();
            modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
            modelBuilder.Entity<Packages>()
            .Property(a => a.pid).IsConcurrencyToken();
            modelBuilder.Entity<Packages>().ToTable("packages");
            modelBuilder.Entity<UserPackage>()
            .Property(a => a.user_pid).IsConcurrencyToken();
            modelBuilder.Entity<UserPackage>().ToTable("user_package");
            modelBuilder.Entity<ClassSchedule>()
            .Property(a => a.classid).IsConcurrencyToken();
            modelBuilder.Entity<ClassSchedule>().ToTable("class");
            modelBuilder.Entity<booking>()
             .Property(a => a.bookingid).IsConcurrencyToken();
            modelBuilder.Entity<booking>().ToTable("booking");

        }

        //public DbSet<EVoucherSystem.Models.PurchaseEVoucherViewModel>? PurchaseEVoucherViewModel { get; set; }

        //public DbSet<DTO.UserDTO>? userDTOs { get; set; }
    }
}
