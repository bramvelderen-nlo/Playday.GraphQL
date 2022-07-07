using System.ComponentModel.DataAnnotations;

namespace Playday.GraphQL.API.Graph.Cars.Inputs
{
	[MetadataType(typeof(CarMetadata))]
	public class CarUpdateInput : ICarInput
	{
		public Guid? Id { get; set; }
		public string? Name { get; set; }
		public string? Brand { get; set; }
		public string? LicensePlate { get; set; }
	}
}
