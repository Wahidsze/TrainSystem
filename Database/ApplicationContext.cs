using Microsoft.EntityFrameworkCore;
using TrainSystem.Models;

namespace TrainSystem.Database
{
	public class ApplicationContext : DbContext
	{
		public DbSet<TicketModel> Tickets { get; set; }
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
