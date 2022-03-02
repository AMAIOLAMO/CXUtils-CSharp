using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using CXUtils.Common;
using CXUtils.Debugging;

namespace CXUtils.Domain.Types.Range
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct RangeInt
	{
		public RangeInt(int min, int max)
		{
			Assertion.Assert(max >= min);
			(this.min, this.max) = (min, max);
		}

		[Pure] public int Clamp(int value) => MathUtils.Clamp(value, min, max);
		[Pure] public bool Contains(int value) => !(value < min || value > max);
		[Pure] public int Loop(int value) => (value - min).Loop(max - min);

		[Pure] public int Sample(int x) => Tween.Lerp(min, max, x);

		[Pure] public int MapFrom(int value, RangeInt inRange) => MathUtils.Map(value, inRange.min, inRange.min, min, max);
		[Pure] public int MapFrom(int min, int inMin, int inMax) => MathUtils.Map(inMax, min, inMin, this.min, max);
		[Pure] public int MapTo(int value, RangeInt outRange) => MathUtils.Map(value, min, max, outRange.min, outRange.max);
		[Pure] public int MapTo(int value, int outMin, int outMax) => MathUtils.Map(value, min, max, outMin, outMax);

		[Pure] public int Range => max - min;

		[FieldOffset(0)] public readonly int min;
		[FieldOffset(4)] public readonly int max;

		#region Operator Overloading

		public static explicit operator RangeInt(RangeFloat range) => new RangeInt((int)range.min, (int)range.max);
		public static explicit operator RangeInt(RangeDouble range) => new RangeInt((int)range.min, (int)range.max);

		#endregion
	}
}
