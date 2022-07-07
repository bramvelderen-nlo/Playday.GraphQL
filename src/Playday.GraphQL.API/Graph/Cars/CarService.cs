using Playday.GraphQL.API.Graph.Cars.Inputs;
using Playday.GraphQL.API.Graph.Cars.Payloads;
using Playday.GraphQL.Common.ExceptionHandling;
using Playday.GraphQL.Database;
using Playday.GraphQL.Database.Models;

namespace Playday.GraphQL.API.Graph.Cars
{
	public class CarService
	{
		private readonly PlaydayDbContext _dbContext;

		public CarService(PlaydayDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<CarCreatePayload> CreateCar(CarCreateInput input)
		{
			var car = new Car
			{
				Name = input.Name,
				Brand = input.Brand,
				LicensePlate = input.LicensePlate
			};

			if (car.Brand == "BMW")
			{
				throw new FunctionalException("Foutje");
			}

			_dbContext.Add(car);
			await _dbContext.SaveChangesAsync();

			return new CarCreatePayload
			{
				Id = car.Id
			};
		}


	}
}
