using HotChocolate.Resolvers;

namespace Playday.GraphQL.Common.Validation
{
	internal class DataAnnotationValidationMiddleware : ValidationMiddlewareBase<object>
	{
		private readonly Validator _validator;

		public DataAnnotationValidationMiddleware(
			FieldDelegate next,
			Validator validator) : base(next)
		{
			_validator = validator;
		}

		public override Task<bool> Validate(
			object objectToValidate,
			IValidationContext context,
			string argumentName)
		{
			(var isValid, var validationResults) = _validator.Validate(objectToValidate);

			foreach (var validationResult in validationResults)
			{
				if (validationResult == null) continue;

				var field = validationResult.MemberNames.First();

				var rootPath = HotChocolate.Path.New(argumentName);
				rootPath.Append(field);

				context.ReportError(ErrorBuilder.New()
					.SetMessage(validationResult.ErrorMessage ?? "An unkown error has occured")
					.SetExtension("field", char.ToLowerInvariant(field[0]) + field.Substring(1))
					.SetPath(rootPath)
					.Build());
			}

			return Task.FromResult(isValid);
		}
	}
}
