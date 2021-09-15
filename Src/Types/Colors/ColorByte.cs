#nullable enable
using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     byte based Color between 0 ~ 255 with no alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorByte : IColor<ColorByte>
    {
        [FieldOffset( 0 )] public readonly byte r;
        [FieldOffset( 1 )] public readonly byte g;
        [FieldOffset( 2 )] public readonly byte b;

        public ColorByte( byte r = 0b0, byte g = 0b0, byte b = 0b0 ) => ( this.r, this.g, this.b ) = ( r, g, b );
        public ColorByte( ColorByte other ) => ( r, g, b ) = ( other.r, other.g, other.b );

        #region Methods

        #endregion

        #region Operator Overloading

        public static bool operator ==( ColorByte a, ColorByte b ) => !( a.r != b.r || a.g != b.g || a.b != b.b );

        public static bool operator !=( ColorByte a, ColorByte b ) => a.r != b.r && a.g != b.g && a.b != b.b;

        public static implicit operator ColorAByte( ColorByte value ) => new ColorAByte( value.r, value.g, value.b );

        #endregion

        #region Methods

        public bool Equals( ColorByte other ) => this == other;
        public override string ToString() => "( r:" + r + ", g:" + g + ", b:" + b + " )";
        public string ToString( string? format, IFormatProvider? formatProvider ) =>
            "( r:" + r.ToString( format, formatProvider ) +
            ", g:" + g.ToString( format, formatProvider ) +
            ", b:" + b.ToString( format, formatProvider ) + " )";

        public override bool Equals( object? obj ) => obj is ColorByte value && Equals( value );

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
