namespace CXUtils.Types
{
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
}
