using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.Database
{
	public class PlaydayDbContext : DbContext
	{
		public DbSet<Car> Cars { get; set; } = null!;
		public DbSet<Bike> Bikes { get; set; } = null!;
		public DbSet<Appartment> Appartments{ get; set; } = null!;
		public DbSet<Scooter> Scooters { get; set; } = null!;
		public DbSet<House> Houses { get; set; } = null!;

		public PlaydayDbContext(DbContextOptions<PlaydayDbContext> options) : base(options)
		{
		}
	}
}
