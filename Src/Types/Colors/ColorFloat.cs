using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     Floating point Color between 0 ~ 1 with no alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorFloat
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

        public static explicit operator ColorAFloat( ColorFloat value ) => new ColorAFloat( value.r, value.g, value.b );

        #endregion
    }
}
