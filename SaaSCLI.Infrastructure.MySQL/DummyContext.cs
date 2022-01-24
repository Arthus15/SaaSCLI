using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.MySQL.Repository;
using SaaSCLI.Infrastructure.Repository;

namespace SaaSCLI.Infrastructure.MySQL
{
	public class DummyContext: IDummyContext
	{
		public IRepository<FeedProduct> FeedProductRepo { get; } = new FeedProductRepository();
	}
}
