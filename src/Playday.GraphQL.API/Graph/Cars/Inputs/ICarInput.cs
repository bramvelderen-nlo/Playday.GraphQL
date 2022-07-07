namespace Playday.GraphQL.API.Graph.Cars.Inputs
{
	public interface ICarInput
	{
		string? Brand { get; set; }
		string? LicensePlate { get; set; }
		string? Name { get; set; }
	}
}