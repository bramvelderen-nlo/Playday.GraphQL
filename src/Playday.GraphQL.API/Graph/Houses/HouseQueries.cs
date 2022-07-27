using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Houses
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class HouseQueries
	{
		[UseServiceScope]
		public IQueryable<House> GetHouses([Service] HouseService service) =>
			service.GetHouses();
	}
}
