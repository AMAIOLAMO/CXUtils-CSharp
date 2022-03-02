namespace CXUtils.Domain
{
	public interface IPool<T>
	{
		int Count { get; }

		T Pop();
		IPoolItem PopScope(out T item);
		
		void Free( T item );
	}
}
