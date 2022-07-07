using HotChocolate.Execution.Configuration;

namespace Playday.GraphQL.API.Graph.Cars
{
	public static class CarServiceExtensions
	{
		public static IServiceCollection ConfigureCars(
			this IServiceCollection services,
			IRequestExecutorBuilder graphQLBuilder)
		{
			graphQLBuilder.AddQueryType<CarQueries>();
			graphQLBuilder.AddMutationType<CarMutations>();
			graphQLBuilder.ConfigureSchema(schemaBuilder =>
			{
				schemaBuilder.Use<CarValidationMiddleware>();
			});

			services.AddTransient<CarService>();

			return services;
		}
	}
}
