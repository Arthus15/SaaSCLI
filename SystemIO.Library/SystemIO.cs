using SystemIO.Library.SystemIOFile;
using SystemIO.Library.SystemIOPath;

namespace SystemIO.Library
{
	public class SystemIO : ISystemIO
	{
		public readonly ISystemIOFile _file;
		public readonly ISystemIOPath _path;

		public SystemIO(ISystemIOFile file, ISystemIOPath path)
		{
			_file = file;
			_path = path;
		}
	}

}
