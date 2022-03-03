using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
	/// <summary>
	///     A wrapper around the pooled object so that it could be automatically disposed
	/// </summary>
	public sealed class PoolItem<T> : IPoolItem
	{
		public PoolItem(T value, IPool<T> root)
		{
			this.value = value;
			this.root = root;
		}

		public void Dispose() => root.Free(value);

		readonly IPool<T> root;

		readonly T value;
	}
}
