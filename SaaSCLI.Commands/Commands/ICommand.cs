using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSCLI.Commands.Commands
{
	public interface ICommand
	{
		bool CanExecute(string commandName);
		int Execute(string command);
	}
}
