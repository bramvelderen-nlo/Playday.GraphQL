using System.ComponentModel.DataAnnotations;

namespace Playday.GraphQL.API.Graph.Cars
{
	public class CarMetadata
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[MinLength(5)]
		public string? Name { get; set; }
		[Required]
		public string? Brand { get; set; }
		[RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{2}")]
		public string? LicensePlate { get; set; }
	}
}
