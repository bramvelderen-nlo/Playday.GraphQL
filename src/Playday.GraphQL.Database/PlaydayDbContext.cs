using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.Database
{
	public class PlaydayDbContext : DbContext
	{
		public DbSet<Car>? Cars { get; set; }

		public PlaydayDbContext(DbContextOptions<PlaydayDbContext> options) : base(options)
		{
		}
	}
}
