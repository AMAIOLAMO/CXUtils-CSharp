using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
	public class BasicPoolObjectFactory<T> : IPoolObjectFactory<T>
	{
		public IPoolObject<T> Create(T obj, IPoolBase<T> pooler) => new PoolObject<T>(obj, pooler);
	}
}
