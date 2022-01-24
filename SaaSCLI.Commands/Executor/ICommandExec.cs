using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSCLI.Commands.Executor
{
	public interface ICommandExec
	{
		void Run(string command);
	}
}
