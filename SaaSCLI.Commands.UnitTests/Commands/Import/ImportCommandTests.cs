using NUnit.Framework;
using System;

namespace SaaSCLI.Commands.UnitTests.Commands.Import
{
	[TestFixture]
	internal partial class ImportCommandTests
	{
		[TestCase("import test correct/path")]
		public void Execute_WhenCorrectFormatCommand_NoErrors(string command)
		{
			var importCommand = Context.BuildSut();

			importCommand.Execute(command);

			Assert.True(true);
		}

		[TestCase("", typeof(ArgumentException))]
		[TestCase(" ", typeof(ArgumentException))]
		[TestCase("import", typeof(ArgumentException))]
		public void Execute_WhenIncorrectFormatCommand_ThrowArgumentException(string command, Type exception)
		{
			var importCommand = Context.BuildSut();

			Assert.Throws(exception,() => importCommand.Execute(command));
		}

		[TestCase("import", true)]
		[TestCase("IMPORT", true)]
		[TestCase("Impor", false)]
		public void CanExecute_Works(string commandKey, bool shouldExecute)
		{
			var importCommand = Context.BuildSut();

			var result = importCommand.CanExecute(commandKey);

			Assert.AreEqual(shouldExecute, result, $"{commandKey} should have returned {shouldExecute}");

		}
	}
}
