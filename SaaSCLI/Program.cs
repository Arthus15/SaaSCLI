using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaaSCLI.Commands.Commands;
using SaaSCLI.Commands.Commands.Import;
using SaaSCLI.Commands.Executor;

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices((_, services) =>
{
	services.AddTransient<ICommand, ImportCommand>();
	services.AddTransient<ICommandExec, CommandExec>();
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
