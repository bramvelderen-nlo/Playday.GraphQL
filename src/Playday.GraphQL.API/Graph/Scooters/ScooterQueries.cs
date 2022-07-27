using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Scooters
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class ScooterQueries
	{
		[UseServiceScope]
		public IQueryable<Scooter> GetScooters([Service] ScooterService service) =>
			service.GetScooters();
	}
}
