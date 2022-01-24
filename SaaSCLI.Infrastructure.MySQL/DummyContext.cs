using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.MySQL.Repository;
using SaaSCLI.Infrastructure.Repository;

namespace SaaSCLI.Infrastructure.MySQL
{
	public class DummyContext
	{
		private readonly IRepository<FeedProduct> _feedProductRepo = new FeedProductRepository();
	}
}
