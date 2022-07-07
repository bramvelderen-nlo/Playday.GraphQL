using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Playday.GraphQL.Common.ExceptionHandling
{
	public static class ExceptionHandlingServiceExtensions
	{
		public static IServiceCollection ConfigureExceptionHandling(
			this IServiceCollection services,
			IRequestExecutorBuilder builder)
		{
			builder.ConfigureSchema(schemaBuilder =>
			{
				schemaBuilder.Use<ExceptionMiddleware>();
			});

			return services;
		}
	}
}
