using System;
using System.Runtime.InteropServices;
#if CXUTILS_UNSAFE
using System.Diagnostics;
#endif

namespace CXUtils.Types
{
    /// <summary>
    ///     represents two integers
    /// </summary>
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct Int2 : ITypeVectorInt<Int2>
    {
        [FieldOffset( 0 )] public readonly int x;
        [FieldOffset( 4 )] public readonly int y;

        public Int2( int x = 0, int y = 0 ) => ( this.x, this.y ) = ( x, y );
        public Int2( Int2 other ) => ( x, y ) = ( other.x, other.y );

        public int this[ int index ]
        {
            get
            {
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 2, nameof( index )+ " is out of range!");
                    fixed ( int* ptr = &x ) return ptr[index];
                }
                #else
                switch ( index )
                {
                    case 0:
                        return x;
                    case 1:
                        return y;

                    default:
                        throw new IndexOutOfRangeException();
                }
                #endif
            }
        }

        public static Int2 MinValue => (Int2)int.MinValue;
        public static Int2 MaxValue => (Int2)int.MaxValue;

        public static Int2 Zero => (Int2)0;
        public static Int2 One  => (Int2)1;

        public static Int2 UnitY    => new Int2( y: 1 );
        public static Int2 NegUnitY => new Int2( y: -1 );
        public static Int2 UnitX    => new Int2( 1 );
        public static Int2 NegUnitX => new Int2( -1 );

        #region Operator overloading

        public static Int2 operator +( Int2 a, Int2 b ) => new Int2( a.x + b.x, a.y + b.y );
        public static Int2 operator -( Int2 a, Int2 b ) => new Int2( a.x - b.x, a.y - b.y );
        public static Int2 operator *( Int2 a, Int2 b ) => new Int2( a.x * b.x, a.y * b.y );
        public static Int2 operator /( Int2 a, Int2 b ) => new Int2( a.x / b.x, a.y / b.y );
        public static Int2 operator *( Int2 a, int value ) => new Int2( a.x * value, a.y * value );
        public static Int2 operator /( Int2 a, int value ) => new Int2( a.x / value, a.y / value );
        public static Int2 operator %( Int2 a, int value ) => new Int2( a.x % value, a.y % value );
        public static Int2 operator *( int value, Int2 a ) => a * value;
        public static Int2 operator /( int value, Int2 a ) => a / value;
        public static Int2 operator -( Int2 a ) => new Int2( -a.x, -a.y );
        public static bool operator ==( Int2 a, Int2 b ) => a.x == b.x && a.y == b.y;
        public static bool operator !=( Int2 a, Int2 b ) => a.x != b.x || a.y != b.y;

        public static explicit operator Int2( Int3 value ) => new Int2( value.x, value.y );
        public static explicit operator Int2( int value ) => new Int2( value, value );

        #endregion

        #region Utility

        public Int2 Min( Int2 other ) => new Int2( Math.Min( x, other.x ), Math.Min( y, other.y ) );
        public Int2 Max( Int2 other ) => new Int2( Math.Max( x, other.x ), Math.Max( y, other.y ) );

        public int Dot( Int2 other ) => x * other.x + y * other.y;

        public Int2 MapAxis( Func<int, int> mapFunction ) => new Int2( mapFunction( x ), mapFunction( y ) );

        public bool Equals( Int2 other ) => x == other.x && y == other.y;

        public string ToString( string format, IFormatProvider formatProvider ) =>
            "(" + x.ToString( format, formatProvider ) + ", " + y.ToString( format, formatProvider ) + ")";
        public override bool Equals( object obj ) => obj is Int2 other && Equals( other );

        public override int GetHashCode()
        {
            unchecked
            {
                return ( x.GetHashCode() * 397 ) ^ y.GetHashCode();
            }
        }

        public override string ToString() => "(" + x + ", " + y + ")";
        public string ToString( string format ) => "(" + x.ToString( format ) + ", " + y.ToString( format ) + ")";

        #endregion
    }
}
