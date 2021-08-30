namespace CXUtils.Types
{
    /// <summary>
    ///     Represents a rectangle using float
    /// </summary>
    public readonly struct RectFloat
    {
        public RectFloat(Float2 min, Float2 max) => (this.min, this.max) = (min, max);

        public readonly Float2 min, max;

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

        public static RectFloat Create(Float2 min, Float2 size) => new RectFloat(min, min + size);

        public static implicit operator RectFloat(RectInt value) => new RectFloat((Float2)value.min, (Float2)value.max);
    }

    /// <summary>
    ///     Represents a rectangle using integer
    /// </summary>
    public readonly struct RectInt
    {
        public RectInt(Int2 min, Int2 max) => (this.min, this.max) = (min, max);

        public readonly Int2 min, max;

        public Int2 Size => max - min;

        public float Area
        {
            get
            {
                var size = Size;
                return size.x * size.y;
            }
        }

        public static RectInt Create(Int2 min, Int2 size) => new RectInt(min, min + size);
    }

    /// <summary>
    ///     Represents a Cuboid using float
    /// </summary>
    public readonly struct CuboidFloat
    {
        public CuboidFloat(Float3 min, Float3 max) => (this.min, this.max) = (min, max);

        public readonly Float3 min, max;

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

        public static CuboidFloat Create(Float3 min, Float3 size) => new CuboidFloat(min, min + size);

        public static implicit operator CuboidFloat(CuboidInt value) => new CuboidFloat((Float3)value.min, (Float3)value.max);
    }

    /// <summary>
    ///     Represents a Cuboid using integer
    /// </summary>
    public readonly struct CuboidInt
    {
        public CuboidInt(Int3 min, Int3 max) => (this.min, this.max) = (min, max);

        public readonly Int3 min, max;

        public Int3 Size => max - min;

        public float Volume
        {
            get
            {
                var size = Size;
                return size.x * size.y * size.z;
            }
        }

        public static CuboidInt Create(Int3 min, Int3 size) => new CuboidInt(min, min + size);
    }
}