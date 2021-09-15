#nullable enable
using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     Integer based Color between 0 ~ 255 with no alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorInt : IColor<ColorInt>
    {
        [FieldOffset( 0 )] public readonly int r;
        [FieldOffset( 4 )] public readonly int g;
        [FieldOffset( 8 )] public readonly int b;

        public ColorInt( int r = 0, int g = 0, int b = 0 ) => ( this.r, this.g, this.b ) = ( r, g, b );
        public ColorInt( ColorInt other ) => ( r, g, b ) = ( other.r, other.g, other.b );

        #region Operator Overloading

        public static ColorInt operator +( ColorInt a, ColorInt b ) => new ColorInt( a.r + b.r, a.g + b.g, a.b + b.b );
        public static ColorInt operator -( ColorInt a, ColorInt b ) => new ColorInt( a.r - b.r, a.g - b.g, a.b - b.b );

        public static ColorInt operator *( ColorInt a, ColorInt b ) => new ColorInt( a.r * b.r, a.g * b.g, a.b * b.b );
        public static ColorInt operator /( ColorInt a, ColorInt b ) => new ColorInt( a.r / b.r, a.g / b.g, a.b / b.b );

        public static ColorInt operator *( ColorInt a, int b ) => new ColorInt( a.r * b, a.g * b, a.b * b );
        public static ColorInt operator /( ColorInt a, int b ) => new ColorInt( a.r / b, a.g / b, a.b / b );

        public static bool operator ==( ColorInt a, ColorInt b ) => !( a.r != b.r || a.g != b.g || a.b != b.b );

        public static bool operator !=( ColorInt a, ColorInt b ) => a.r != b.r && a.g != b.g && a.b != b.b;
        
        public static explicit operator ColorAInt( ColorInt value ) => new ColorAInt( value.r, value.g, value.b );

        #endregion
        
        #region Methods

        public bool Equals( ColorInt other ) => this == other;
        public override string ToString() => "( r:" + r + ", g:" + g + ", b:" + b + " )";
        public string ToString( string? format, IFormatProvider? formatProvider ) =>
            "( r:" + r.ToString( format, formatProvider ) +
            ", g:" + g.ToString( format, formatProvider ) +
            ", b:" + b.ToString( format, formatProvider ) + " )";

        public override bool Equals( object? obj ) => obj is ColorInt value && Equals( value );

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = r.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ g.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ b.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
