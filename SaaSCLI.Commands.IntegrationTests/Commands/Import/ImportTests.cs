using NUnit.Framework;
using Parsers.Library.Enums;

namespace SaaSCLI.Commands.IntegrationTests.Commands.Import
{
	[TestFixture]
	internal partial class ImportTests
	{
		[TestCase(FileType.Json, "SoftwareAdvice")]
		[TestCase(FileType.Yaml, "Capterra")]
		public void TestCommandRun(FileType fileType, string source)
		{
			var service = Context
				.WithFile(fileType)
				.WithSource(source)
				.BuildSut();

			var result = service.Execute(Context.BuildCommand());

			Assert.AreEqual(0, result, $"Something went wrong");
		}
	}
}
