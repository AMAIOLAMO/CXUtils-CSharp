namespace CXUtils.Domain
{
	public interface IPool<T>
	{
		T Pop();
		IPoolItem PopScope(out T item);

		void Free(T item);

		int Count { get; }
	}
}
