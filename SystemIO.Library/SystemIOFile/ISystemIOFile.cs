using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIO.Library.SystemIOFile
{
	public interface ISystemIOFile
	{
		string ReadAllText(string filePath);
	}
}
