using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     Integer based Color between 0 ~ 255 with alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorAInt
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

        public static implicit operator ColorInt( ColorAInt value ) => new ColorInt( value.r, value.g, value.b );

        #endregion

    }

}
