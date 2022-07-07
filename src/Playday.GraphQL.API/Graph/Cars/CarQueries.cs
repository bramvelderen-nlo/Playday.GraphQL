using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Cars
{
	public class CarQueries
	{
		public Car GetCar() =>
			new Car
			{
				Id = Guid.NewGuid(),
				Brand = "BMW",
				LicensePlate = "22-33-44",
				Name = "A1"
			};
	}
}
