using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playday.GraphQL.Common.ExceptionHandling
{
	public class FunctionalException : Exception
	{
		public FunctionalException(string message) : base(message)
		{

		}
	}
}
