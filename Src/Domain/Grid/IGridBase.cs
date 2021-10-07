using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
    public interface IGridBase<T>
    {
        T this[ int x, int y ] { get; set; }
        T this[ Int2 cellPosition ] { get; set; }
        
        Float2 CellToWorld( int x, int y );
        Float2 CellToWorld( Int2 cellPosition );
        Int2 WorldToCell( float x, float y );
        Int2 WorldToCell( Float2 worldPosition );
        Float2 LocalToWorld( float x, float y );
        Float2 LocalToWorld( Float2 localPosition );
        Float2 WorldToLocal( float x, float y );
        Float2 WorldToLocal( Float2 worldPosition );
        
        void Swap( int x1, int y1, int x2, int y2 );
        void Swap( Int2 cell1, Int2 cell2 );
        
        string ToString( int x, int y );
        string ToString( Int2 cellPosition );
    }
}
