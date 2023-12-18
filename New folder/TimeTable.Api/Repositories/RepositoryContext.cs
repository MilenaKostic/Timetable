using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TimeTable.Api.Entities.Models;
using TimeTable.Api.Repositories.Configuration;

namespace TimeTable.Api.Repositories
{
	public class RepositoryContext :IdentityDbContext
	{


		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
		//public RepositoryContext(DbContextOptions options) : base(options)
		//{
		//	// base.OnModelCreating(modelBuilder);

			
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}

		public DbSet<Calendar> Calendars { get; set; }
		public DbSet<Entities.Models.Route> Routes { get; set; }
		public DbSet<CalendarDate> CalendarDates { get; set; }
		public DbSet<Stop> Stops { get; set; }
		public DbSet<StopTime> StopTimes { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<RouteStop> RouteStops { get; set; }
		public DbSet<Shape> Shapes { get; set; }
		public DbSet<SiteUser> SiteUsers {  get; set; }

	}
}
