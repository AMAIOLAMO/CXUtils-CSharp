using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
    public abstract class GridBase<T> : IGridBase<T>
    {
        public GridBase( Float2 cellSize, Float2 origin = default ) => ( Origin, CellSize ) = ( origin, cellSize );

        public Float2 CellSize { get; }
        public Float2 Origin   { get; }

        public float HalfCellX => CellSize.x * .5f;
        public float HalfCellY => CellSize.y * .5f;

        /// <summary>
        ///     The half size of the cell size
        /// </summary>
        public Float2 HalfCellSize => CellSize.Halve;

        public abstract T this[ int x, int y ] { get; set; }
        public abstract T this[ Int2 cell ] { get; set; }

        #region Utilities

        public abstract Float2 CellToGlobal( int x, int y );
        public abstract Float2 CellToGlobal( Int2 cell );

        public abstract Int2 GlobalToCell( float x, float y );
        public abstract Int2 GlobalToCell( Float2 global );

        public abstract Float2 LocalToGlobal( float x, float y );
        public abstract Float2 LocalToGlobal( Float2 local );

        public abstract Float2 GlobalToLocal( float x, float y );
        public abstract Float2 GlobalToLocal( Float2 global );

        public virtual void Swap( int x1, int y1, int x2, int y2 ) =>
            ( this[x1, y1], this[x2, y2] ) = ( this[x2, y2], this[x1, y1] );
        public virtual void Swap( Int2 cell1, Int2 cell2 ) =>
            ( this[cell1], this[cell2] ) = ( this[cell2], this[cell1] );

        public virtual string ToString( int x, int y ) => this[x, y].ToString();
        public virtual string ToString( Int2 cell ) => this[cell.x, cell.y].ToString();

        #endregion
    }
}
