using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     Represents a rectangle using integer
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct RectInt
	{
		public RectInt(Int2 min, Int2 max) => (this.min, this.max) = (min, max);

		public static RectInt Create(Int2 min, Int2 size) => new(min, min + size);

		public Int2 Size => max - min;

		public float Area
		{
			get
			{
				Int2 size = Size;
				return size.x * size.y;
			}
		}

		[FieldOffset(0)] public readonly Int2 min;
		[FieldOffset(8)] public readonly Int2 max;
	}
}
