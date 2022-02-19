using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     Represents a rectangle using float
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct RectFloat
	{
		public RectFloat(Float2 min, Float2 max) => (this.min, this.max) = (min, max);

		public static RectFloat Create(Float2 min, Float2 size) => new(min, min + size);

		public static implicit operator RectFloat(RectInt value) => new((Float2)value.min, (Float2)value.max);

		public Float2 Size => max - min;

		public Float2 Center => min + Size.Halve;

		public float Area
		{
			get
			{
				Float2 size = Size;
				return size.x * size.y;
			}
		}

		[FieldOffset(0)] public readonly Float2 min;
		[FieldOffset(8)] public readonly Float2 max;
	}
}
