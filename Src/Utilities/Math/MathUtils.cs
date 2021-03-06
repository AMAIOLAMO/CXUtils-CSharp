using System;

namespace CXUtils.Common
{
	/// <summary>
	///     Math Function Class
	/// </summary>
	public static class MathUtils
	{
		#region Extensions

		public static float Floor(this float value)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Floor(value);
            #else
            return FloorInt( value );
            #endif
		}

		public static float Ceil(this float value)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Ceiling(value);
            #else
            return CeilInt( value );
            #endif
		}

		public static int FloorInt(this float value)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return (int)value.Floor();
            #else
            int valueInt = (int)value;

            return value < valueInt ? valueInt - 1 : valueInt;
            #endif
		}

		public static int CeilInt(this float value)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return (int)value.Ceil();
            #else
            int valueInt = (int)value;

            return value > valueInt ? valueInt + 1 : valueInt;
            #endif
		}

		public static bool AlmostEqual(this float value, float other = 0f, float relativeTolerance = 1e-09f, float absoluteTolerance = 0f) =>
			Math.Abs(value - other) <= Math.Max(relativeTolerance * Math.Max(Math.Abs(value), Math.Abs(other)), absoluteTolerance);
		public static bool AlmostEqual(this double value, double other = 0d, float relativeTolerance = 1e-09f, float absoluteTolerance = 0f) =>
			Math.Abs(value - other) <= Math.Max(relativeTolerance * Math.Max(Math.Abs(value), Math.Abs(other)), absoluteTolerance);

		/// <summary>
		///     This will loop the <paramref name="value" /> back to 0, when <paramref name="value" /> is an integer
		/// </summary>
		public static float Frac(this float value) => value - Floor(value);

		/// <inheritdoc cref="Frac(float)" />
		public static double Frac(this double value) => value - Math.Floor(value);

		/// <summary>
		///     Loops the <paramref name="value" /> back to 0 when <paramref name="value" />
		///     is a multiple of <paramref name="amount" />
		/// </summary>
		public static float Loop(this float value, float amount) => value - Floor(value / amount) * amount;

		/// <inheritdoc cref="Loop(float, float)" />
		public static int Loop(this int value, int amount) => value % amount;

		/// <inheritdoc cref="Loop(float, float)" />
		public static double Loop(this double value, double amount) => value - Math.Floor(value / amount) * amount;

		public static float Step(this float value) => Floor(value);
		public static float Step(this float value, float stepSize) => Floor(value / stepSize);
		#endregion

		#region Math Methods

		public static float Cos(float angle)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Cos(angle);
            #else
            return (float)Math.Cos( angle );
            #endif
		}

		public static float Acos(float angle)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Acos(angle);
            #else
            return (float)Math.Acos( angle );
            #endif
		}

		public static float Sin(float angle)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Sin(angle);
            #else
            return (float)Math.Sin( angle );
            #endif
		}

		public static float Asin(float angle)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Asin(angle);
            #else
            return (float)Math.Asin( angle );
            #endif
		}

        #if NETCOREAPP2_0_OR_GREATER
		
		public static float Acosh(float angle) => MathF.Acosh(angle);
		public static float Asinh(float angle) => MathF.Asinh(angle);
		public static float ATanh(float angle) => MathF.Atanh(angle);
		
        #endif

		public static float Tan(float angle)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Tan(angle);
            #else
            return (float)Math.Tan( angle );
            #endif
		}

		public static float ATan(float angle)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Atan(angle);
            #else
            return (float)Math.Atan( angle );
            #endif
		}

		public static float Atan2(float y, float x)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Atan2(y, x);
            #else
            return (float)Math.Atan2( y, x );
            #endif
		}

		public static float CopySign(float value, float sign)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.CopySign(value, sign);
            #else
            return Math.Abs( value ) * Math.Sign( sign );
            #endif
		}

		public static float Sqrt(float value)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Sqrt(value);
            #else
            return (float)Math.Sqrt( value );
            #endif
		}

		public static float Pow(float value, float power)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Pow(value, power);
            #else
            return (float)Math.Pow( value, power );
            #endif
		}

		public static float Log(float a, float newBase)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Log(a, newBase);
            #else
            return (float)Math.Log( a, newBase );
            #endif
		}

		public static float Log10(float a)
		{
            #if NETCOREAPP2_0_OR_GREATER
			return MathF.Log10(a);
            #else
            return (float)Math.Log10( a );
            #endif
		}

		#endregion

		#region Range

		/// <summary>
		///     Remaps the given value from the given range to the another given range <br />
		///     NOTE: If values overflow, it will cause unexpected behaviour
		/// </summary>
		public static float Remap(float value, float inMin, float inMax, float outMin, float outMax) =>
			(value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

		/// <inheritdoc cref="Remap(float,float,float,float,float)" />
		public static double Remap(double value, double inMin, double inMax, double outMin, double outMax) =>
			(value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

		/// <inheritdoc cref="Remap(float,float,float,float,float)" />
		public static int Remap(int value, int inMin, int inMax, int outMin, int outMax) =>
			(value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

		/// <summary>
		///     Remaps the given value from the given range to the another given range and also clamp the value
		/// </summary>
		public static float RemapClamp(float value, float inMin, float inMax, float outMin, float outMax) =>
			Remap(Clamp(value, inMin, inMax), inMin, inMax, outMin, outMax);
		
		/// <inheritdoc cref="RemapClamp(float,float,float,float,float)"/>
		public static double RemapClamp(double value, double inMin, double inMax, double outMin, double outMax) =>
			Remap(Clamp(value, inMin, inMax), inMin, inMax, outMin, outMax);
		
		/// <inheritdoc cref="RemapClamp(float,float,float,float,float)"/>
		public static int RemapClamp(int value, int inMin, int inMax, int outMin, int outMax) =>
			Remap(Clamp(value, inMin, inMax), inMin, inMax, outMin, outMax);

		/// <summary>
		///     Remaps the given value from Polar(-1 ~ 1) to Unit(0 ~ 1)
		/// </summary>
		public static float RemapPolarToUnit(float value) => value * .5f + .5f;
		public static double RemapPolarToUnit(double value) => value * .5f + .5f;

		/// <summary>
		///     Remaps the given value from Unit(0 ~ 1) to some output
		/// </summary>
		public static float RemapUnit(float value, float outMin, float outMax) => value * (outMax - outMin) + outMin;
		public static double RemapUnit(double value, double outMin, double outMax) => value * (outMax - outMin) + outMin;

		public static float Clamp(float value, float min, float max) =>
			value < min ? min : value > max ? max : value;
		public static double Clamp(double value, double min, double max) =>
			value < min ? min : value > max ? max : value;
		public static int Clamp(int value, int min, int max) =>
			value < min ? min : value > max ? max : value;

		public static float ClampUnit(float value) =>
			Clamp(value, 0f, 1f);
		public static double ClampUnit(double value) =>
			Clamp(value, 0d, 1d);

		#endregion

		#region Useful Methods

		public static float RoundedStep(float value, float step) =>
			MathF.Round(value / step) * step;
		public static double RoundedStep(double value, double step) =>
			Math.Round(value / step) * step;


		#endregion
	}
}
