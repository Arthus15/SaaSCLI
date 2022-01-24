namespace Parsers.Library.Enums.Extensions
{
	public static class ParseTypeExtensions
	{
		public static FileType FromFileName(string fileName)
		{
			var extension = fileName.Split(".").Last();

			return extension.ToLower() switch
			{
				"json" => FileType.Json,
				"yaml" => FileType.Yaml,
				_ => throw new NotSupportedException($"Extension {extension} not supported")
			};
		}
	}
}
