using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
	public interface INullableGrid2<T> : IGrid2<T>
	{
		public bool TryGetValue(in Int2 cell, out T value);
		public bool TryGetValue(int x, int y, out T value);
	}
}
