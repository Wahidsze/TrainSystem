using Microsoft.EntityFrameworkCore;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Database
{
    public class ApplicationContext : DbContext
    {
		public virtual DbSet<TicketModel> Tickets { get; set; }
        public virtual DbSet<ConditionModel> Conditions { get; set; }
        public virtual DbSet<RouteModel> Routes { get; set; }
        public virtual DbSet<DateModel> Dates { get; set; }
        public virtual DbSet<PlaceModel> Places { get; set; }
        public virtual DbSet<TrainModel> Trains { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<WagonModel> Wagons { get; set; }
        public virtual DbSet<UserTicketModel> UserTickets { get; set; }
        public virtual DbSet<WagonConditionModel> WagonConditions { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
        public ApplicationContext() { }
    }
}
