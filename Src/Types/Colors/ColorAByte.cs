using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     byte based Color between 0 ~ 255 with alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorAByte
    {
        [FieldOffset( 0 )] public readonly byte r;
        [FieldOffset( 1 )] public readonly byte g;
        [FieldOffset( 2 )] public readonly byte b;
        [FieldOffset( 3 )] public readonly byte a;

        public ColorAByte( byte r = 0b0, byte g = 0b0, byte b = 0b0, byte a = byte.MaxValue ) => ( this.r, this.g, this.b, this.a ) = ( r, g, b, a );
        public ColorAByte( ColorAByte other ) => ( r, g, b, a ) = ( other.r, other.g, other.b, other.a );

        #region Operator Overloading

        public static implicit operator ColorByte( ColorAByte value ) => new ColorByte( value.r, value.g, value.b );

        #endregion
    }

}
