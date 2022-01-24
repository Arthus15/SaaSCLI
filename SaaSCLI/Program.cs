using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parsers.Library.IoC;
using SaaSCLI.Commands.Commands;
using SaaSCLI.Commands.Commands.Import;
using SaaSCLI.Commands.Executor;
using SaaSCLI.Infrastructure.MySQL.IoC;
using SystemIO.Library.IoC;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices((_, services) =>
{
	services.AddTransient<ICommand, ImportCommand>();
	services.AddTransient<ICommandExec, CommandExec>();
	services.RegisterSystemIO();
	services.RegisterParsers();
	services.RegisterMySQLRepos();
});

var host = builder.Build();
var executor = host.Services.GetService<ICommandExec>();

Console.WriteLine("***SaasCli***");


Console.WriteLine("Write command (exit to end the execution): \n");

while (true)
{
	var commmand = Console.ReadLine();

	if (commmand == "exit") break;

	executor!.Run(commmand!);
}
