using HotChocolate;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Cars
{
	[ExtendObjectType(OperationTypeNames.Query)]
	public class CarQueries
	{
		[UseServiceScope]
		public async Task<List<Car>> GetCars([Service] CarService service) =>
			await service.GetCars();
	}
}
