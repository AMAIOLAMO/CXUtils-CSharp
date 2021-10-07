#nullable enable
using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     Floating point Color between 0 ~ 1 with no alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorFloat : IColor<ColorFloat>
    {
        [FieldOffset( 0 )] public readonly float r;
        [FieldOffset( 4 )] public readonly float g;
        [FieldOffset( 8 )] public readonly float b;

        public ColorFloat( float r = 0f, float g = 0f, float b = 0f ) => ( this.r, this.g, this.b ) = ( r, g, b );
        public ColorFloat( ColorFloat other ) => ( r, g, b ) = ( other.r, other.g, other.b );

        #region Operator Overloading

        public static ColorFloat operator +( ColorFloat a, ColorFloat b ) => new ColorFloat( a.r + b.r, a.g + b.g, a.b + b.b );
        public static ColorFloat operator -( ColorFloat a, ColorFloat b ) => new ColorFloat( a.r - b.r, a.g - b.g, a.b - b.b );

        public static ColorFloat operator *( ColorFloat a, ColorFloat b ) => new ColorFloat( a.r * b.r, a.g * b.g, a.b * b.b );
        public static ColorFloat operator /( ColorFloat a, ColorFloat b ) => new ColorFloat( a.r / b.r, a.g / b.g, a.b / b.b );

        public static ColorFloat operator *( ColorFloat a, float b ) => new ColorFloat( a.r * b, a.g * b, a.b * b );
        public static ColorFloat operator /( ColorFloat a, float b ) => new ColorFloat( a.r / b, a.g / b, a.b / b );
        
        public static bool operator ==( ColorFloat a, ColorFloat b ) => !( a.r != b.r || a.g != b.g || a.b != b.b );

        public static bool operator !=( ColorFloat a, ColorFloat b ) => a.r != b.r && a.g != b.g && a.b != b.b;

        public static explicit operator ColorAFloat( ColorFloat value ) => new ColorAFloat( value.r, value.g, value.b );

        #endregion
        
        #region Methods

        public bool Equals( ColorFloat other ) => this == other;
        public override string ToString() => "( r:" + r + ", g:" + g + ", b:" + b + " )";
        public string ToString( string? format, IFormatProvider? formatProvider ) =>
            "( r:" + r.ToString( format, formatProvider ) +
            ", g:" + g.ToString( format, formatProvider ) +
            ", b:" + b.ToString( format, formatProvider ) + " )";

        public override bool Equals( object? obj ) => obj is ColorFloat value && Equals( value );

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
