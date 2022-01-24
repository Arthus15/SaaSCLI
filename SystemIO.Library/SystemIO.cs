using SystemIO.Library.SystemIOFile;
using SystemIO.Library.SystemIOPath;

namespace SystemIO.Library
{
	public class SystemIO : ISystemIO
	{
		public ISystemIOFile File { get; }
		public ISystemIOPath Path { get; }

		public SystemIO(ISystemIOFile file, ISystemIOPath path)
		{
			File = file;
			Path = path;
		}
	}

}
