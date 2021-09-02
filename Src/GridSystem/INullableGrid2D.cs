using CXUtils.Types;

namespace CXUtils.Grid
{
    public interface INullableGrid2D<T>
    {
        public bool TryGetValue( Int2 cellPosition, out T value );
        public bool TryGetValue( int x, int y, out T value );
    }
}
