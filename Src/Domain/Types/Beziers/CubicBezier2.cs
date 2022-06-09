using CXUtils.Common;
using CXUtils.Utilities;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     A struct that represents a cubic bezier curve in 2D
	/// </summary>
	public readonly struct CubicBezier2
	{
		public CubicBezier2(Float2 anchor1, Float2 control1, Float2 control2, Float2 anchor2)
		{
			this.anchor1 = anchor1;
			this.control1 = control1;
			this.control2 = control2;
			this.anchor2 = anchor2;
		}

		public CubicBezier2(Float2[] points, int position = 0)
		{
			BezierUtils.AssertPointArrayLength(points, position);

			anchor1 = points[position + 0];
			control1 = points[position + 1];
			control2 = points[position + 2];
			anchor2 = points[position + 3];
		}

		public Float2 Sample(float t) =>
			Tween.CubicBezier(anchor1, control1, control2, anchor2, t);

		public readonly Float2 anchor1;
		public readonly Float2 control1;
		public readonly Float2 control2;
		public readonly Float2 anchor2;
	}
}
