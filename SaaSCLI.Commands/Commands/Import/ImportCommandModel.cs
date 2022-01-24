namespace SaaSCLI.Commands.Commands.Import
{
	internal class ImportCommandModel
	{
		public static string CommnadKey = "import";
		public string Product { get; set; }
		public string FilePath { get; set; }


		public static ImportCommandModel Parse(string command)
		{
			var commandSplited = command.Split(" ");

			if (commandSplited.Length is < 3)
				throw new ArgumentException("Missing parameters in command");

			return new ImportCommandModel()
			{
				Product = commandSplited[2],
				FilePath = commandSplited[3]
			};
		}
	}
}
