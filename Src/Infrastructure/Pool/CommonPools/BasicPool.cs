using System;

namespace CXUtils.Infrastructure
{
	public class BasicPool<T> : PoolBase<T>
	{
		public BasicPool(int count, Func<T> createFunc, Func<T, T> releaseFunc) : base(count)
		{
			this.createFunc = createFunc;
			this.releaseFunc = releaseFunc;
		}

		public BasicPool(int count, Func<T> createFunc) :
			this(count, createFunc, defaultReleaseFactory)
		{
		}

		readonly Func<T>    createFunc;
		readonly Func<T, T> releaseFunc;
		
		static readonly Func<T, T> defaultReleaseFactory = item => item;

		protected override T Create() => createFunc();
		protected override T Release(T item) => releaseFunc(item);
	}
}
