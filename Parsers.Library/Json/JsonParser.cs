using Newtonsoft.Json;

namespace Parsers.Library.Json
{
	internal class JsonParser : IParser
	{
		public const string FileType = "json";

		public bool CanParse(string fileType) => FileType.Equals(fileType, StringComparison.CurrentCultureIgnoreCase);

		public object Parse(string objectString, Type resultObjectType) =>
		JsonConvert.DeserializeObject(objectString, resultObjectType);
	}
}
