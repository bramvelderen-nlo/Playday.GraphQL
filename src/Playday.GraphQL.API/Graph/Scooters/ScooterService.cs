using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.Database;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Scooters
{
	public class ScooterService
	{
		private readonly PlaydayDbContext _dbContext;

		public ScooterService(PlaydayDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<Scooter>> GetScooters()
			=> await _dbContext.Scooters.ToListAsync();

	}
}
