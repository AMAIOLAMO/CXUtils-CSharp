using System;
using CXUtils.Domain.Types;
using CXUtils.Mathematics;

namespace CXUtils.Common
{
	/// <summary>
	///     Represents the types for tweening
	/// </summary>
	public enum TweenType
	{
		InSine,    OutSine,    InOutSine,    InQuad,   OutQuad,   InOutQuad,
		InCubic,   OutCubic,   InOutCubic,   InExpo,   OutExpo,   InOutExpo,
		InCirc,    OutCirc,    InOutCirc,    InBack,   OutBack,   InOutBack,
		InElastic, OutElastic, InOutElastic, InBounce, OutBounce, InOutBounce
	}

	/// <summary>
	///     A basic tweening library
	/// </summary>
	public static class Tween
	{
		#region Interpolation

		#region Linear Interpolation

		/// <summary>
		///     linear interpolates between <paramref name="a" /> and <paramref name="b" /> using <paramref name="t" /> <br />
		///     NOTE: This is not clamped
		/// </summary>
		/// <param name="a">initial value</param>
		/// <param name="b">destination value</param>
		/// <param name="t">
		///     the percentage between (0 ~ 1) that interpolates <paramref name="a" /> and <paramref name="b" />
		/// </param>
		public static float Lerp(float a, float b, float t) => (b - a) * t + a;

		public static float LerpClamp(float a, float b, float t) => Lerp(a, b, MathUtils.ClampUnit(t));

		/// <inheritdoc cref="Lerp(float, float, float)" />
		public static double Lerp(double a, double b, double t) => (b - a) * t + a;

		public static double LerpClamp(double a, double b, double t) => Lerp(a, b, MathUtils.ClampUnit(t));

		#endregion

		#region Inverse Linear Interpolation

		/// <summary>
		///     Returns the unclamped percentage between <paramref name="a" /> and <paramref name="b" /> by
		///     <paramref name="t" />
		///     NOTE: the result value is not clamped
		/// </summary>
		public static float InverseLerp(float a, float b, float t) => (t - a) / (b - a);

		/// <summary>
		///     Returns the clamped percentage between <paramref name="a" /> and <paramref name="b" /> by <paramref name="t" />
		/// </summary>
		public static float InverseLerpClamp(float a, float b, float t) =>
			InverseLerp(a, b, MathUtils.Clamp(t, a, b));

		/// <inheritdoc cref="InverseLerp(float,float,float)" />
		public static double InverseLerp(double a, double b, double t) => (t - a) / (b - a);

		/// <inheritdoc cref="InverseLerpClamp(float,float,float)" />
		public static double InverseLerpClamp(double a, double b, double t) =>
			InverseLerp(a, b, MathUtils.Clamp(t, a, b));

		#endregion

		#region Multiplicative Linear Interpolation

		public static float Eerp(float a, float b, float t) =>
			MathUtils.Pow(a, 1f - t) * MathUtils.Pow(b, t);

		public static float EerpClamp(float a, float b, float t) =>
			Eerp(a, b, MathUtils.ClampUnit(t));

		public static double Eerp(double a, double b, double t) =>
			Math.Pow(a, 1f - t) * Math.Pow(b, t);

		public static double EerpClamp(double a, double b, double t) =>
			Eerp(a, b, MathUtils.ClampUnit(t));

		#endregion

		#endregion

		#region Easing

		const float BACK_C1 = 1.70158f;
		const float BACK_C3 = BACK_C1 + 1f;
		const float BACK_C2 = BACK_C1 * 1.525f;

		const float ELASTIC_C1 = 2f * Constants.PI / 3f;
		const float ELASTIC_C2 = 2f * Constants.PI / 4.5f;

		const float BOUNCE_B1 = 7.5625f,
			BOUNCE_D1         = 2.75f;

		public static class In
		{
			public static float Sine(float t) => 1f - MathUtils.Cos(t * Constants.PI * .5f);
			public static float Quad(float t) => t * t;
			public static float Cubic(float t) => t * t * t;
			public static float Expo(float t) => t == 0f ? 0f : MathUtils.Pow(2f, 10f * t - 10f);
			public static float Circ(float t) => 1f - MathUtils.Sqrt(1f - MathUtils.Pow(t, 2f));
			public static float Back(float t) => BACK_C3 * t * t * t - BACK_C1 * t * t;

			public static float Elastic(float t) => t == 0f
				? 0f
				: t.AlmostEqual(1f)
					? 1f
					: -MathUtils.Pow(2f, 10f * t - 10f) * MathUtils.Sin((t * 10f - 10.75f) * ELASTIC_C1);

			public static float Bounce(float t) => 1f - Out.Bounce(1f - t);
		}

		public static class Out
		{
			public static float Sine(float t) => MathUtils.Sin(t * Constants.PI * .5f);
			public static float Quad(float t) => 1f - (1f - t) * (1f - t);
			public static float Cubic(float t) => 1 - (1f - t) * (1f - t) * (1f - t);
			public static float Expo(float t) => t.AlmostEqual(1f) ? 1f : 1f - MathUtils.Pow(2f, -10f * t);
			public static float Circ(float t) => MathUtils.Sqrt(1f - MathUtils.Pow(t - 1f, 2f));
			public static float Back(float t) => 1f + BACK_C3 * MathUtils.Pow(t - 1f, 3f) + BACK_C1 * MathUtils.Pow(t - 1f, 2f);

			public static float Elastic(float t) => t == 0f
				? 0f
				: t.AlmostEqual(1f)
					? 1f
					: MathUtils.Pow(2f, -10f * t) * MathUtils.Sin((t * 10f - .75f) * ELASTIC_C1) + 1f;

			public static float Bounce(float t)
			{
				if (t < 1f / BOUNCE_D1)
					return BOUNCE_B1 * t * t;
				if (t < 2f / BOUNCE_D1)
					return BOUNCE_B1 * (t -= 1.5f / BOUNCE_D1) * t + 0.75f;
				if (t < 2.5f / BOUNCE_D1)
					return BOUNCE_B1 * (t -= 2.25f / BOUNCE_D1) * t + 0.9375f;

				return BOUNCE_B1 * (t -= 2.625f / BOUNCE_D1) * t + 0.984375f;
			}
		}

		public static class InOut
		{
			public static float Sine(float t) => -(MathUtils.Cos(Constants.PI * t) - 1f) * .5f;

			public static float Quad(float t) => t < .5f ? 2f * t * t : 1f - MathUtils.Pow(-2f * t + 2f, 2f) * .5f;


			public static float Cubic(float t) => t < .5f ? 4f * t * t * t : 1f - MathUtils.Pow(-2f * t + 2f, 3f) * .5f;


			public static float Expo(float t) => t == 0
				? 0f
				: t.AlmostEqual(1f)
					? 1f
					: t < .5f
						? MathUtils.Pow(2f, 20f * t - 10f) / 2f
						: (2f - MathUtils.Pow(2f, -20f * t + 10f)) / 2f;


			public static float Circ(float t) => t < .5f
				? In.Circ(t) * .5f
				: (Out.Circ(t) + 1f) * .5f;


			public static float Back(float t) => t < .5f
				? MathUtils.Pow(2f * t, 2f) * ((BACK_C2 + 1f) * 2f * t - BACK_C2) * .5f
				: (MathUtils.Pow(2f * t - 2f, 2f) * ((BACK_C2 + 1f) * (t * 2f - 2f) + BACK_C2) + 2f) * .5f;


			public static float Elastic(float t) => t == 0f
				? 0f
				: t.AlmostEqual(1f)
					? 1f
					: t < .5f
						? (float)(-(MathUtils.Pow(2f, 20f * t - 10f) * MathUtils.Sin((20f * t - 11.125f) * ELASTIC_C2)) * .5)
						: (float)(MathUtils.Pow(2f, -20f * t + 10f) * MathUtils.Sin((20f * t - 11.125f) * ELASTIC_C2) * .5 + 1f);


			public static float Bounce(float t) => t < .5f
				? (1f - Out.Bounce(1f - 2f * t)) * .5f
				: (1f + Out.Bounce(2f * t - 1f)) * .5f;
		}


		#region EasingTypeEvaluation

		public static float Ease(float t, TweenType type)
		{
			switch (type)
			{
				case TweenType.InSine:    return In.Sine(t);
				case TweenType.OutSine:   return Out.Sine(t);
				case TweenType.InOutSine: return InOut.Sine(t);

				case TweenType.InQuad:    return In.Quad(t);
				case TweenType.OutQuad:   return Out.Quad(t);
				case TweenType.InOutQuad: return InOut.Quad(t);

				case TweenType.InCubic:    return In.Cubic(t);
				case TweenType.OutCubic:   return Out.Cubic(t);
				case TweenType.InOutCubic: return InOut.Cubic(t);

				case TweenType.InExpo:    return In.Expo(t);
				case TweenType.OutExpo:   return Out.Expo(t);
				case TweenType.InOutExpo: return InOut.Expo(t);

				case TweenType.InCirc:    return In.Circ(t);
				case TweenType.OutCirc:   return Out.Circ(t);
				case TweenType.InOutCirc: return InOut.Circ(t);

				case TweenType.InBack:    return In.Back(t);
				case TweenType.OutBack:   return Out.Back(t);
				case TweenType.InOutBack: return InOut.Back(t);

				case TweenType.InElastic:    return In.Elastic(t);
				case TweenType.OutElastic:   return Out.Elastic(t);
				case TweenType.InOutElastic: return InOut.Elastic(t);

				case TweenType.InBounce:    return In.Bounce(t);
				case TweenType.OutBounce:   return Out.Bounce(t);
				case TweenType.InOutBounce: return InOut.Bounce(t);

				default: throw ExceptionUtils.NotAccessible;
			}
		}

		#endregion

		#endregion

		#region BezierCurves

		public static Float2 QuadBezier(Float2 p0, Float2 p1, Float2 p2, float t)
		{
			float inverse = 1f - t;

			return inverse * inverse * p0 + 2f * inverse * t * p1 + t * t * p2;
		}

		public static Float3 QuadBezier(Float3 p0, Float3 p1, Float3 p2, float t)
		{
			float inverse = 1f - t;

			return inverse * inverse * p0 + 2f * inverse * t * p1 + t * t * p2;
		}

		public static Float2 CubicBezier(Float2 p0, Float2 p1, Float2 p2, Float2 p3, float t)
		{
			float inverse = 1f - t;

			return inverse * inverse * inverse * p0 + 3f * inverse * inverse * t * p1 + 3 * inverse * t * t * p2 + t * t * t * p3;
		}

		public static Float3 CubicBezier(Float3 p0, Float3 p1, Float3 p2, Float3 p3, float t)
		{
			float inverse = 1f - t;

			return inverse * inverse * inverse * p0 + 3f * inverse * inverse * t * p1 + 3 * inverse * t * t * p2 + t * t * t * p3;
		}

		#endregion

		#region Interpolate Vectors

		#region Linear Interpolation

		public static Float2 Lerp(this Float2 a, Float2 b, float t) =>
			new(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t));

		public static Float2 LerpClamp(this Float2 a, Float2 b, float t) =>
			new(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t));

		public static Float3 Lerp(this Float3 a, Float3 b, float t) =>
			new(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t));

		public static Float3 LerpClamp(this Float3 a, Float3 b, float t) =>
			new(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t), LerpClamp(a.z, b.z, t));

		public static Float4 Lerp(this Float4 a, Float4 b, float t) =>
			new(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t), Lerp(a.w, b.w, t));

		public static Float4 LerpClamp(this Float4 a, Float4 b, float t) =>
			new(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t), LerpClamp(a.z, b.z, t), LerpClamp(a.w, b.w, t));

		#endregion

		#region Inverse Linear Interpolation

		public static Float2 InverseLerp(this Float2 a, Float2 b, float t) =>
			new(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t));

		public static Float2 InverseLerpClamp(this Float2 a, Float2 b, float t) =>
			new(InverseLerpClamp(a.x, b.x, t), InverseLerpClamp(a.y, b.y, t));

		public static Float3 InverseLerp(this Float3 a, Float3 b, float t) =>
			new(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t), InverseLerp(a.z, b.z, t));

		public static Float3 InverseLerpClamp(this Float3 a, Float3 b, float t) =>
			new(InverseLerpClamp(a.x, b.x, t), InverseLerpClamp(a.y, b.y, t), InverseLerpClamp(a.z, b.z, t));

		public static Float4 InverseLerp(this Float4 a, Float4 b, float t) =>
			new(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t), InverseLerp(a.z, b.z, t), InverseLerp(a.w, b.w, t));

		public static Float4 InverseLerpClamp(this Float4 a, Float4 b, float t) =>
			new(InverseLerpClamp(a.x, b.x, t), InverseLerpClamp(a.y, b.y, t), InverseLerpClamp(a.z, b.z, t), InverseLerpClamp(a.w, b.w, t));

		#endregion

		#region Multiplicative Linear Interpolation

		public static Float2 Eerp(this Float2 a, Float2 b, float t) =>
			new(Eerp(a.x, b.x, t), Eerp(a.y, b.y, t));

		public static Float2 EerpClamp(this Float2 a, Float2 b, float t) =>
			new(EerpClamp(a.x, b.x, t), EerpClamp(a.y, b.y, t));

		public static Float3 Eerp(this Float3 a, Float3 b, float t) =>
			new(Eerp(a.x, b.x, t), Eerp(a.y, b.y, t), Eerp(a.z, b.z, t));

		public static Float3 EerpClamp(this Float3 a, Float3 b, float t) =>
			new(EerpClamp(a.x, b.x, t), EerpClamp(a.y, b.y, t), EerpClamp(a.z, b.z, t));

		public static Float4 Eerp(this Float4 a, Float4 b, float t) =>
			new(Eerp(a.x, b.x, t), Eerp(a.y, b.y, t), Eerp(a.z, b.z, t), Eerp(a.w, b.w, t));

		public static Float4 EerpClamp(this Float4 a, Float4 b, float t) =>
			new(EerpClamp(a.x, b.x, t), EerpClamp(a.y, b.y, t), EerpClamp(a.z, b.z, t), EerpClamp(a.w, b.w, t));

		#endregion

		#endregion
	}
}
