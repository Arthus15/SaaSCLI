using Newtonsoft.Json;
using Parsers.Library.Enums;

namespace Parsers.Library.Parsers.Json
{
	internal class JsonParser : IParser
	{
		public const ParseType FileType = ParseType.Json;

		public bool CanParse(ParseType fileType) => FileType == fileType;

		public object Parse(string objectString, Type resultObjectType) =>
		JsonConvert.DeserializeObject(objectString, resultObjectType);
	}
}
