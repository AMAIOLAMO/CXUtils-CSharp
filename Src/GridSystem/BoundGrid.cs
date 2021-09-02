using System;
using System.Collections.Generic;
using CXUtils.Types;

namespace CXUtils.Grid
{
    /// <summary>
    ///     A 2D Limited size / bounded grid system
    /// </summary>
    /// <typeparam name="T">The type that each cell stores</typeparam>
    public class BoundGrid<T> : UnSpacedGridBase<T>, INullableGrid2D<T>
    {
        #region Utilities

        public IEnumerable<LineFloat2> GetGridLines()
        {
            var lines = new List<LineFloat2>();

            for ( int y = 0; y < Height + 1; ++y )
                lines.Add( new LineFloat2( new Float2( Origin.x, Origin.y + y * CellSize.y ),
                    new Float2( Origin.x + Width * CellSize.x, Origin.y + y * CellSize.y ) ) );

            for ( int x = 0; x < Width + 1; ++x )
                lines.Add( new LineFloat2( new Float2( Origin.x + x * CellSize.x, Origin.y ),
                    new Float2( Origin.x + x * CellSize.x, Origin.y + Height * CellSize.y ) ) );

            return lines;
        }

        #endregion

        #region Fields

        readonly T[,] _gridArray;
        public   int  Width  { get; }
        public   int  Height { get; }

        public override T this[ int x, int y ]
        {
            get => _gridArray[x, y];
            set => _gridArray[x, y] = value;
        }

        public override T this[ Int2 cellPosition ]
        {
            get => _gridArray[cellPosition.x, cellPosition.y];
            set => _gridArray[cellPosition.x, cellPosition.y] = value;
        }


        /// <summary>
        ///     The total cell count
        /// </summary>
        public int CellCount => Width * Height;

        /// <summary>
        ///     The whole <see cref="BoundGrid{T}" />'s size
        /// </summary>
        public Int2 GridSize => new( Width, Height );

        #endregion

        #region Constructors

        public BoundGrid( int width, int height, Float2 cellSize, Float2 origin = default ) : base( cellSize, origin )
        {
            ( Width, Height ) = ( width, height );
            _gridArray = new T[Width, Height];
        }

        public BoundGrid( Int2 gridSize, Float2 cellSize, Float2 origin = default ) : base( cellSize, origin )
        {
            ( Width, Height ) = ( gridSize.x, gridSize.y );
            _gridArray = new T[Width, Height];
        }

        #endregion

        #region Values

        #region SetValues

        /// <summary>
        ///     Tries to set a value using grid position <br />
        ///     Returns if sets correctly
        /// </summary>
        public bool TrySetValue( int x, int y, T value )
        {
            if ( !CellValid( x, y ) )
                return false;

            _gridArray[x, y] = value;
            return true;
        }

        /// <summary>
        ///     Tries to set a value using grid position <br />
        ///     Returns if sets correctly
        /// </summary>
        public bool TrySetValue( Int2 cellPosition, T value ) => TrySetValue( cellPosition.x, cellPosition.y, value );

        #endregion

        #region GetValues

        /// <summary>
        ///     Gets the value using grid position <br />
        ///     Returns if the grid position is valid
        /// </summary>
        public bool TryGetValue( int x, int y, out T value )
        {
            if ( CellValid( x, y ) )
            {
                value = _gridArray[x, y];
                return true;
            }
            value = default;
            return false;
        }
        public bool CellValid( int x, int y ) => x >= 0 && y >= 0 && x < Width && y < Height;
        public bool CellValid( Int2 cellPosition ) => cellPosition.x >= 0 && cellPosition.y >= 0 && cellPosition.x < Width && cellPosition.y < Height;

        /// <summary>
        ///     Gets the value using grid position <br />
        ///     Returns if the grid position is valid
        /// </summary>
        public bool TryGetValue( Int2 cellPosition, out T value ) => TryGetValue( cellPosition.x, cellPosition.y, out value );

        #endregion

        #endregion

        #region Value manipulation

        /// <summary>
        ///     Sets all the value in the grid to the given value
        /// </summary>
        public void Fill( T value = default )
        {
            for ( int x = 0; x < Width; ++x )
                for ( int y = 0; y < Height; ++y )
                    _gridArray[x, y] = value;
        }

        public void Fill( Func<int, int, T> fillFunction )
        {
            for ( int x = 0; x < Width; ++x )
                for ( int y = 0; y < Height; ++y )
                    _gridArray[x, y] = fillFunction( x, y );
        }

        /// <summary>
        ///     Uses this function onto all the values on the grid
        /// </summary>
        public void Map( Func<BoundGrid<T>, int, int, T> mapFunction )
        {
            for ( int x = 0; x < Width; ++x )
                for ( int y = 0; y < Height; ++y )
                    _gridArray[x, y] = mapFunction.Invoke( this, x, y );
        }

        #endregion

        #region Bounds

        /// <summary>
        ///     Get grid's bounds on world position
        /// </summary>
        public AABBFloat2 GetWorldBounds()
        {
            var boundCenter = Origin + (Float2)GridSize * .5f;

            return new AABBFloat2( boundCenter, (Float2)GridSize );
        }

        /// <summary>
        ///     Get grid's bounds on grid position
        /// </summary>
        public AABBFloat2 GetLocalBounds() =>
            new( (Float2)0f, (Float2)GridSize );

        #endregion
    }
}
