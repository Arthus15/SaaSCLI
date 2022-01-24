using Microsoft.Extensions.DependencyInjection;
using Parsers.Library.Global;
using Parsers.Library.Parsers.Json;
using Parsers.Library.Parsers.Yaml;

namespace Parsers.Library.IoC
{
	public static class IoC
	{
		public static void RegisterParsers(this IServiceCollection services)
		{
			services.AddTransient<IParser, JsonParser>();
			services.AddTransient<IParser, YamlParser>();
			services.AddTransient<IGlobalParser, GlobalParser>();
		}
	}
}
