using Parsers.Library.Global;
using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.MySQL;

namespace SaaSCLI.Commands.Commands.Import
{
	public class ImportCommand : ICommand
	{
		private readonly IGlobalParser _parser;
		private readonly IDummyContext _context;
		public ImportCommand(IGlobalParser parser, IDummyContext context)
		{
			_parser = parser;
			_context = context;
		}

		public bool CanExecute(string commandName) =>
			commandName.Equals(ImportCommandModel.CommnadKey, StringComparison.CurrentCultureIgnoreCase);

		public int Execute(string command)
		{
			var importCommand = ImportCommandModel.Parse(command);
			Validate();

			if (!_parser.TryParse(importCommand.FilePath, typeof(FeedProduct), out object result))
				return 1;

			_context.FeedProductRepo.Add((result as FeedProduct)!);

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
