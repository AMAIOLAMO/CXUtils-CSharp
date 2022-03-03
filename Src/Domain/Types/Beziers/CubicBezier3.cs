﻿using CXUtils.Common;
using CXUtils.Utilities;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     A struct that represents a cubic bezier curve in 2D
	/// </summary>
	public readonly struct CubicBezier3
	{
		public CubicBezier3(Float3 control1, Float3 anchor1, Float3 control2, Float3 anchor2)
		{
			this.control1 = control1;
			this.anchor1 = anchor1;
			this.control2 = control2;
			this.anchor2 = anchor2;
		}

		public CubicBezier3(Float3[] points)
		{
			BezierUtils.AssertPoints(points);

			anchor1 = points[0];
			control1 = points[1];
			control2 = points[2];
			anchor2 = points[3];
		}

		public Float3 Sample(float t) =>
			Tween.CubicBezier(anchor1, control1, control2, anchor2, t);

		public readonly Float3 anchor1;
		public readonly Float3 control1;
		public readonly Float3 control2;
		public readonly Float3 anchor2;
	}
}
