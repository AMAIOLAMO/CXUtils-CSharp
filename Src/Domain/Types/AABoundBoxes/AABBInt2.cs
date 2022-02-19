using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     An axis aligned bounding box using Int2 <br />
	///     NOTE: the <see cref="origin" /> is in the center of the bounding box,
	///     the size is also the full width and full height of the bounding box; <br />
	///     Also it's worth to note that the origin is <see cref="Float2" />
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct AABBInt2 : IEnumerable<Float2>
	{
		public AABBInt2(Float2 origin, Int2 size) => (this.origin, this.size) = (origin, size);
		public AABBInt2(AABBInt2 other) => (origin, size) = (other.origin, other.size);

		public IEnumerator<Float2> GetEnumerator() => new Enumerator(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public float  HalfXSize => size.x / 2f;
		public float  HalfYSize => size.y / 2f;
		public Float2 HalfSize  => (Float2)size / 2f;

		public float MinXBound => origin.x - HalfXSize;
		public float MinYBound => origin.y - HalfYSize;
		public float MaxXBound => origin.x + HalfXSize;
		public float MaxYBound => origin.y + HalfYSize;

		public Float2 MinBound => origin - HalfSize;
		public Float2 MaxBound => origin + HalfSize;

		[FieldOffset(0)] public readonly Float2 origin;
		[FieldOffset(8)] public readonly Int2   size;

		class Enumerator : IEnumerator<Float2>
		{
			public Enumerator(AABBInt2 boundBox) => this.boundBox = boundBox;

			public bool MoveNext()
			{
				int resultX = currentOffset.x + 1;

				if (resultX > boundBox.size.x)
				{
					if (currentOffset.y > boundBox.size.y)
						return false;

					//else
					currentOffset = new Int2(0, currentOffset.y + 1);
				}
				else
				{
					currentOffset = new Int2(resultX, currentOffset.y);
				}

				Current = (Float2)currentOffset + boundBox.origin;

				return true;
			}

			public void Reset()
			{
				currentOffset = Int2.Zero;
				Current = boundBox.origin;
			}
			public Float2 Current { get; private set; }

			object IEnumerator.Current => Current;

			public void Dispose() { }
			readonly AABBInt2 boundBox;

			Int2 currentOffset = Int2.Zero;
		}
	}
}
