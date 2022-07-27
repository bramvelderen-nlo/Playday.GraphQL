using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Scooters
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class ScooterQueries
	{
		[UseServiceScope]
		public async Task<List<Scooter>> GetScooters([Service] ScooterService service) =>
			await service.GetScooters();
	}
}
