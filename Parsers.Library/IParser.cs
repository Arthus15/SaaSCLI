using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Library.Enums;

namespace Parsers.Library
{
	public interface IParser
	{
		bool CanParse(ParseType fileType);
		object Parse(string objectString, Type resultObjectType);
	}
}
