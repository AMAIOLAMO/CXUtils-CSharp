using System;
using System.Runtime.InteropServices;

namespace CXUtils.Types
{
    /// <summary>
    ///     Represents a Cuboid using float
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct CuboidFloat
    {
        public CuboidFloat( Float3 min, Float3 max ) => ( this.min, this.max ) = ( min, max );

        [FieldOffset( 0 )]  public readonly Float3 min;
        [FieldOffset( 12 )] public readonly Float3 max;

        public Float3 Size => max - min;

        public Float3 Center => min + Size.Halve;

        public float Volume
        {
            get
            {
                var size = Size;
                return size.x * size.y * size.z;
            }
        }

        public static CuboidFloat Create( Float3 min, Float3 size ) => new CuboidFloat( min, min + size );

        public static implicit operator CuboidFloat( CuboidInt value ) => new CuboidFloat( (Float3)value.min, (Float3)value.max );
    }
}
