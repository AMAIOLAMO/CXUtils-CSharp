using System;
using System.Diagnostics;
using System.Text;
using CXUtils.Common;

namespace CXUtils.Types
{
    /// <summary>
    ///     A customizable size floating point matrix
    /// </summary>
    public class MatrixFloat
    {
        /// <summary>
        ///     The width of the matrix
        /// </summary>
        public readonly int column;
        /// <summary>
        ///     The height of the matrix
        /// </summary>
        public readonly int row;

        float[] _data;

        MatrixFloat( int row, int column )
        {
            this.row = row;
            this.column = column;

            _data = new float[column * row];
        }

        public float this[ int x, int y ]
        {
            get => _data[x + y * column];
            set => _data[x + y * column] = value;
        }

        public float this[ int index ]
        {
            get => _data[index];
            set => _data[index] = value;
        }

        #region Operators

        public static MatrixFloat operator +( MatrixFloat a, MatrixFloat b )
        {
            AssertEqualDimensions( a, b );

            var result = new MatrixFloat( a.row, a.column );
            for ( int i = 0; i < a._data.Length; ++i ) result[i] = a[i] + b[i];

            return result;
        }

        public static MatrixFloat operator -( MatrixFloat a, MatrixFloat b )
        {
            AssertEqualDimensions( a, b );

            var result = new MatrixFloat( a.row, a.column );
            for ( int i = 0; i < a._data.Length; ++i ) result[i] = a[i] - b[i];

            return result;
        }

        public static MatrixFloat operator *( MatrixFloat a, MatrixFloat b )
        {
            AssertMultiplyDimensions( a, b );
            var result = new MatrixFloat( a.row, b.column );

            for ( int y = 0; y < result.row; ++y )
            {
                for ( int x = 0; x < result.column; ++x )
                {
                    float resultValue = 0f;
                    for ( int i = 0; i < a.column; ++i ) resultValue += a[i, y] * b[x, i];
                    result[x, y] = resultValue;
                }
            }

            return result;
        }

        public static MatrixFloat operator *( MatrixFloat a, float scalar )
        {
            var result = BuildDimension( a );
            for ( int i = 0; i < a._data.Length; ++i ) result[i] = a[i] * scalar;

            return result;
        }

        public static MatrixFloat operator /( MatrixFloat a, float scalar )
        {
            var result = BuildDimension( a );
            for ( int i = 0; i < a._data.Length; ++i ) result[i] = a[i] / scalar;

            return result;
        }

        public static MatrixFloat operator -( MatrixFloat matrix )
        {
            var result = new MatrixFloat( matrix.row, matrix.column );
            for ( int i = 0; i < matrix._data.Length; ++i ) result[i] = -matrix[i];

            return result;
        }

        public static bool operator ==( MatrixFloat a, MatrixFloat b )
        {
            if ( a == null && b == null ) return true;
            if ( a == null || b == null || !a.IsEqualDimension( b ) ) return false;
            
            for ( int i = 0; i < a._data.Length; ++i )
            {
                if(a._data[i] == b._data[i]) continue;

                return false;
            }

            return true;
        }
        public static bool operator !=( MatrixFloat a, MatrixFloat b )
        {
            if ( a == null && b == null ) return false;
            if ( a == null || b == null || !a.IsEqualDimension( b ) ) return true;
            
            for ( int i = 0; i < a._data.Length; ++i )
            {
                if(a._data[i] != b._data[i]) continue;

                return true;
            }

            return false;
        }

        #endregion

        #region Methods

        public float[] GetRawData() => _data;

        public void SetRawData( float[] data )
        {
            Debug.Assert( data.Length == _data.Length, nameof( data ) + " doesn't match the current matrix's dimensions!" );
            _data = data;
        }
        protected bool Equals( MatrixFloat other ) => column == other.column && row == other.row && Equals( _data, other._data );
        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) ) return false;
            if ( ReferenceEquals( this, obj ) ) return true;
            return obj.GetType() == this.GetType() && Equals( (MatrixFloat)obj );

        }
        public override int GetHashCode() => HashCode.Combine( column, row );

        public override string ToString()
        {
            using var poolObject = CommonPools.StringBuilder.Pop();
            
            var sb = poolObject.Get();
                
            for ( int y = 0; y < row; ++y )
            {
                sb.Append( '|' );
                for ( int x = 0; x < column - 1; ++x )
                {
                    sb.Append(this[x, y] + " ");
                }

                //last
                sb.Append(this[column - 1, y]);
                
                sb.Append( "|\n" );
            }

            return sb.ToString();

        }

        public bool IsEqualDimension( int row, int column ) => this.row == row && this.column == column;
        public bool IsEqualDimension( MatrixFloat other ) => IsEqualDimension( other.row, other.column );

        #endregion

        #region Static Methods

        /// <summary>
        ///     Builds a floating point null matrix (Filled with 0f)
        /// </summary>
        public static MatrixFloat Build( int row, int column ) => new MatrixFloat( row, column );

        /// <summary>
        ///     Builds a floating point matrix with the values initialized by <paramref name="initializeFunction" />
        /// </summary>
        public static MatrixFloat Build( int row, int column, Func<int, int, float> initializeFunction )
        {
            var result = new MatrixFloat( row, column );

            for ( int x = 0; x < column; x++ )
                for ( int y = 0; y < row; ++y )
                    result[x, y] = initializeFunction( x, y );

            return result;
        }

        public static MatrixFloat BuildDimension( MatrixFloat other ) => new MatrixFloat( other.row, other.column );

        public static MatrixFloat BuildScalar( int row, int column, float scalar )
        {
            var result = new MatrixFloat( row, column );

            int y = 0;

            for ( int x = 0; x < column; ++x )
            {
                result[x, y] = scalar;
                if ( ++y >= row ) break;
            }

            return result;
        }

        public static MatrixFloat BuildDiagonal( int row, int column, Func<int, int, float> initializeFunction )
        {
            var result = new MatrixFloat( row, column );

            int y = 0;

            for ( int x = 0; x < column; ++x )
            {
                result[x, y] = initializeFunction( x, y );
                if ( ++y >= row ) break;
            }

            return result;
        }

        [Conditional( "DEBUG" )]
        static void AssertMultiplyDimensions( MatrixFloat a, MatrixFloat b ) => Debug.Assert( a.row == b.column, nameof( b ) + "'s column count doesn't match the current matrix's row count!" );

        [Conditional( "DEBUG" )]
        static void AssertEqualDimensions( MatrixFloat a, MatrixFloat b ) => Debug.Assert( a.IsEqualDimension( b ), nameof( b ) + " doesn't match the current matrix's dimensions!" );

        #endregion
    }
}
