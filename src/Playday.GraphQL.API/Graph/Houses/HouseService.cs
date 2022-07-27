using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.Database;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Houses
{
	public class HouseService
	{
		private readonly PlaydayDbContext _dbContext;

		public HouseService(PlaydayDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<House>> GetHouses()
			=> await _dbContext.Houses.ToListAsync();

	}
}
