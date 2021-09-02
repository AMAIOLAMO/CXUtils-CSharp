namespace CXUtils.Types
{

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