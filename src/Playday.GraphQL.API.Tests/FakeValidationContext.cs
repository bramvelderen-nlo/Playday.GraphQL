using HotChocolate;
using Playday.GraphQL.Common.Validation;

namespace Playday.GraphQL.API.Tests
{
	public class FakeValidationContext : IValidationContext
	{
		public List<string> ErrorMessages = new List<string>();

		public void ReportError(string errorMessage)
		{
			ErrorMessages.Add(errorMessage);
		}

		public void ReportError(IError error)
		{
			ErrorMessages.Add(error.Message);
		}
	}

}
