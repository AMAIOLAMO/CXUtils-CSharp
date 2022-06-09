using System;
using System.Runtime.InteropServices;
using CXUtils.Common;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     Represents a single line in 2D
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Line2
	{
		public Line2(Float2 a, Float2 b) => (this.a, this.b) = (a, b);

		/// <summary>
		///     Samples a point in between the two points using <paramref name="t" />
		/// </summary>
		public Float2 Sample(float t) => a.Lerp(b, t);

		/// <summary>
		///     Checks if two lines intersect
		/// </summary>
		public bool Intersect(Line2 other, out float t, out float u)
		{
			float x1Mx2 = a.x - b.x,
				x1Mx3 = a.x - other.a.x,
				x3Mx4 = other.a.x - other.b.x,
				y1My2 = a.y - b.y,
				y1My3 = a.y - other.a.y,
				y3My4 = other.a.y - other.b.y;

			float tUp = x1Mx3 * y3My4 - y1My3 * x3Mx4;
			float uUp = -(x1Mx2 * y1My3 - y1My2 * x1Mx3);
			float den = x1Mx2 * y3My4 - y1My2 * x3Mx4;

			(t, u) = (tUp / den, uUp / den);

			bool tBool, uBool;
			(tBool, uBool) = (t >= 0f && t <= 1f, u >= 0f && u <= 1f);

			return tBool && uBool;
		}

		[FieldOffset(0)] public readonly Float2 a;
		[FieldOffset(8)] public readonly Float2 b;

		public static explicit operator Line2(Line3 value) =>
			new((Float2)value.a, (Float2)value.b);
	}
}
