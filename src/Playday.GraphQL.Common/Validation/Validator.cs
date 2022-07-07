using System.ComponentModel.DataAnnotations;
using SystemValidator = System.ComponentModel.DataAnnotations.Validator;
using SystemValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Playday.GraphQL.Common.Validation
{
	public class Validator
	{
		public (bool isValid, List<ValidationResult>) Validate(object objectToValidate)
		{
			var validationResults = new List<ValidationResult>();
			var objectType = objectToValidate.GetType();
			var metadataAttribute = objectType.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault() as MetadataTypeAttribute;
			var metadataType = metadataAttribute?.MetadataClassType;

			var propertiesToValidate = objectType.GetProperties();

			foreach (var propertyToValidate in propertiesToValidate)
			{
				var allAttributes = new List<object?>();

				var propertyInfo = propertyToValidate;
				var propertyType = propertyToValidate.PropertyType;
				var propertyValue = propertyInfo.GetValue(objectToValidate);
				var attributes = propertyInfo.GetCustomAttributes(true);
				allAttributes.AddRange(attributes);

				if (metadataType != null)
				{
					var metadataPropertyInfo = metadataType.GetProperty(propertyInfo.Name);
					var metaAttributes = metadataPropertyInfo?.GetCustomAttributes(true);
					if (metaAttributes != null) allAttributes.AddRange(metaAttributes);
				}

				var validationAttributes = allAttributes
					.Where(x => x is ValidationAttribute)
					.Cast<ValidationAttribute>()
					.ToList();

				var validationContext = new SystemValidationContext(this, null, null)
				{
					DisplayName = propertyInfo.Name,
					MemberName = propertyInfo.Name,
				};

#pragma warning disable CS8604 // Possible null reference argument. NULL values work just fine here and is needed for required validation. Stop complaining!
				SystemValidator.TryValidateValue(propertyValue, validationContext, validationResults, validationAttributes);
#pragma warning restore CS8604 // Possible null reference argument.
			}

			return (!validationResults.Any(), validationResults);
		}
	}
}
