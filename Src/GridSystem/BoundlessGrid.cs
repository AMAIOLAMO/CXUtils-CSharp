using System.Collections.Generic;
using System.Collections.ObjectModel;
using CXUtils.Types;

namespace CXUtils.Grid
{
    /// <summary>
    ///     A 2D Infinite sized / boundless grid system
    /// </summary>
    /// <typeparam name="T">the type that each cell stores</typeparam>
    public class BoundlessGrid<T> : UnSpacedGridBase<T>, INullableGrid2D<T>
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
}
