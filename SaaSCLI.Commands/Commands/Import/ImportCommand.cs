using Parsers.Library.Global;

namespace SaaSCLI.Commands.Commands.Import
{
	public class ImportCommand : ICommand
	{
		private readonly IGlobalParser _parser;
		public ImportCommand(IGlobalParser parser)
		{
			_parser = parser;
		}

		public bool CanExecute(string commandName) =>
			commandName.Equals(ImportCommandModel.CommnadKey, StringComparison.CurrentCultureIgnoreCase);

		public int Execute(string command)
		{
			var importCommand = ImportCommandModel.Parse(command);
			Validate();

			if (!_parser.TryParse(importCommand.FilePath, typeof(ImportCommandModel), out object result))
				return 1;

			return 0;

			void Validate()
			{
				if (string.IsNullOrWhiteSpace(importCommand.Product))
					throw new ArgumentNullException(nameof(importCommand.Product));

				if (string.IsNullOrWhiteSpace(importCommand.FilePath))
					throw new ArgumentNullException(nameof(importCommand.FilePath));
			}
		}
	}
}
