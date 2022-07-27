using Playday.GraphQL.API.Graph.Cars.Inputs;
using Playday.GraphQL.API.Graph.Cars.Payloads;
using Playday.GraphQL.Database;

namespace Playday.GraphQL.API.Graph.Cars
{
	[ExtendObjectType(OperationTypeNames.Mutation)]
	public class CarMutations
	{
		[UseServiceScope]
		public async Task<CarCreatePayload> CreateCar([Service] CarService carService, CarCreateInput input)
			=> await carService.CreateCar(input);
	}
}
