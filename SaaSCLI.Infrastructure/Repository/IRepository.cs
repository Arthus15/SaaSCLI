namespace SaaSCLI.Infrastructure.Repository
{
	public interface IRepository<in T> where T : class
	{
		bool Add(T entity);

		//(C)RUD Operations should come next...
	}
}
