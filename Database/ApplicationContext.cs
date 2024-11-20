using Microsoft.EntityFrameworkCore;
using TrainSystem.Models;

namespace TrainSystem.Database
{
	public class ApplicationContext : DbContext
	{
		public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<ConditionModel> Conditions { get; set; }
        public DbSet<RouteModel> Routes { get; set; }
        public DbSet<DateModel> Dates { get; set; }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<TrainModel> Trains { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WagonModel> Wagons { get; set; }

        public DbSet<UserTicketModel> UserTickets { get; set; }
        public DbSet<WagonConditionModel> WagonConditions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
