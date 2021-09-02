namespace CXUtils.Types
{
    /// <summary>
    ///     An axis aligned bounding box using Float2 <br />
    ///     NOTE: the <see cref="origin" /> is in the center of the bounding box,
    ///     the size is also the full width and full height of the bounding box
    /// </summary>
    public readonly struct AABBFloat2
    {
        public AABBFloat2( Float2 origin, Float2 size ) => ( this.origin, this.size ) = ( origin, size );
        public AABBFloat2( AABBFloat2 other ) => ( origin, size ) = ( other.origin, other.size );

        public readonly Float2 origin, size;

        public float  HalfXSize => size.x / 2f;
        public float  HalfYSize => size.y / 2f;
        public Float2 HalfSize  => size / 2f;

        public float MinXBound => origin.x - HalfXSize;
        public float MinYBound => origin.y - HalfYSize;
        public float MaxXBound => origin.x + HalfXSize;
        public float MaxYBound => origin.y + HalfYSize;

        public Float2 MinBound => origin - HalfSize;
        public Float2 MaxBound => origin + HalfSize;

        public bool Contains( Float2 point ) => !( point.x < MinXBound || point.x > MaxXBound || point.y < MinYBound || point.y > MinYBound );
    }
}
