using System;
using System.Globalization;
using System.Runtime.InteropServices;
using CXUtils.Common;
#if CXUTILS_UNSAFE
using System.Diagnostics;
#endif

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     represents three floats
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Float3 : IVectorFloat<Float3>
	{
		public Float3(float x = 0f, float y = 0f, float z = 0f) => (this.x, this.y, this.z) = (x, y, z);

		public Float3(Float3 other) => (x, y, z) = (other.x, other.y, other.z);

		public float SqrMagnitude => x * x + y * y + z * z;
		public float Magnitude    => (float)Math.Sqrt(SqrMagnitude);

		public Float3 Normalized => Magnitude == 0f ? Zero : this / Magnitude;

		public Float3 Floor => new(x.Floor(), y.Floor(), z.Floor());
		public Float3 Ceil  => new(x.Ceil(), y.Ceil(), z.Ceil());
		public Float3 Halve => this * .5f;

		public static Float3 MinValue => (Float3)float.MinValue;
		public static Float3 MaxValue => (Float3)float.MaxValue;
		public static Float3 Epsilon  => (Float3)float.Epsilon;

		public static Float3 Zero    => (Float3)0f;
		public static Float3 One     => (Float3)1f;
		public static Float3 Half    => (Float3).5f;
		public static Float3 Quarter => (Float3).25f;

		public static Float3 UnitY    => new(y: 1f);
		public static Float3 NegUnitY => new(y: -1f);
		public static Float3 UnitX    => new(1f);
		public static Float3 NegUnitX => new(-1f);
		public static Float3 UnitZ    => new(z: 1f);
		public static Float3 NegUnitZ => new(z: -1f);

		public float this[int index]
		{
			get
			{
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 3, nameof( index )+ " is out of range!");
                    fixed ( float* ptr = &x ) return ptr[index];
                }
                #else
				switch (index)
				{
					case 0:
						return x;
					case 1:
						return y;
					case 2:
						return z;

					default:
						throw new IndexOutOfRangeException();
				}
                #endif
			}
		}

		public float Sum => x + y + z;

		public float MaxPart
		{
			get
			{
				float max = x;
				if (max < y) max = y;
				if (max < z) max = z;
				return max;
			}
		}

		public float MinPart
		{
			get
			{
				float min = x;
				if (min > y) min = y;
				if (min > z) min = z;
				return min;
			}
		}

		public Float2 LeftFloat2  => new(x, y);
		public Float2 RightFloat2 => new(y, z);
		public Int3   FloorInt    => new(x.FloorInt(), y.FloorInt(), z.FloorInt());
		public Int3   CeilInt     => new(x.CeilInt(), y.CeilInt(), z.CeilInt());

		[FieldOffset(0)] public readonly float x;
		[FieldOffset(4)] public readonly float y;
		[FieldOffset(8)] public readonly float z;

		#region Operator overloading

		public static Float3 operator +(Float3 a, Float3 b) => new(a.x + b.x, a.y + b.y, a.z + b.z);
		public static Float3 operator -(Float3 a, Float3 b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
		public static Float3 operator *(Float3 a, Float3 b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
		public static Float3 operator /(Float3 a, Float3 b) => new(a.x / b.x, a.y / b.y, a.x / b.x);

		public static Float3 operator *(Float3 a, float value) => new(a.x * value, a.y * value, a.z * value);
		public static Float3 operator /(Float3 a, float value) => new(a.x / value, a.y / value, a.z / value);
		public static Float3 operator *(float value, Float3 a) => a * value;
		public static Float3 operator /(float value, Float3 a) => a / value;
		public static Float3 operator -(Float3 a) => new(-a.x, -a.y, -a.z);

		public static bool operator ==(Float3 a, Float3 b) => a.x.AlmostEqual(b.x) && a.y.AlmostEqual(b.y) && a.z.AlmostEqual(b.z);
		public static bool operator !=(Float3 a, Float3 b) => !(a == b);

		public static explicit operator Float3(float value) => new(value, value, value);
		public static explicit operator Float3(Int3 value) => new(value.x, value.y, value.z);
		public static implicit operator Float3(Float2 value) => new(value.x, value.y);

		#endregion

		#region Utility

		public bool Equals(Float3 other) => x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
		public Float3 Min(Float3 other) => new(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z));
		public Float3 Max(Float3 other) => new(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z));

		public override bool Equals(object obj) => obj is Float3 other && Equals(other);
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = x.GetHashCode();
				hashCode = (hashCode * 397) ^ y.GetHashCode();
				hashCode = (hashCode * 397) ^ z.GetHashCode();
				return hashCode;
			}
		}

		public float Dot(Float2 other) => x * other.x + y * other.y;
		public float Dot(Float3 other) => x * other.x + y * other.y + z * other.z;

		public Float3 Cross(Float3 other) => new(y * other.z - z * other.y, z * other.x - x * other.z, x * other.y - y * other.x);

		public Float3 Reflect(Float3 normal) => this - 2f * Dot(normal) * normal;

		public Float3 AsMagnitude(float magnitude) => Normalized * magnitude;
		public Float3 Apply(Func<float, float> func) => new(func(x), func(y), func(z));

		public Float3 OffsetX(float value) => new(x + value, y, z);
		public Float3 OffsetY(float value) => new(x, y + value, z);
		public Float3 OffsetZ(float value) => new(x, y, z + value);

		public Float3 AsX(float value) => new(value, y, z);
		public Float3 AsY(float value) => new(x, value, z);
		public Float3 AsZ(float value) => new(x, y, value);

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
		public override string ToString() =>
			$"({x.ToString(CultureInfo.InvariantCulture)}, {y.ToString(CultureInfo.InvariantCulture)}, {z.ToString(CultureInfo.InvariantCulture)})";
		public string ToString(string format) =>
			$"({x.ToString(format)}, {y.ToString(format)}, {z.ToString(format)})";

		#endregion
	}
}
