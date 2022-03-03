using System;
using System.Collections.Concurrent;
using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
	/// <summary>
	///     A basic pooling class <br />
	///     Note: this pool doesn't really care if you freed the wrong item
	/// </summary>
	public abstract class PoolBase<T> : IPool<T>
	{
		protected PoolBase() => data = new ConcurrentBag<T>();
		protected PoolBase(int count) : this() => Populate(count);
		
		public int Count => data.Count;

		public T Pop() => data.TryTake(out T item) ? item : Create();

		public IPoolItem PopScope(out T item) =>
			new PoolItem<T>(item = Pop(), this);

		public void Free(T item) =>
			data.Add(Release(item));

		readonly ConcurrentBag<T> data;

		protected abstract T Create();

		protected abstract T Release(T item);

		protected void Populate(int amount)
		{
			for (int i = 0; i < amount; ++i)
				data.Add(Create());
		}
	}
}
