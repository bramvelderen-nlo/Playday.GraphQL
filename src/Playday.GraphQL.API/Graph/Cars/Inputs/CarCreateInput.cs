using System.ComponentModel.DataAnnotations;
using Playday.GraphQL.API.Graph.Cars;

namespace Playday.GraphQL.API.Graph.Cars.Inputs
{
	[MetadataType(typeof(CarMetadata))]
	public class CarCreateInput : ICarInput
	{
		public string? Name { get; set; }
		public string? Brand { get; set; }
		public string? LicensePlate { get; set; }
	}


}
