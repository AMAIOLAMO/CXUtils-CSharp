using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
    public interface INullableGrid2D<T> : IGridBase<T>
    {
        public bool TryGetValue( Int2 cellPosition, out T value );
        public bool TryGetValue( int x, int y, out T value );
    }
}
