using HotChocolate.Execution.Configuration;

namespace Playday.GraphQL.API.Graph.Scooters
{
	public static class ScooterServiceExtensions
	{
		public static IServiceCollection ConfigureScooters(
			this IServiceCollection services,
			IRequestExecutorBuilder graphQLBuilder)
		{
			graphQLBuilder.AddTypeExtension<ScooterQueries>();
			services.AddTransient<ScooterService>();

			return services;
		}
	}
}
