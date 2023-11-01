using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<CalendarDate> CalendarDates { get; set; }
        public DbSet<StopTime> StopTimes { get; set; }
        public DbSet<Trip> Trips { get; set; }

       
    }
}
