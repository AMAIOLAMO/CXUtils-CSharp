using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     Floating point Color between 0 ~ 1 with alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorAFloat
    {
        [FieldOffset( 0 )]  public readonly float r;
        [FieldOffset( 4 )]  public readonly float g;
        [FieldOffset( 8 )]  public readonly float b;
        [FieldOffset( 12 )] public readonly float a;

        public ColorAFloat( float r = 0f, float g = 0f, float b = 0f, float a = 1f ) => ( this.r, this.g, this.b, this.a ) = ( r, g, b, a );
        public ColorAFloat( ColorAFloat other ) => ( r, g, b, a ) = ( other.r, other.g, other.b, other.a );

        #region Operator Overloading

        public static ColorAFloat operator +( ColorAFloat a, ColorAFloat b ) => new ColorAFloat( a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a );
        public static ColorAFloat operator -( ColorAFloat a, ColorAFloat b ) => new ColorAFloat( a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a );

        public static ColorAFloat operator *( ColorAFloat a, ColorAFloat b ) => new ColorAFloat( a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a );
        public static ColorAFloat operator /( ColorAFloat a, ColorAFloat b ) => new ColorAFloat( a.r / b.r, a.g / b.g, a.b / b.b, a.a / b.a );

        public static ColorAFloat operator *( ColorAFloat a, float b ) => new ColorAFloat( a.r * b, a.g * b, a.b * b, a.a * b );
        public static ColorAFloat operator /( ColorAFloat a, float b ) => new ColorAFloat( a.r / b, a.g / b, a.b / b, a.a / b );

        public static implicit operator ColorFloat( ColorAFloat value ) => new ColorFloat( value.r, value.g, value.b );

        #endregion
    }

}
