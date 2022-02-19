using CXUtils.Common;
using CXUtils.Utilities;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     A struct that represents a cubic bezier curve in 2D
	/// </summary>
	public readonly struct CubicBezier2
	{
		public CubicBezier2(Float2 control1, Float2 anchor1, Float2 control2, Float2 anchor2) =>
			buffer = new[] { anchor1, control1, control2, anchor2 };

		public CubicBezier2(Float2[] points)
		{
			BezierUtils.AssertPoints(points);

			buffer = points;
		}

		public Float2 Sample(float t) =>
			Tween.CubicBezier(buffer[0], buffer[1], buffer[2], buffer[3], t);

		public   Float2   Anchor1  => buffer[0];
		public   Float2   Control1 => buffer[1];
		public   Float2   Control2 => buffer[2];
		public   Float2   Anchor2  => buffer[3];
		
		readonly Float2[] buffer;
	}
}
