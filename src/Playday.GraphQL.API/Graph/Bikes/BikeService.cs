using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.Database;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Bikes
{
	public class BikeService
	{
		private readonly PlaydayDbContext _dbContext;

		public BikeService(PlaydayDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<Bike>> GetBikes()
			=> await _dbContext.Bikes.ToListAsync();

	}
}
