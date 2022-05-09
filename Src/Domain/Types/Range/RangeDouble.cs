using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using CXUtils.Common;
using CXUtils.Debugging;

namespace CXUtils.Domain.Types.Range
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct RangeDouble
	{
		public RangeDouble(double min, double max)
		{
			Assertion.Assert(max >= min);
			(this.min, this.max) = (min, max);
		}

		[Pure] public double Clamp(double value) => MathUtils.Clamp(value, min, max);
		[Pure] public bool Contains(double value) => !(value < min || value > max);
		[Pure] public double Loop(double value) => (value - min).Loop(max - min);

		[Pure] public double Sample(double x) => Tween.Lerp(min, max, x);

		[Pure] public double RemapFrom(double value, RangeDouble inRange) =>
			MathUtils.Remap(value, inRange.min, inRange.max, min, max);
		[Pure] public double RemapFrom(double value, double inMin, double inMax) =>
			MathUtils.Remap(value, inMin, inMax, min, max);
		[Pure] public double RemapTo(double value, RangeDouble outRange) =>
			MathUtils.Remap(value, min, max, outRange.min, outRange.max);
		[Pure] public double RemapTo(double value, double outMin, double outMax) =>
			MathUtils.Remap(value, min, max, outMin, outMax);

		[Pure] public static RangeDouble One      => new(0d, 1d);
		[Pure] public static RangeDouble Polarity => new(-1d, 1d);

		[Pure] public double Range => max - min;

		[FieldOffset(0)] public readonly double min;
		[FieldOffset(8)] public readonly double max;
	}
}
