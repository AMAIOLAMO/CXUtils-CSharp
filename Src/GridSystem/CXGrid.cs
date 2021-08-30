using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CXUtils.Types;

namespace CXUtils.Grid
{
    public abstract class GridBase<T>
    {
        public GridBase( Float2 cellSize, Float2 origin = default ) => ( Origin, CellSize ) = ( origin, cellSize );

        public Float2 CellSize { get; }
        public Float2 Origin { get; }

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

    public abstract class UnSpacedGridBase<T> : GridBase<T>
    {
        protected UnSpacedGridBase( Float2 cellSize, Float2 origin = default ) : base( cellSize, origin ) { }

        public override Float2 CellToWorld( int x, int y ) => new Float2( x, y ) * CellSize + Origin;
        public override Float2 CellToWorld( Int2 cellPosition ) => (Float2)cellPosition * CellSize + Origin;

        public override Int2 WorldToCell( float x, float y ) => ( WorldToLocal( x, y ) / CellSize ).FloorInt;
        public override Int2 WorldToCell( Float2 worldPosition ) => ( WorldToLocal( worldPosition ) / CellSize ).FloorInt;

        public override Float2 LocalToWorld( float x, float y ) => new Float2( x, y ) + Origin;
        public override Float2 LocalToWorld( Float2 localPosition ) => localPosition + Origin;

        public override Float2 WorldToLocal( float x, float y ) => new Float2( x, y ) - Origin;
        public override Float2 WorldToLocal( Float2 worldPosition ) => worldPosition - Origin;
    }

    public interface IUnsafeGrid2D<T>
    {
        public bool TryGetValue( Int2 cellPosition, out T value );
        public bool TryGetValue( int x, int y, out T value );
    }

    /// <summary>
    ///     A 2D Infinite sized / boundless grid system
    /// </summary>
    /// <typeparam name="T">the type that each cell stores</typeparam>
    public class BoundlessGrid<T> : UnSpacedGridBase<T>, IUnsafeGrid2D<T>
    {
        readonly Dictionary<Int2, T> _gridDictionary;
        public BoundlessGrid( Float2 cellSize, Float2 origin = default ) : base( cellSize, origin ) => _gridDictionary = new Dictionary<Int2, T>();

        public override T this[ int x, int y ]
        {
            get => this[new Int2( x, y )];
            set => this[new Int2( x, y )] = value;
        }
        public override T this[ Int2 cellPosition ]
        {
            get => _gridDictionary[cellPosition];
            set
            {
                if ( _gridDictionary.ContainsKey( cellPosition ) )
                {
                    _gridDictionary[cellPosition] = value;
                    return;
                }

                //else
                _gridDictionary.Add( cellPosition, value );
            }
        }

        public bool TryGetValue( int x, int y, out T value ) => TryGetValue( new Int2( x, y ), out value );

        public bool TryGetValue( Int2 cellPosition, out T value )
        {
            value = default;

            if ( !CellExists( cellPosition ) )
                return false;

            value = this[cellPosition];
            return true;
        }

        public bool TryPopCell( Int2 cellPosition, out T value )
        {
            value = default;
            if ( !CellExists( cellPosition ) )
                return false;

            value = PopCell( cellPosition );
            return true;
        }

        public bool TryPopCell( int x, int y, out T value ) => TryPopCell( new Int2( x, y ), out value );

        /// <summary>
        ///     Removes the cell content from the grid and pops it out
        /// </summary>
        public T PopCell( Int2 cellPosition )
        {
            var content = _gridDictionary[cellPosition];

            _gridDictionary.Remove( cellPosition );

            return content;
        }

        /// <inheritdoc cref="PopCell(Int2)" />
        public T PopCell( int x, int y ) => PopCell( new Int2( x, y ) );

        public bool TryRemoveCell( Int2 cellPosition )
        {
            if ( !CellExists( cellPosition ) )
                return false;

            RemoveCell( cellPosition );
            return true;
        }

        public bool TryRemoveCell( int x, int y ) => TryRemoveCell( new Int2( x, y ) );

        public void RemoveCell( Int2 cellPosition ) => _gridDictionary.Remove( cellPosition );
        public void RemoveCell( int x, int y ) => RemoveCell( new Int2( x, y ) );


        public bool CellExists( Int2 cellPosition ) => _gridDictionary.ContainsKey( cellPosition );

        public bool CellExists( int x, int y ) => CellExists( new Int2( x, y ) );

        public ReadOnlyDictionary<Int2, T> GetAllCells() => new ReadOnlyDictionary<Int2, T>( _gridDictionary );
    }

    /// <summary>
    ///     A 2D Limited size / bounded grid system
    /// </summary>
    /// <typeparam name="T">The type that each cell stores</typeparam>
    public class BoundGrid<T> : UnSpacedGridBase<T>, IUnsafeGrid2D<T>
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
        public int Width { get; }
        public int Height { get; }

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
        public Int2 GridSize => new Int2( Width, Height );

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
            new AABBFloat2( (Float2)0f, (Float2)GridSize );

        #endregion
    }
}
