using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Houses
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class HouseQueries
	{
		[UseServiceScope]
		public async Task<List<House>> GetHouses([Service] HouseService service) =>
			await service.GetHouses();
	}
}
