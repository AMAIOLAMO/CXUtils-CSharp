using CXUtils.Domain.Types;
using CXUtils.Mathematics;

namespace CXUtils.Common
{
	/// <summary>
	///     Represents the types for tweening
	/// </summary>
	public enum TweenType
	{
		InSine, OutSine, InOutSine, InQuad, OutQuad, InOutQuad,
		InCubic, OutCubic, InOutCubic, InExpo, OutExpo, InOutExpo,
		InCirc, OutCirc, InOutCirc, InBack, OutBack, InOutBack,
		InElastic, OutElastic, InOutElastic, InBounce, OutBounce, InOutBounce
	}

	/// <summary>
	///     A basic tweening library
	/// </summary>
	public static class Tween
	{
		#region Lerp

		// == FORWARD == //

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

		public static float LerpClamp(float a, float b, float t) => Lerp(a, b, MathUtils.Clamp01(t));

		/// <inheritdoc cref="Lerp(float, float, float)" />
		public static double Lerp(double a, double b, double t) => (b - a) * t + a;

		public static double LerpClamp(double a, double b, double t) => Lerp(a, b, MathUtils.Clamp01(t));

		/// <inheritdoc cref="Lerp(float, float, float)" />
		public static int Lerp(int a, int b, float t) => ((b - a) * t).FloorInt() + a;

		public static int LerpClamp(int a, int b, float t) => Lerp(a, b, MathUtils.Clamp01(t));

		// == INVERSE == //

		public static float InvLerp(float value, float a, float b) => -a / (b - a);

		#endregion

		#region Easing

		public static float EaseInSine(float t) => 1f - MathUtils.Cos(t * Constants.Pi * .5f);
		public static float EaseOutSine(float t) => MathUtils.Sin(t * Constants.Pi * .5f);
		public static float EaseInOutSine(float t) => -(MathUtils.Cos(Constants.Pi * t) - 1f) * .5f;

		public static float EaseInQuad(float t) => t * t;
		public static float EaseOutQuad(float t) => 1f - (1f - t) * (1f - t);
		public static float EaseInOutQuad(float t) => t < .5f ? 2f * t * t : 1f - MathUtils.Pow(-2f * t + 2f, 2f) * .5f;

		public static float EaseInCubic(float t) => t * t * t;
		public static float EaseOunCubic(float t) => 1 - (1f - t) * (1f - t) * (1f - t);
		public static float EaseInOutCubic(float t) => t < .5f ? 4f * t * t * t : 1f - MathUtils.Pow(-2f * t + 2f, 3f) * .5f;

		public static float EaseInExpo(float t) => t == 0f ? 0f : MathUtils.Pow(2f, 10f * t - 10f);
		public static float EaseOutExpo(float t) => t.AlmostEqual(1f) ? 1f : 1f - MathUtils.Pow(2f, -10f * t);
		public static float EaseInOutExpo(float t) => t == 0
			? 0f
			: t.AlmostEqual(1f)
				? 1f
				: t < .5f
					? MathUtils.Pow(2f, 20f * t - 10f) / 2f
					: (2f - MathUtils.Pow(2f, -20f * t + 10f)) / 2f;

		public static float EaseInCirc(float t) => 1f - MathUtils.Sqrt(1f - MathUtils.Pow(t, 2f));
		public static float EaseOutCirc(float t) => MathUtils.Sqrt(1f - MathUtils.Pow(t - 1f, 2f));
		public static float EaseInOutCirc(float t) => t < .5f
			? EaseInCirc(t) * .5f
			: (EaseOutCirc(t) + 1f) * .5f;

		const float BackC1 = 1.70158f;
		const float BackC2 = BackC1 * 1.525f;
		const float BackC3 = BackC1 + 1f;

		public static float EaseInBack(float t) => BackC3 * t * t * t - BackC1 * t * t;
		public static float EaseOutBack(float t) => 1f + BackC3 * MathUtils.Pow(t - 1f, 3f) + BackC1 * MathUtils.Pow(t - 1f, 2f);
		public static float EaseInOutBack(float t) => t < .5f
			? MathUtils.Pow(2f * t, 2f) * ((BackC2 + 1f) * 2f * t - BackC2) * .5f
			: (MathUtils.Pow(2f * t - 2f, 2f) * ((BackC2 + 1f) * (t * 2f - 2f) + BackC2) + 2f) * .5f;

		const float ElasticC1 = 2f * Constants.Pi / 3f;
		const float ElasticC2 = 2f * Constants.Pi / 4.5f;

		public static float EaseInElastic(float t) => t == 0f
			? 0f
			: t.AlmostEqual(1f)
				? 1f
				: -MathUtils.Pow(2f, 10f * t - 10f) * MathUtils.Sin((t * 10f - 10.75f) * ElasticC1);
		public static float EaseOutElastic(float t) => t == 0f
			? 0f
			: t.AlmostEqual(1f)
				? 1f
				: MathUtils.Pow(2f, -10f * t) * MathUtils.Sin((t * 10f - .75f) * ElasticC1) + 1f;
		public static float EaseInOutElastic(float t) => t == 0f
			? 0f
			: t.AlmostEqual(1f)
				? 1f
				: t < .5f
					? (float)(-(MathUtils.Pow(2f, 20f * t - 10f) * MathUtils.Sin((20f * t - 11.125f) * ElasticC2)) * .5)
					: (float)(MathUtils.Pow(2f, -20f * t + 10f) * MathUtils.Sin((20f * t - 11.125f) * ElasticC2) * .5 + 1f);

		const float BounceB1 = 7.5625f,
			BounceD1         = 2.75f;

		public static float EaseInBounce(float t) => 1f - EaseOutBounce(1f - t);
		public static float EaseOutBounce(float t)
		{
			if (t < 1f / BounceD1)
				return BounceB1 * t * t;
			if (t < 2f / BounceD1)
				return BounceB1 * (t -= 1.5f / BounceD1) * t + 0.75f;
			if (t < 2.5f / BounceD1)
				return BounceB1 * (t -= 2.25f / BounceD1) * t + 0.9375f;

			return BounceB1 * (t -= 2.625f / BounceD1) * t + 0.984375f;
		}
		public static float EaseInOutBounce(float t) => t < .5f
			? (1f - EaseOutBounce(1f - 2f * t)) * .5f
			: (1f + EaseOutBounce(2f * t - 1f)) * .5f;

		#region EasingTypeEvaluation

		public static float Ease(float t, TweenType type)
		{
			switch (type)
			{
				case TweenType.InSine:    return EaseInSine(t);
				case TweenType.OutSine:   return EaseOutSine(t);
				case TweenType.InOutSine: return EaseInOutSine(t);

				case TweenType.InQuad:    return EaseInQuad(t);
				case TweenType.OutQuad:   return EaseInQuad(t);
				case TweenType.InOutQuad: return EaseInQuad(t);

				case TweenType.InCubic:    return EaseInCubic(t);
				case TweenType.OutCubic:   return EaseInCubic(t);
				case TweenType.InOutCubic: return EaseInCubic(t);

				case TweenType.InExpo:    return EaseInExpo(t);
				case TweenType.OutExpo:   return EaseOutExpo(t);
				case TweenType.InOutExpo: return EaseInOutExpo(t);

				case TweenType.InCirc:    return EaseInCirc(t);
				case TweenType.OutCirc:   return EaseOutCirc(t);
				case TweenType.InOutCirc: return EaseInOutCirc(t);

				case TweenType.InBack:    return EaseInBack(t);
				case TweenType.OutBack:   return EaseOutBack(t);
				case TweenType.InOutBack: return EaseInOutBack(t);

				case TweenType.InElastic:    return EaseInElastic(t);
				case TweenType.OutElastic:   return EaseOutElastic(t);
				case TweenType.InOutElastic: return EaseInOutElastic(t);

				case TweenType.InBounce:    return EaseInBounce(t);
				case TweenType.OutBounce:   return EaseOutBounce(t);
				case TweenType.InOutBounce: return EaseInOutBounce(t);

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

		#region Lerp Vectors

		public static Float2 Lerp(this Float2 a, Float2 b, float t) => new Float2(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t));

		public static Float2 LerpClamp(this Float2 a, Float2 b, float t) => new Float2(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t));

		public static Float3 Lerp(this Float3 a, Float3 b, float t) => new Float3(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t));

		public static Float3 LerpClamp(this Float3 a, Float3 b, float t) => new Float3(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t), LerpClamp(a.z, b.z, t));

		public static Float4 Lerp(this Float4 a, Float4 b, float t) => new Float4(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t), Lerp(a.w, b.w, t));

		public static Float4 LerpClamp(this Float4 a, Float4 b, float t) => new Float4(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t), LerpClamp(a.z, b.z, t), LerpClamp(a.w, b.w, t));


		public static Int2 Lerp(this Int2 a, Int2 b, float t) => new Int2(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t));

		public static Int2 LerpClamp(this Int2 a, Int2 b, float t) => new Int2(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t));

		public static Int3 Lerp(this Int3 a, Int3 b, float t) => new Int3(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t));

		public static Int3 LerpClamp(this Int3 a, Int3 b, float t) => new Int3(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t), LerpClamp(a.z, b.z, t));

		public static Int4 Lerp(this Int4 a, Int4 b, float t) => new Int4(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t), Lerp(a.w, b.w, t));

		public static Int4 LerpClamp(this Int4 a, Int4 b, float t) => new Int4(LerpClamp(a.x, b.x, t), LerpClamp(a.y, b.y, t), LerpClamp(a.z, b.z, t), LerpClamp(a.w, b.w, t));

		#endregion
	}
}
