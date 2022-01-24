namespace Parsers.Library.Global
{
	public interface IGlobalParser
	{
		bool TryParse(string fileName, Type resultObjectType, out object result, Func<string, string> formatFunc = null);
	}
}
