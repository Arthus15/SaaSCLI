using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers.Library
{
	internal interface IParser
	{
		bool CanParse(string fileType);
		object Parse(string objectString, Type resultObjectType);
	}
}
