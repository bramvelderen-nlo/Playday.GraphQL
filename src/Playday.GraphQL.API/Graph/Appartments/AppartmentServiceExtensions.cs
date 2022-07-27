using HotChocolate.Execution.Configuration;

namespace Playday.GraphQL.API.Graph.Appartments
{
	public static class AppartmentServiceExtensions
	{
		public static IServiceCollection ConfigureAppartments(
			this IServiceCollection services,
			IRequestExecutorBuilder graphQLBuilder)
		{
			graphQLBuilder.AddTypeExtension<AppartmentQueries>();
			services.AddTransient<AppartmentService>();

			return services;
		}
	}
}
