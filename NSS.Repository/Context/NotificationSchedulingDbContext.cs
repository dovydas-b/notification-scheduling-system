using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using notification_scheduling_system.DataContracts.Domain;
using notification_scheduling_system.DataContracts.Enums;

namespace NSS.Repository.Context
{
    public class NotificationSchedulingDbContext : DbContext
    {
        public NotificationSchedulingDbContext(DbContextOptions<NotificationSchedulingDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Company>()
                .Property(e => e.MarketType)
                .HasConversion(new EnumToStringConverter<MarketType>());

            modelBuilder
                .Entity<Company>()
                .Property(e => e.Type)
                .HasConversion(new EnumToStringConverter<CompanyType>());

            base.OnModelCreating(modelBuilder);
        }
    }
}