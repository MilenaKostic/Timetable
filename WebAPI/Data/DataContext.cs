using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Calendar> calendars { get; set; }
        public DbSet<Shared.Models.Route> routes { get; set; }
        public DbSet<CalendarDate> calendarDates { get; set; }
        public DbSet<Stop> stops { get; set; }
        public DbSet<StopTime> stopTimes { get; set; }
        public DbSet<Trip> trips { get; set; }

       
    }
}
