using Playday.GraphQL.API.Graph.Cars;
using Playday.GraphQL.API.Graph.Cars.Inputs;
using Playday.GraphQL.API.Tests;

namespace Playday.GraphQL.Logic.Tests.Cars
{
	[TestClass]
	public class CarValidationMiddlewareTests : TestClassBase
	{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		private readonly CarValidationMiddleware _target = new(default);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

		[TestMethod]
		public async Task ValidateShouldFailWhenNameIsNotHallo()
		{
			var car = new CarCreateInput
			{
				Brand = "BMW",
				LicensePlate = "Plate",
				Name = "TestName"
			};
			var result = await _target.Validate(car, ValidationContext, "Test");

			Assert.IsTrue(ValidationContext.ErrorMessages.Any());
			Assert.IsFalse(result);
		}

		[TestMethod]
		public async Task ValidateShouldSucceedWhenNameIsHallo()
		{
			var car = new CarCreateInput
			{
				Brand = "BMW",
				LicensePlate = "Plate",
				Name = "111.111"
			};
			var result = await _target.Validate(car, ValidationContext, "Test");

			Assert.IsFalse(ValidationContext.ErrorMessages.Any());
			Assert.IsTrue(result);
		}
	}
}
