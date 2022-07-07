using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;

namespace Playday.GraphQL.Common.Validation
{
	public abstract class ValidationMiddlewareBase<TObject>
	{
		private readonly FieldDelegate _next;

		public ValidationMiddlewareBase(
			FieldDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(IMiddlewareContext context)
		{
			var isSuccess = true;
#pragma warning disable CS0618 // Type or member is obsolete
			var arguments = context.Field.Arguments;
#pragma warning restore CS0618 // Type or member is obsolete
			var validationContext = new ValidationContext(context);
			foreach (var argument in arguments)
			{
				var argumentName = argument.Name;
				var argumentValue = context.ArgumentValue<object>(argumentName);

				if (!(argumentValue is TObject objectToValidate)) continue;
				
				var isValid = await Validate(objectToValidate, validationContext, argumentName);
				if (!isValid) isSuccess = false;
			}

			if (!isSuccess) return;

			await _next(context);
		}

		public abstract Task<bool> Validate(
			TObject objectToValidate,
			IValidationContext context,
			string argumentName);
	}
}
