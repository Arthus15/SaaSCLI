using Newtonsoft.Json;
using SaaSCLI.Infrastructure.Entities;
using SaaSCLI.Infrastructure.Repository;

namespace SaaSCLI.Infrastructure.MySQL.Repository
{
	public class FeedProductRepository : IRepository<FeedProduct>
	{
		public bool Add(FeedProduct entity)
		{
			Console.WriteLine($"importing:  {JsonConvert.SerializeObject(entity)}"); //Adding Json just for serialization
			return true;
		}
	}
}
