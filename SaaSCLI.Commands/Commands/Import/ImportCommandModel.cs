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

			var path = commandSplited[2..commandSplited.Length];


			return new ImportCommandModel()
			{
				Product = commandSplited[1],
				FilePath = string.Join(' ',path)
			};
		}
	}
}
