namespace Parsers.Library.Enums.Extensions
{
	public static class ParseTypeExtensions
	{
		public static ParseType FromFileName(string fileName)
		{
			var extension = fileName.Split(".").Last();

			return extension.ToLower() switch
			{
				"json" => ParseType.Json,
				"yaml" => ParseType.Yaml,
				_ => throw new NotSupportedException($"Extension {extension} not supported")
			};
		}
	}
}
