using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace Playday.GraphQL.Common.ExceptionHandling
{
	internal class ExceptionMiddleware
	{
		private readonly FieldDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(
			FieldDelegate next,
			ILoggerFactory loggerFactory)
		{
			_next = next;
			_logger = loggerFactory.CreateLogger<ExceptionMiddleware>();

		}

		public async Task InvokeAsync(IMiddlewareContext context)
		{
			try
			{
				await _next(context);
			}
			catch (FunctionalException e)
			{
				context.ReportError(e.Message);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "An unexpected exception occured");
				throw;
			}
		}
	}
}
