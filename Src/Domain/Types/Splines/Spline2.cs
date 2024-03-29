﻿using System.Collections.Generic;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     A class that handles all spline calculations
	/// </summary>
	public sealed class Spline2 : SplineBase<Float2>
	{
		public Spline2(List<Float2> points, bool isLoop = false) : base(points, isLoop) { }

		public Spline2(Float2 center, bool isLoop = false)
		{
			points.Add(center + Float2.NegUnitX);
			points.Add(center + (Float2.NegUnitX + Float2.UnitY).Halve);
			points.Add(center + (Float2.UnitX + Float2.NegUnitY).Halve);
			points.Add(center + Float2.UnitX);

			SetLoop(isLoop);
		}

		public CubicBezier2 GetSegment(int i) => new CubicBezier2(GetSegmentRaw(i));

		public override void PushAnchor(Float2 newAnchor)
		{
			Float2 newControlPoint = (points[points.Count - 1] + newAnchor).Halve; // the new anchor's new control point
			
			points.Add(points[points.Count - 1] * 2f - points[points.Count - 2]); // last control point's other side control point
			points.Add(newControlPoint);
			points.Add(newAnchor);
		}

		/// <summary>
		///     Moves a point in the spline but move the controls also
		/// </summary>
		public void MoveDynamic(int pointIndex, Float2 position)
		{
			Float2 delta = position - points[pointIndex];
			points[pointIndex] = position;

			if (SplineUtils.IsAnchor(pointIndex))
			{
				if (pointIndex + 1 < points.Count || IsLoop) points[LoopIndex(pointIndex + 1)] += delta;
				if (pointIndex - 1 >= 0 || IsLoop) points[LoopIndex(pointIndex - 1)] += delta;
			}
			else
			{
				bool nextAnchor = SplineUtils.IsAnchor(pointIndex + 1);

				int mirroredControlIndex = nextAnchor ? pointIndex + 2 : pointIndex - 2;
				int anchorIndex = nextAnchor ? pointIndex + 1 : pointIndex - 1;

				if ((mirroredControlIndex < 0 || mirroredControlIndex >= points.Count) && !IsLoop) return;

				(anchorIndex, mirroredControlIndex) = (LoopIndex(anchorIndex), LoopIndex(mirroredControlIndex));

				float originalDistance = (points[anchorIndex] - points[mirroredControlIndex]).Magnitude;
				Float2 direction = (points[anchorIndex] - position).Normalized;

				points[mirroredControlIndex] = points[anchorIndex] + direction * originalDistance;
			}
		}

		public override void InsertAnchor(Float2 anchor, int segmentIndex) =>
			points.InsertRange(segmentIndex * 3 + 2, new[] { anchor + Float2.NegUnitX, anchor, anchor + Float2.UnitX });

		protected override void DoLoopChanged()
		{
			if (IsLoop)
			{
				points.Add(points[points.Count - 1] * 2f - points[points.Count - 2]); // last control point's other side control point
				points.Add(points[0] * 2f - points[1]); // first control point's other side control point
				return;
			}

			//remove the last two control points (which is the loop control point)
			points.RemoveRange(points.Count - 2, 2);
		}
	}
}
