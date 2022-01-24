using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSCLI.Commands.Commands.Import
{
	public class ImportCommand : ICommand
	{
		public bool CanExecute(string commandName) =>
			commandName.Equals(ImportCommandModel.CommnadKey, StringComparison.CurrentCultureIgnoreCase);

		public void Execute(string command)
		{
			var importCommand = ImportCommandModel.Parse(command);
			Validate();

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
