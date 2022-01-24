using Parsers.Library.Enums;

namespace Parsers.Library.Parsers.Yaml
{
	internal class YamlParser : IParser
	{
		internal const ParseType FileType = ParseType.Yaml;
		public bool CanParse(ParseType fileType) => FileType == fileType;
		public object Parse(string filePath, Type resultObjectType)
		{
			throw new NotImplementedException();
		}
	}
}
