using Microsoft.Extensions.DependencyInjection;
using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.MySQL.Repository;
using SaaSCLI.Infrastructure.Repository;

namespace SaaSCLI.Infrastructure.MySQL.IoC
{
	public static class IoC
	{
		public static void RegisterMySQLRepos(this IServiceCollection services)
		{
			services.AddTransient<DummyContext>();
			services.AddTransient<IRepository<FeedProduct>, FeedProductRepository>();
		}
	}
}
