using Microsoft.Extensions.DependencyInjection;
using Parsers.Library.Enums;
using SaaSCLI.Commands.Commands.Import;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SaaSCLI.Commands.Commands;

namespace SaaSCLI.Commands.IntegrationTests.Commands.Import
{
	internal partial class ImportTests
	{
		public TestContext Context = new();
		public class TestContext
		{
			private string _path;
			private string _source;
			public ImportCommand BuildSut()
			{
				var testAppHost = new TestProgram().Build();
				var command = testAppHost.Services.GetService<IEnumerable<ICommand>>()!;
				return (command.First(x => x.CanExecute("import")) as ImportCommand)!;
			}

			public string BuildCommand() => $"import {_source} {_path}";

			public TestContext WithFile(FileType fileType)
			{
				_path = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location)!.FullName, "Files", GetFileNameByType());

				return this;
				string GetFileNameByType()
				{
					return fileType switch
					{
						FileType.Json => "softwareadvice.json",
						FileType.Yaml => "capterra.yaml",
						_ => throw new NotImplementedException()
					};
				}
			}

			public TestContext WithSource(string source)
			{
				_source = source;
				return this;
			}
		}
	}
}
