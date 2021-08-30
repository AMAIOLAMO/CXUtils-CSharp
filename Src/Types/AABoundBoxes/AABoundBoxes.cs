using System.Collections;
using System.Collections.Generic;

namespace CXUtils.Types
{
    /// <summary>
    ///     An axis aligned bounding box using Float2 <br />
    ///     NOTE: the <see cref="origin" /> is in the center of the bounding box,
    ///     the size is also the full width and full height of the bounding box
    /// </summary>
    public readonly struct AABBFloat2
    {
        public AABBFloat2(Float2 origin, Float2 size) => (this.origin, this.size) = (origin, size);
        public AABBFloat2(AABBFloat2 other) => (origin, size) = (other.origin, other.size);

        public readonly Float2 origin, size;

        public float HalfXSize => size.x / 2f;
        public float HalfYSize => size.y / 2f;
        public Float2 HalfSize => size / 2f;

        public float MinXBound => origin.x - HalfXSize;
        public float MinYBound => origin.y - HalfYSize;
        public float MaxXBound => origin.x + HalfXSize;
        public float MaxYBound => origin.y + HalfYSize;

        public Float2 MinBound => origin - HalfSize;
        public Float2 MaxBound => origin + HalfSize;

        public bool Contains(Float2 point) => !(point.x < MinXBound || point.x > MaxXBound || point.y < MinYBound || point.y > MinYBound);
    }

    /// <summary>
    ///     An axis aligned bounding box using Int2 <br />
    ///     NOTE: the <see cref="origin" /> is in the center of the bounding box,
    ///     the size is also the full width and full height of the bounding box; <br />
    ///     Also it's worth to note that the origin is <see cref="Float2" />
    /// </summary>
    public readonly struct AABBInt2 : IEnumerable<Float2>
    {
        public AABBInt2(Float2 origin, Int2 size) => (this.origin, this.size) = (origin, size);
        public AABBInt2(AABBInt2 other) => (origin, size) = (other.origin, other.size);

        public readonly Float2 origin;
        public readonly Int2 size;

        public float HalfXSize => size.x / 2f;
        public float HalfYSize => size.y / 2f;
        public Float2 HalfSize => (Float2)size / 2f;

        public float MinXBound => origin.x - HalfXSize;
        public float MinYBound => origin.y - HalfYSize;
        public float MaxXBound => origin.x + HalfXSize;
        public float MaxYBound => origin.y + HalfYSize;

        public Float2 MinBound => origin - HalfSize;
        public Float2 MaxBound => origin + HalfSize;

        public IEnumerator<Float2> GetEnumerator() => new AABBInt2Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        class AABBInt2Enumerator : IEnumerator<Float2>
        {
            readonly AABBInt2 _boundBox;
            Int2 _currentOffset = Int2.Zero;

            public AABBInt2Enumerator(AABBInt2 boundBox) => _boundBox = boundBox;

            public bool MoveNext()
            {
                int resultX = _currentOffset.x + 1;

                if ( resultX > _boundBox.size.x )
                {
                    if ( _currentOffset.y > _boundBox.size.y )
                        return false;
                    //else
                    _currentOffset = new Int2(0, _currentOffset.y + 1);
                }
                else
                    _currentOffset = new Int2(resultX, _currentOffset.y);

                Current = (Float2)_currentOffset + _boundBox.origin;

                return true;
            }

            public void Reset()
            {
                _currentOffset = Int2.Zero;
                Current = _boundBox.origin;
            }
            public Float2 Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }
}
