using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIO.Library.SystemIOFile
{
	internal class SystemIOFile: ISystemIOFile
	{
		public string ReadAllText(string filePath)
		{
			return File.ReadAllText(filePath);
		}
	}
}
