using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     An axis aligned bounding box using Float2 <br />
	///     NOTE: the <see cref="origin" /> is designed to be the least significant corner of the box
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct AABBFloat2
	{
		public AABBFloat2(Float2 origin, Float2 size) =>
			(this.origin, this.size) = (origin, size);

		public AABBFloat2(AABBFloat2 other) : this(other.origin, other.size) { }

		public bool Contains(Float2 point) =>
			!(point.x < MinXBound || point.x > MaxXBound || point.y < MinYBound || point.y > MinYBound);

		public float  HalfXSize => size.x / 2f;
		public float  HalfYSize => size.y / 2f;
		public Float2 HalfSize  => size.Halve;

		public float MinXBound => origin.x;
		public float MinYBound => origin.y;
		public float MaxXBound => origin.x + size.x;
		public float MaxYBound => origin.y + size.y;

		public Float2 MinBound => origin;
		public Float2 MaxBound => origin + size;

		[FieldOffset(0)] public readonly Float2 origin;
		[FieldOffset(8)] public readonly Float2 size;

		public static explicit operator AABBFloat2(AABBInt2 other) => new((Float2)other.origin, (Float2)other.size);
	}
}
