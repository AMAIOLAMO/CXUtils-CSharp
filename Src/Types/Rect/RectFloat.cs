using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     Represents a rectangle using float
    /// </summary>
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct RectFloat
    {
        public RectFloat( Float2 min, Float2 max ) => ( this.min, this.max ) = ( min, max );

        [FieldOffset( 0 )] public readonly Float2 min;
        [FieldOffset( 8 )] public readonly Float2 max;

        public Float2 Size => max - min;

        public Float2 Center => min + Size.Halve;

        public float Area
        {
            get
            {
                var size = Size;
                return size.x * size.y;
            }
        }

        public static RectFloat Create( Float2 min, Float2 size ) => new RectFloat( min, min + size );

        public static implicit operator RectFloat( RectInt value ) => new RectFloat( (Float2)value.min, (Float2)value.max );
    }
}
