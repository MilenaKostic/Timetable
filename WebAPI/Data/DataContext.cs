using Microsoft.EntityFrameworkCore;
using Shared.DTO.User;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Calendar> calendars { get; set; }
        public DbSet<Models.Route> routes { get; set; }
        public DbSet<CalendarDate> calendarDates { get; set; }
        public DbSet<Stop> stops { get; set; }
        public DbSet<StopTime> stopTimes { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<RouteStop> routeStops { get; set; }

       
    }
}
