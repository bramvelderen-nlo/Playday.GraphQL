namespace Playday.GraphQL.Common.Validation
{
	public interface IValidationContext
	{
		void ReportError(string errorMessage);
		void ReportError(IError error);
	}
}
