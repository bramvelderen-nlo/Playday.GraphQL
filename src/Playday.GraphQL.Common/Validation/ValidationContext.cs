using HotChocolate.Resolvers;

namespace Playday.GraphQL.Common.Validation
{
	public class ValidationContext : IValidationContext
	{
		private readonly IMiddlewareContext _middlewareContext;

		public ValidationContext(IMiddlewareContext middlewareContext)
		{
			_middlewareContext = middlewareContext;
		}

		public void ReportError(IError error)
		{
			_middlewareContext.ReportError(error);
		}

		public void ReportError(string errorMessage)
		{
			_middlewareContext.ReportError(errorMessage);
		}
	}
}
