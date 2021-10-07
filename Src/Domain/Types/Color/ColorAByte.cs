#nullable enable
using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     byte based Color between 0 ~ 255 with alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorAByte : IColor<ColorAByte>
    {
        [FieldOffset( 0 )] public readonly byte r;
        [FieldOffset( 1 )] public readonly byte g;
        [FieldOffset( 2 )] public readonly byte b;
        [FieldOffset( 3 )] public readonly byte a;

        public ColorAByte( byte r = 0b0, byte g = 0b0, byte b = 0b0, byte a = byte.MaxValue ) => ( this.r, this.g, this.b, this.a ) = ( r, g, b, a );
        public ColorAByte( ColorAByte other ) => ( r, g, b, a ) = ( other.r, other.g, other.b, other.a );

        #region Operator Overloading

        public static bool operator ==( ColorAByte a, ColorAByte b ) => !( a.r != b.r || a.g != b.g || a.b != b.b || a.a != b.a );
        public static bool operator !=( ColorAByte a, ColorAByte b ) => a.r != b.r && a.g != b.g && a.b != b.b && a.a != b.a;

        public static implicit operator ColorByte( ColorAByte value ) => new ColorByte( value.r, value.g, value.b );

        #endregion

        #region Methods

        public bool Equals( ColorAByte other ) => this == other;
        public override string ToString() => "( r:" + r + ", g:" + g + ", b:" + b + ", a:" + a + " )";
        public string ToString( string? format, IFormatProvider? formatProvider ) =>
            "( r:" + r.ToString( format, formatProvider ) +
            ", g:" + g.ToString( format, formatProvider ) +
            ", b:" + b.ToString( format, formatProvider ) +
            ", a:" + a.ToString( format, formatProvider ) + " )";

        public override bool Equals( object? obj ) => obj is ColorAByte value && Equals( value );

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
