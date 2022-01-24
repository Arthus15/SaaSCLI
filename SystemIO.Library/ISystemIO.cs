using SystemIO.Library.SystemIOFile;
using SystemIO.Library.SystemIOPath;

namespace SystemIO.Library
{
	public interface ISystemIO
	{
		ISystemIOFile File { get; }
		ISystemIOPath Path { get; }
	}
}
