using HotChocolate.Execution.Configuration;

namespace Playday.GraphQL.API.Graph.Houses
{
	public static class HouseServiceExtensions
	{
		public static IServiceCollection ConfigureHouses(
			this IServiceCollection services,
			IRequestExecutorBuilder graphQLBuilder)
		{
			graphQLBuilder.AddTypeExtension<HouseQueries>();
			services.AddTransient<HouseService>();

			return services;
		}
	}
}
