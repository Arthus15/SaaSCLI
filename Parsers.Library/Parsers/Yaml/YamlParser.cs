using Parsers.Library.Enums;

namespace Parsers.Library.Parsers.Yaml
{
	internal class YamlParser : IParser
	{
		internal const FileType FileType = Enums.FileType.Yaml;
		public bool CanParse(FileType fileType) => FileType == fileType;
		public object Parse(string filePath, Type resultObjectType)
		{
			throw new NotImplementedException();
		}
	}
}
