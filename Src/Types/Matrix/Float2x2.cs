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
    public readonly struct Float2x2 : IEquatable<Float2x2>, IFormattable
    {
        /// <summary>
        ///     Left Column v00 & v01
        /// </summary>
        [FieldOffset( 0 )] public readonly Float2 iHat;
        /// <summary>
        ///     Right Column v10 & v11
        /// </summary>
        [FieldOffset( 8 )] public readonly Float2 jHat;

        public Float2x2( Float4 value ) => ( iHat, jHat ) = ( value.XY(), value.ZW() );
        public Float2x2(
            float v00, float v10,
            float v01, float v11
        ) => ( iHat, jHat ) = (
            new Float2( v00, v01 ),
            new Float2( v10, v11 )
        );
        
        public Float2x2( Float2 iHat, Float2 jHat ) => ( this.iHat, this.jHat ) = ( iHat, jHat );

        public Float2x2 Transposed  => new Float2x2( new Float2( iHat.x, jHat.x ), new Float2( iHat.y, jHat.y ) );
        public float    Determinant => iHat.Cross( jHat ); //iHat.x * jHat.y - jHat.x * iHat.y;
        public bool     IsSingular  => Determinant == 0f;

        public static Float2x2 Zero => new Float2x2( 0f, 0f, 0f, 0f );
        public static Float2x2 Identity => new Float2x2(
            new Float2( 1f ),
            new Float2( 0f, 1f )
        );

        #region Operators

        public static Float2x2 operator +( Float2x2 a, Float2x2 b ) => new Float2x2( a.iHat + b.iHat, a.jHat + b.jHat );
        public static Float2x2 operator -( Float2x2 a, Float2x2 b ) => new Float2x2( a.iHat - b.iHat, a.jHat - b.jHat );

        public static Float2x2 operator *( Float2x2 matrix, float scalar ) => new Float2x2( matrix.iHat * scalar, matrix.jHat * scalar );
        public static Float2x2 operator *( Float2x2 a, Float2x2 b ) => new Float2x2(
            new Float2( a.iHat.x * b.iHat.x + a.jHat.x * b.iHat.y, a.iHat.x * b.jHat.x + a.jHat.x * b.jHat.y ),
            new Float2( a.iHat.y * b.iHat.x + a.jHat.y * b.iHat.y, a.iHat.y * b.jHat.x + a.jHat.y * b.jHat.y )
        );

        public static Float2 operator *( Float2 vector, Float2x2 matrix ) => new Float2(
            vector.x * matrix.iHat.x + vector.y * matrix.iHat.y,
            vector.x * matrix.jHat.x + vector.y * matrix.jHat.y
        );

        public static Float2 operator *( Float2x2 matrix, Float2 matrix2x1 ) => new Float2(
            matrix.iHat.x * matrix2x1.x + matrix.jHat.x * matrix2x1.y,
            matrix.iHat.y * matrix2x1.x + matrix.jHat.y * matrix2x1.y
        );

        public static Float2x2 operator /( Float2x2 matrix, float scalar ) => new Float2x2( matrix.iHat / scalar, matrix.jHat / scalar );
        public static Float2x2 operator /( Float2x2 a, Float2x2 b ) => a * b.GetInverse();

        public static bool operator ==( Float2x2 left, Float2x2 right ) => left.iHat == right.iHat && left.jHat == right.jHat;

        public static bool operator !=( Float2x2 left, Float2x2 right ) => left.iHat != right.iHat || left.jHat != right.jHat;

        public static Float2x2 operator -( Float2x2 matrix ) => new Float2x2( -matrix.iHat, -matrix.jHat );

        #endregion

        #region Methods

        public bool TryGetInverse( out Float2x2 inverse )
        {
            if ( Determinant == 0f )
            {
                inverse = default;
                return false;
            }

            inverse = GetInverse();
            return true;
        }

        public Float2x2 GetInverse()
        {
            Debug.Assert( !IsSingular, "Cannot get the inverse of a singular matrix!" );
            
            float scalar = 1f / Determinant;
            return new Float2x2( new Float2( jHat.y * scalar, -iHat.y * scalar ), new Float2( -jHat.x * scalar, iHat.x * scalar ) );
        }

        public bool Equals( Float2x2 other ) => iHat.Equals( other.iHat ) && jHat.Equals( other.jHat );
        public override bool Equals( object? obj ) => obj is Float2x2 other && Equals( other );
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

        public static Float2x2 BuildDiagonal( Float2 value ) => new Float2x2( new Float2( value.x ), new Float2( 0f, value.y ) );
        public static Float2x2 BuildScalar( float value ) => new Float2x2( new Float2( value ), new Float2( 0f, value ) );

        #endregion
    }
}
