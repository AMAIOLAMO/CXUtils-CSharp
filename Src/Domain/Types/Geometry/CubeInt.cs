using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     Represents a Cuboid using integer
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct CubeInt
	{
		public CubeInt(Int3 min, Int3 max) => (this.min, this.max) = (min, max);

		public static CubeInt Create(Int3 min, Int3 size) => new CubeInt(min, min + size);

		public Int3 Size => max - min;

		public float Volume
		{
			get
			{
				Int3 size = Size;
				return size.x * size.y * size.z;
			}
		}

		[FieldOffset(0)]  public readonly Int3 min;
		[FieldOffset(12)] public readonly Int3 max;
	}
}
