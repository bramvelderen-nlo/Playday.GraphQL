using HotChocolate.Resolvers;
using Playday.GraphQL.API.Graph.Cars.Inputs;
using Playday.GraphQL.Common.Validation;

namespace Playday.GraphQL.API.Graph.Cars
{
	public class CarValidationMiddleware : ValidationMiddlewareBase<ICarInput>
	{
		public CarValidationMiddleware(FieldDelegate next) : base(next)
		{

		}

		public override Task<bool> Validate(ICarInput car, IValidationContext context, string argumentName)
		{
			if (car.Name != "111.111")
			{
				context.ReportError("Car name must be '111.111'");
				return Task.FromResult(false);
			}


			return Task.FromResult(true);
		}
	}
}
