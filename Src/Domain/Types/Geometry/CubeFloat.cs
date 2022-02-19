using System;
using System.Runtime.InteropServices;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     Represents a Cuboid using float
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct CubeFloat
	{
		public CubeFloat(Float3 min, Float3 max) => (this.min, this.max) = (min, max);

		public static CubeFloat Create(Float3 min, Float3 size) => new(min, min + size);

		public static implicit operator CubeFloat(CubeInt value) => new((Float3)value.min, (Float3)value.max);

		public Float3 Size => max - min;

		public Float3 Center => min + Size.Halve;

		public float Volume
		{
			get
			{
				Float3 size = Size;
				return size.x * size.y * size.z;
			}
		}

		[FieldOffset(0)]  public readonly Float3 min;
		[FieldOffset(12)] public readonly Float3 max;
	}
}
