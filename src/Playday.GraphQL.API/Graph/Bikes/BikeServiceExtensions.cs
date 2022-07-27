using HotChocolate.Execution.Configuration;

namespace Playday.GraphQL.API.Graph.Bikes
{
	public static class BikeServiceExtensions
	{
		public static IServiceCollection ConfigureBikes(
			this IServiceCollection services,
			IRequestExecutorBuilder graphQLBuilder)
		{
			graphQLBuilder.AddTypeExtension<BikeQueries>();
			services.AddTransient<BikeService>();

			return services;
		}
	}
}
