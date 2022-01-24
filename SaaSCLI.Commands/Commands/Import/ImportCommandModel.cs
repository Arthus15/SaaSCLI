namespace SaaSCLI.Commands.Commands.Import
{
	internal class ImportCommandModel
	{
		public static string CommnadKey = "import";
		public string Product { get; set; }
		public string FilePath { get; set; }


		public static ImportCommandModel Parse(string command)
		{
			var commandSplited = command.Split(" ")[1..3];

			return new ImportCommandModel()
			{
				Product = commandSplited[0],
				FilePath = commandSplited[1]
			};
		}
	}
}
