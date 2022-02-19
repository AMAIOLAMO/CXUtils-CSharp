using CXUtils.Common;
using CXUtils.Utilities;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     A struct that represents a cubic bezier curve in 2D
	/// </summary>
	public readonly struct CubicBezier3
	{
		public CubicBezier3(Float3 control1, Float3 anchor1, Float3 control2, Float3 anchor2) =>
			buffer = new[] { anchor1, control1, control2, anchor2 };

		public CubicBezier3(Float3[] points)
		{
			BezierUtils.AssertPoints(points);

			buffer = points;
		}

		public Float3 Sample(float t) =>
			Tween.CubicBezier(buffer[0], buffer[1], buffer[2], buffer[3], t);

		public   Float3   Anchor1  => buffer[0];
		public   Float3   Control1 => buffer[1];
		public   Float3   Control2 => buffer[2];
		public   Float3   Anchor2  => buffer[3];
		
		readonly Float3[] buffer;
	}
}
