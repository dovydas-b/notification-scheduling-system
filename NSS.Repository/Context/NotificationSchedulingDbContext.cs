using Microsoft.EntityFrameworkCore;
using notification_scheduling_system.DataContracts.Domain;

namespace NSS.Repository.Context
{
    public class NotificationSchedulingDbContext : DbContext
    {
        public NotificationSchedulingDbContext(DbContextOptions<NotificationSchedulingDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<NotificationSchedule> NotificationSchedules { get; set; }
    }
}