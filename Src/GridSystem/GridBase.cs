using CXUtils.Types;

namespace CXUtils.Grid
{
    public abstract class GridBase<T>
    {
        public GridBase( Float2 cellSize, Float2 origin = default ) => ( Origin, CellSize ) = ( origin, cellSize );

        public Float2 CellSize { get; }
        public Float2 Origin   { get; }

        public abstract T this[ int x, int y ] { get; set; }
        public abstract T this[ Int2 cellPosition ] { get; set; }

        public float HalfCellX => CellSize.x * .5f;
        public float HalfCellY => CellSize.y * .5f;

        /// <summary>
        ///     The half size of the cell size
        /// </summary>
        public Float2 HalfCellSize => CellSize.Halve;

        #region Utilities

        public abstract Float2 CellToWorld( int x, int y );
        public abstract Float2 CellToWorld( Int2 cellPosition );

        public abstract Int2 WorldToCell( float x, float y );
        public abstract Int2 WorldToCell( Float2 worldPosition );

        public abstract Float2 LocalToWorld( float x, float y );
        public abstract Float2 LocalToWorld( Float2 localPosition );

        public abstract Float2 WorldToLocal( float x, float y );
        public abstract Float2 WorldToLocal( Float2 worldPosition );

        public virtual void Swap( int x1, int y1, int x2, int y2 )
        {
            ( this[x1, y1], this[x2, y2] ) = ( this[x2, y2], this[x1, y1] );
        }
        public virtual void Swap( Int2 cell1, Int2 cell2 )
        {
            ( this[cell1], this[cell2] ) = ( this[cell2], this[cell1] );
        }

        public virtual string ToString( int x, int y ) => this[x, y].ToString();
        public virtual string ToString( Int2 cellPosition ) => this[cellPosition.x, cellPosition.y].ToString();

        #endregion
    }
}
