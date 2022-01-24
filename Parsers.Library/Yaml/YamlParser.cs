namespace Parsers.Library.Yaml
{
	internal class YamlParser : IParser
	{
		internal const string FileType = "Yaml";
		public bool CanParse(string fileType) => FileType.Equals(fileType, StringComparison.CurrentCultureIgnoreCase);
		public object Parse(string filePath, Type resultObjectType)
		{
			throw new NotImplementedException();
		}
	}
}
