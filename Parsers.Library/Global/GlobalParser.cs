using System.Text.Json.Nodes;
using Parsers.Library.Enums.Extensions;
using SystemIO.Library;

namespace Parsers.Library.Global
{
	public class GlobalParser : IGlobalParser
	{
		private readonly IEnumerable<IParser> _parsers;
		private readonly ISystemIO _systemIo;
		public GlobalParser(IEnumerable<IParser> parsers, ISystemIO systemIo)
		{
			_parsers = parsers;
			_systemIo = systemIo;
		}

		public bool TryParse(string filePath, Type resultObjectType, out object result, Func<string, string> formatFunc = null)
		{
			try
			{
				var type = ParseTypeExtensions.FromFileName(filePath);
				var fileText = _systemIo.File.ReadAllText(filePath);

				if (formatFunc is not null)
					fileText = formatFunc(fileText);

				var parser = _parsers.First(x => x.CanParse(type));

				result = parser.Parse(fileText, resultObjectType);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Could not parse the file - inner ex: {ex.Message}");
				result = null;
				return false;
			}
		}
	}
}
