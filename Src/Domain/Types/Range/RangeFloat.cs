using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using CXUtils.Common;
using CXUtils.Debugging;

namespace CXUtils.Domain.Types.Range
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct RangeFloat
	{
		public RangeFloat(float min, float max)
		{
			Assertion.Assert(max >= min);
			(this.min, this.max) = (min, max);
		}
		
		[Pure] public float Clamp(float value) => MathUtils.Clamp(value, min, max);
		[Pure] public bool Contains(float value) => !(value < min || value > max);
		[Pure] public float Loop(float value) => (value - min).Loop(max - min);

		[Pure] public float Sample(float x) => Tween.Lerp(min, max, x);

		[Pure] public float MapFrom(float value, RangeFloat inRange) =>
			MathUtils.Map(value, inRange.min, inRange.max, min, max);
		[Pure] public float MapFrom(float value, float inMin, float inMax) =>
			MathUtils.Map(value, inMin, inMax, min, max);
		[Pure] public float MapTo(float value, RangeFloat outRange) =>
			MathUtils.Map(value, min, max, outRange.min, outRange.max);
		[Pure] public float MapTo(float value, float outMin, float outMax) =>
			MathUtils.Map(value, min, max, outMin, outMax);

		public static explicit operator RangeFloat(RangeInt range) => new RangeFloat(range.min, range.max);
		public static explicit operator RangeFloat(RangeDouble range) => new RangeFloat((float)range.min, (float)range.max);

		[Pure] public static RangeFloat Normalize => new RangeFloat(0f, 1f);
		[Pure] public static RangeFloat Polarity  => new RangeFloat(-1f, 1f);

		[Pure] public float Range => max - min;

		[FieldOffset(0)] public readonly float min;
		[FieldOffset(4)] public readonly float max;
	}
}
