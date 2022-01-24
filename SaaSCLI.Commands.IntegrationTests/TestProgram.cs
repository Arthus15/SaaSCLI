using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parsers.Library.IoC;
using SaaSCLI.Commands.Commands;
using SaaSCLI.Commands.Commands.Import;
using SaaSCLI.Commands.Executor;
using SaaSCLI.Infrastructure.MySQL.IoC;
using SystemIO.Library.IoC;

namespace SaaSCLI.Commands.IntegrationTests
{
	internal class TestProgram
	{
		private readonly IHostBuilder _host;
		public TestProgram()
		{
			_host = Host.CreateDefaultBuilder();
			_host.ConfigureServices((_, services) =>
			{
				services.AddTransient<ICommand, ImportCommand>();
				services.AddTransient<ICommandExec, CommandExec>();
				services.RegisterSystemIO();
				services.RegisterParsers();
				services.RegisterMySQLRepos();
			});
		}

		public IHost Build()
		{
			return _host.Build();
		}
	}
}
