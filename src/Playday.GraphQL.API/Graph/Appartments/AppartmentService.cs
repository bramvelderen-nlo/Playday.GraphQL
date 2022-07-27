using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.Database;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Appartments
{
	public class AppartmentService
	{
		private readonly PlaydayDbContext _dbContext;

		public AppartmentService(PlaydayDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<Appartment>> GetAppartments()
			=> await _dbContext.Appartments.ToListAsync();

	}
}
