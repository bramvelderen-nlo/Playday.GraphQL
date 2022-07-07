using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playday.GraphQL.Database.Models
{
	[Table("Cars")]
	public class Car
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Brand { get; set; }
		[Required]
		public string? LicensePlate { get; set; }
	}
}
