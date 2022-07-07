using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Playday.GraphQL.Common.Validation
{
	public static class ValidationServiceExtensions
	{
		public static IServiceCollection ConfigureValidation(
			this IServiceCollection services,
			IRequestExecutorBuilder builder)
		{
			services.AddTransient<Validator>();
			builder.ConfigureSchema(schemaBuilder =>
			{
				schemaBuilder.Use<DataAnnotationValidationMiddleware>();
			});

			return services;
		}
	}
}
