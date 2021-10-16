#nullable enable
using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     Integer based Color between 0 ~ 255 with alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorAInt : IColor<ColorAInt>
    {
        [FieldOffset( 0 )]  public readonly int r;
        [FieldOffset( 4 )]  public readonly int g;
        [FieldOffset( 8 )]  public readonly int b;
        [FieldOffset( 12 )] public readonly int a;

        public ColorAInt( int r = 0, int g = 0, int b = 0, int a = 255 ) => ( this.r, this.g, this.b, this.a ) = ( r, g, b, a );
        public ColorAInt( ColorAInt other ) => ( r, g, b, a ) = ( other.r, other.g, other.b, other.a );

        #region Operator Overloading

        public static ColorAInt operator +( ColorAInt a, ColorAInt b ) => new ColorAInt( a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a );
        public static ColorAInt operator -( ColorAInt a, ColorAInt b ) => new ColorAInt( a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a );

        public static ColorAInt operator *( ColorAInt a, ColorAInt b ) => new ColorAInt( a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a );
        public static ColorAInt operator /( ColorAInt a, ColorAInt b ) => new ColorAInt( a.r / b.r, a.g / b.g, a.b / b.b, a.a / b.a );

        public static ColorAInt operator *( ColorAInt a, int b ) => new ColorAInt( a.r * b, a.g * b, a.b * b, a.a * b );
        public static ColorAInt operator /( ColorAInt a, int b ) => new ColorAInt( a.r / b, a.g / b, a.b / b, a.a / b );

        public static bool operator ==( ColorAInt a, ColorAInt b ) => !( a.r != b.r || a.g != b.g || a.b != b.b || a.a != b.a );

        public static bool operator !=( ColorAInt a, ColorAInt b ) => a.r != b.r && a.g != b.g && a.b != b.b && a.a != b.a;
        public static implicit operator ColorInt( ColorAInt value ) => new ColorInt( value.r, value.g, value.b );

        #endregion

        #region Methods

        public bool Equals( ColorAInt other ) => this == other;

        public override string ToString() => "( r:" + r + ", g:" + g + ", b:" + b + ", a:" + a + " )";
        public string ToString( string? format, IFormatProvider? formatProvider ) =>
            "( r:" + r.ToString( format, formatProvider ) +
            ", g:" + g.ToString( format, formatProvider ) +
            ", b:" + b.ToString( format, formatProvider ) +
            ", a:" + a.ToString( format, formatProvider ) + " )";

        public override bool Equals( object? obj ) => obj is ColorAInt value && Equals( value );


        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = r.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ g.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ b.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ a.GetHashCode();
                return hashCode;
            }
        }

        #endregion

    }

}
