﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using CXUtils.Common;
#if CXUTILS_UNSAFE
using CXUtils.Debugging;
#endif

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     represents two floats
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Float2 : IVectorFloat<Float2>
	{
		public Float2(float x = .0f, float y = .0f) => (this.x, this.y) = (x, y);
		public Float2(Float2 other) => (x, y) = (other.x, other.y);

		public bool Equals(Float2 other) => x.Equals(other.x) && y.Equals(other.y);

		public float SqrMagnitude => x * x + y * y;
		public float Magnitude    => (float)Math.Sqrt(SqrMagnitude);

		public Float2 Normalized => Magnitude == 0f ? Zero : this / Magnitude;

		public Float2 Floor => new(x.Floor(), y.Floor());
		public Float2 Ceil  => new(x.Ceil(), y.Ceil());
		public Float2 Halve => this * .5f;
		public override bool Equals(object obj) => obj is Float2 other && Equals(other);
		public override int GetHashCode()
		{
			unchecked
			{
				return (x.GetHashCode() * 397) ^ y.GetHashCode();
			}
		}

		public static Float2 MinValue => (Float2)float.MinValue;
		public static Float2 MaxValue => (Float2)float.MaxValue;
		public static Float2 Epsilon  => (Float2)float.Epsilon;

		public static Float2 Zero    => (Float2)0f;
		public static Float2 One     => (Float2)1f;
		public static Float2 Half    => (Float2).5f;
		public static Float2 Quarter => (Float2).25f;

		public static Float2 UnitY    => new(y: 1f);
		public static Float2 NegUnitY => new(y: -1f);
		public static Float2 UnitX    => new(1f);
		public static Float2 NegUnitX => new(-1f);


		public float this[int index]
		{
			get
			{
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Assertion.AssertInvalid( index >= 0 && index < 2, nameof( index ), index, InvalidReason.ValueOutOfRange );
                    fixed ( float* ptr = &x )
                    {
                        return ptr[index];
                    }
                }
                #else
				switch (index)
				{
					case 0: return x;
					case 1: return y;

					default: throw new IndexOutOfRangeException();
				}
                #endif
			}
		}

		public float Sum     => x + y;
		public float MaxPart => x > y ? x : y;
		public float MinPart => x < y ? x : y;

		public Int2 FloorInt => new(x.FloorInt(), y.FloorInt());
		public Int2 CeilInt  => new(x.CeilInt(), y.CeilInt());

		[FieldOffset(0)] public readonly float x;
		[FieldOffset(4)] public readonly float y;

		#region Operator overloading

		public static Float2 operator +(Float2 a, Float2 b) => new(a.x + b.x, a.y + b.y);
		public static Float2 operator -(Float2 a, Float2 b) => new(a.x - b.x, a.y - b.y);
		public static Float2 operator *(Float2 a, Float2 b) => new(a.x * b.x, a.y * b.y);
		public static Float2 operator /(Float2 a, Float2 b) => new(a.x / b.x, a.y / b.y);

		public static Float2 operator *(Float2 a, float value) => new(a.x * value, a.y * value);
		public static Float2 operator /(Float2 a, float value) => new(a.x / value, a.y / value);
		public static Float2 operator *(float value, Float2 a) => new(a.x * value, a.y * value);
		public static Float2 operator /(float value, Float2 a) => new(a.x / value, a.y / value);

		public static Float2 operator -(Float2 a) => new(-a.x, -a.y);

		public static bool operator ==(Float2 a, Float2 b) => a.x.AlmostEqual(b.x) && a.y.AlmostEqual(b.y);
		public static bool operator !=(Float2 a, Float2 b) => !(a == b);

		public static explicit operator Float2(Float3 value) => new(value.x, value.y);
		public static explicit operator Float2(float value) => new(value, value);
		public static explicit operator Float2(Int2 value) => new(value.x, value.y);

		#endregion

		#region Utility

		/// <summary>
		///     Rotates Float2 using the specified < paramref name="angle" />
		/// </summary>
		public Float2 Rotate(float angle) => new(x * MathUtils.Cos(angle) - y * MathUtils.Sin(angle), x * MathUtils.Sin(angle) + y * MathUtils.Cos(angle));

		public float Dot(Float2 other) => x * other.x + y * other.y;

		/// <summary>
		///     unlike the cross product of a <see cref="Float3" />, this gives the z length
		/// </summary>
		public float Cross(Float2 other) => x * other.y - y * other.x;
		public Float2 Reflect(Float2 normal) => this - 2f * Dot(normal) * normal;

		public Float2 Min(Float2 other) => new(Math.Min(x, other.x), Math.Min(y, other.y));
		public Float2 Max(Float2 other) => new(Math.Max(x, other.x), Math.Max(y, other.y));

		/// <summary>
		///     returns a new Float2 with a direction of this and a specified target magnitude
		/// </summary>
		public Float2 AsMagnitude(float magnitude) => Normalized * magnitude;

		/// <summary>
		///     Returns the modified <see cref="Float2" /> by <paramref name="func" />
		/// </summary>
		public Float2 Apply(Func<float, float> func) => new(func(x), func(y));

		public Float2 OffsetX(float value) => new(x + value, y);
		public Float2 OffsetY(float value) => new(x, y + value);

		public Float2 WithX(float value) => new(value, y);
		public Float2 WithY(float value) => new(x, value);

		public override string ToString() =>
			$"({x.ToString(CultureInfo.InvariantCulture)}, {y.ToString(CultureInfo.InvariantCulture)})";
		public string ToString(string format) =>
			$"({x.ToString(format)}, {y.ToString(format)})";
		public string ToString(string format, IFormatProvider formatProvider) =>
			$"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";

		/// <summary>
		///     Calculates a Float2 using the specified <paramref name="angle" />
		/// </summary>
		public static Float2 FromAngle(float angle) => new(MathUtils.Cos(angle), MathUtils.Sin(angle));

		/// <summary>
		///     Calculates a Float2 using the specified <paramref name="angle" /> scaled with <paramref name="length" />
		/// </summary>
		public static Float2 FromAngle(float angle, float length) => new(MathUtils.Cos(angle) * length, MathUtils.Sin(angle) * length);

		#endregion
	}
}
