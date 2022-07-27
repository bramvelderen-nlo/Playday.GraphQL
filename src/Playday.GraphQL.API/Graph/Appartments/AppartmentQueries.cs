using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Appartments
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class AppartmentQueries
	{
		[UseServiceScope]
		public async Task<List<Appartment>> GetAppartments([Service] AppartmentService service) =>
			await service.GetAppartments();
	}
}
