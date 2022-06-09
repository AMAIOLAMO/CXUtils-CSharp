using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     An axis aligned bounding box using Int2 <br />
	///     NOTE: the <see cref="origin" /> is designed to be the least significant corner of the box
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct AABBInt2 : IEnumerable<Int2>
	{
		public AABBInt2(Int2 origin, Int2 size) =>
			(this.origin, this.size) = (origin, size);

		public AABBInt2(AABBInt2 other) : this(other.origin, other.size) { }

		public IEnumerator<Int2> GetEnumerator() => new Enumerator(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public bool Contains(Float2 point) =>
			!(point.x < MinXBound || point.x > MaxXBound || point.y < MinYBound || point.y > MinYBound);

		public bool Contains(Int2 point) =>
			!(point.x < MinXBound || point.x > MaxXBound || point.y < MinYBound || point.y > MinYBound);

		public float HalfXSize => size.x / 2f;
		public float HalfYSize => size.y / 2f;
		public Int2  HalfSize  => size / 2;

		public Float2 HalfSizeFloat => ((Float2)size).Halve;

		public float MinXBound => origin.x;
		public float MinYBound => origin.y;
		public float MaxXBound => origin.x + size.x;
		public float MaxYBound => origin.y + size.y;

		public Int2 MinBound => origin;
		public Int2 MaxBound => origin + size;

		public Int2   Center      => origin + HalfSize;
		public Float2 CenterFloat => (Float2)origin + HalfSizeFloat;

		[FieldOffset(0)] public readonly Int2 origin;
		[FieldOffset(8)] public readonly Int2 size;

		class Enumerator : IEnumerator<Int2>
		{
			public Enumerator(AABBInt2 boundBox) => _boundBox = boundBox;

			public bool MoveNext()
			{
				int resultX = _currentOffset.x + 1;

				if (resultX > _boundBox.size.x)
				{
					if (_currentOffset.y > _boundBox.size.y)
						return false;

					//else

					_currentOffset = new Int2(0, _currentOffset.y + 1);
				}
				else
					_currentOffset = _currentOffset.WithX(resultX);

				Current = _currentOffset + _boundBox.origin;

				return true;
			}

			public void Reset()
			{
				_currentOffset = Int2.Zero;
				Current = _boundBox.origin;
			}

			public Int2 Current { get; private set; }

			object IEnumerator.Current => Current;

			public void Dispose() { }

			readonly AABBInt2 _boundBox;

			Int2 _currentOffset = Int2.Zero;
		}
	}
}
