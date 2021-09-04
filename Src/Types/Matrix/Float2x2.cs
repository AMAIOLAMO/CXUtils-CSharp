#nullable enable
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CXUtils.Common;
using CXUtils.Types.Utils;

namespace CXUtils.Types
{
    /// <summary>
    ///     Represents a 2x2 floating point matrix
    /// </summary>
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct Float2X2 : IEquatable<Float2X2>, IFormattable
    {
        /// <summary>
        ///     Left Column
        /// </summary>
        [FieldOffset( 0 )] public readonly Float2 iHat;
        /// <summary>
        ///     Right Column
        /// </summary>
        [FieldOffset( 8 )] public readonly Float2 jHat;

        public Float2X2( Float4 value ) => ( iHat, jHat ) = ( value.XY(), value.ZW() );
        public Float2X2( float leftUp, float leftDown, float rightUp, float rightDown ) =>
            ( iHat, jHat ) = ( new Float2( leftUp, leftDown ), new Float2( rightUp, rightDown ) );
        public Float2X2( Float2 iHat, Float2 jHat ) => ( this.iHat, this.jHat ) = ( iHat, jHat );

        public Float2X2 Transposed  => new Float2X2( new Float2( iHat.x, jHat.x ), new Float2( iHat.y, jHat.y ) );
        public float    Determinant => iHat.x * jHat.y - jHat.x * iHat.y;
        public bool     IsSingular  => Determinant == 0f;

        public static Float2X2 Zero     => new Float2X2( 0f, 0f, 0f, 0f );
        public static Float2X2 Identity => new Float2X2( new Float2( 1f ), new Float2( 0f, 1f ) );

        #region Operators

        public static Float2X2 operator +( Float2X2 a, Float2X2 b ) => new Float2X2( a.iHat + b.iHat, a.jHat + b.jHat );
        public static Float2X2 operator -( Float2X2 a, Float2X2 b ) => new Float2X2( a.iHat - b.iHat, a.jHat - b.jHat );

        public static Float2X2 operator *( Float2X2 matrix, float scalar ) => new Float2X2( matrix.iHat * scalar, matrix.jHat * scalar );
        public static Float2X2 operator *( Float2X2 a, Float2X2 b ) => new Float2X2(
            new Float2( a.iHat.x * b.iHat.x + a.jHat.x * b.iHat.y, a.iHat.x * b.jHat.x + a.jHat.x * b.jHat.y ),
            new Float2( a.iHat.y * b.iHat.x + a.jHat.y * b.iHat.y, a.iHat.y * b.jHat.x + a.jHat.y * b.jHat.y )
        );

        public static Float2X2 operator /( Float2X2 matrix, float scalar ) => new Float2X2( matrix.iHat / scalar, matrix.jHat / scalar );
        public static Float2X2 operator /( Float2X2 a, Float2X2 b ) => a * b.GetInverse();

        public static bool operator ==( Float2X2 left, Float2X2 right ) => left.iHat == right.iHat && left.jHat == right.jHat;

        public static bool operator !=( Float2X2 left, Float2X2 right ) => left.iHat != right.iHat || left.jHat != right.jHat;

        public static Float2X2 operator -( Float2X2 matrix ) => new Float2X2( -matrix.iHat, -matrix.jHat );

        #endregion

        #region Methods

        public bool TryGetInverse( out Float2X2 inverse )
        {
            if ( Determinant == 0f )
            {
                inverse = default;
                return false;
            }

            inverse = GetInverse();
            return true;
        }

        public Float2X2 GetInverse()
        {
            Debug.Assert( !IsSingular, "Cannot get the inverse of a singular matrix!" );
            float scalar = 1f / Determinant;
            return new Float2X2( new Float2( jHat.y * scalar, -iHat.y * scalar ), new Float2( -jHat.x * scalar, iHat.x * scalar ) );
        }

        public bool Equals( Float2X2 other ) => iHat.Equals( other.iHat ) && jHat.Equals( other.jHat );
        public override bool Equals( object? obj ) => obj is Float2X2 other && Equals( other );
        public override int GetHashCode()
        {
            unchecked { return ( iHat.GetHashCode() * 397 ) ^ jHat.GetHashCode(); }
        }
        public override string ToString() => "(I Hat: " + iHat + ", J Hat: " + jHat + ")";
        public string ToString( string? format, IFormatProvider? formatProvider ) =>
            "(I Hat: " + iHat.ToString( format, formatProvider ) + ", J Hat: " + jHat.ToString( format, formatProvider ) + ")";

        public string ToString( MatrixFormat format )
        {
            switch ( format )
            {
                case MatrixFormat.Compact:
                    return "(" + iHat.x + ", " + iHat.y + ", " + jHat.x + ", " + jHat.y + ')'; 
                
                case MatrixFormat.Mathematical:
                    return
                        "|" + iHat.x + ' ' + jHat.x + "|\n" +
                        '|' + iHat.y + ' ' + jHat.y + '|';
                
                default: throw ExceptionUtils.PossibilityNotImplemented;
            }
        }

        #endregion

        #region Static Methods

        public static Float2X2 BuildDiagonal( Float2 value ) => new Float2X2( new Float2( value.x ), new Float2( 0f, value.y ) );
        public static Float2X2 BuildScalar( float value ) => new Float2X2( new Float2( value ), new Float2( 0f, value ) );

        #endregion
    }
}
