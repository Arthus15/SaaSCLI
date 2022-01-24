using Microsoft.Extensions.DependencyInjection;
using SystemIO.Library.SystemIOFile;
using SystemIO.Library.SystemIOPath;

namespace SystemIO.Library.IoC
{
	public static class IoC
	{
		public static void RegisterSystemIO(this IServiceCollection services)
		{
			services.AddTransient<ISystemIOFile, SystemIOFile.SystemIOFile>();
			services.AddTransient<ISystemIOPath, SystemIOPath.SystemIOPath>();
			services.AddTransient<ISystemIO, SystemIO>();
		}
	}
}
