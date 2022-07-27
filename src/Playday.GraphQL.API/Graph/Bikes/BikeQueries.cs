using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Bikes
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class BikeQueries
	{
		[UseServiceScope]
		public async Task<List<Bike>> GetBikes([Service] BikeService service) =>
			await service.GetBikes();
	}
}
