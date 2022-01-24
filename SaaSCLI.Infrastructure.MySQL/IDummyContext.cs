using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.Repository;

namespace SaaSCLI.Infrastructure.MySQL
{
	public interface IDummyContext
	{
		public IRepository<FeedProduct> FeedProductRepo { get; }
	}
}
