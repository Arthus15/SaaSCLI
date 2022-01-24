using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaaSCLI.Commands.Commands.Import;

namespace SaaSCLI.Commands.UnitTests.Commands.Import
{
	internal partial class ImportCommandTests
	{
		public TestContext Context = new();
		public class TestContext
		{
			public ImportCommand BuildSut()
			{
				return new ImportCommand();
			}
		}
	}
}
