using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Parsers.Library.Enums;
using SharpYaml.Serialization;

namespace Parsers.Library.Parsers.Yaml
{
	internal class YamlParser : IParser
	{
		internal const FileType FileType = Enums.FileType.Yaml;
		public bool CanParse(FileType fileType) => FileType == fileType;
		public object Parse(string objectString, Type resultObjectType)
		{
			var yamlSerialize = new Serializer();

			var result = yamlSerialize.Deserialize(objectString);
			CleanArrays();

			var value = JsonConvert.SerializeObject(result);
			value = value.Replace("\\", "").Replace("\"\"", "\"").Replace("]\"", "]").Replace("\"[", "[");
			return JsonConvert.DeserializeObject(value, resultObjectType);

			void CleanArrays()
			{
				foreach (var line in result as List<object>)
				{
					var lineDict = (line as Dictionary<object, object>)!;

					foreach (var key in lineDict.Keys)
					{
						var dicValue = lineDict[key] as string;

						var splitList= dicValue.Split(",");

						if(splitList.Length == 1) continue;
						var parseResult = "[";

						foreach (var listValue in splitList)
						{
							parseResult += $"\"{listValue}\",";
						}

						parseResult = parseResult.Remove(parseResult.Length-1);
						parseResult += "]";

						lineDict[key] = parseResult;
					}
				}
			}
		}
	}
}
