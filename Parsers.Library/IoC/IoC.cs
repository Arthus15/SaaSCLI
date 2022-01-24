using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Parsers.Library.Json;
using Parsers.Library.Yaml;

namespace Parsers.Library.IoC
{
	public static class IoC
	{
		public static void RegisterParsers(this IServiceCollection services)
		{
			services.AddTransient<IParser, JsonParser>();
			services.AddTransient<IParser, YamlParser>();
		}
	}
}
