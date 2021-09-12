using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     byte based Color between 0 ~ 255 with no alpha
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct ColorByte
    {
        [FieldOffset( 0 )] public readonly byte r;
        [FieldOffset( 1 )] public readonly byte g;
        [FieldOffset( 2 )] public readonly byte b;

        public ColorByte( byte r = 0b0, byte g = 0b0, byte b = 0b0 ) => ( this.r, this.g, this.b ) = ( r, g, b );
        public ColorByte( ColorByte other ) => ( r, g, b ) = ( other.r, other.g, other.b );

        #region Operator Overloading

        public static implicit operator ColorAByte( ColorByte value ) => new ColorAByte( value.r, value.g, value.b );

        #endregion
    }
}
