using Newtonsoft.Json;
using Parsers.Library.Enums;

namespace Parsers.Library.Parsers.Json
{
	internal class JsonParser : IParser
	{
		public const FileType FileType = Enums.FileType.Json;

		public bool CanParse(FileType fileType) => FileType == fileType;

		public object Parse(string objectString, Type resultObjectType) =>
		JsonConvert.DeserializeObject(objectString, resultObjectType);
	}
}
