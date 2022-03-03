using System;
using System.Runtime.InteropServices;
using CXUtils.Common;
#if CXUTILS_UNSAFE
using System.Diagnostics;
#endif

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     represents four floats
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Float4 : IVectorFloat<Float4>
	{
		public Float4(float x = .0f, float y = .0f, float z = .0f, float w = .0f) => (this.x, this.y, this.z, this.w) = (x, y, z, w);
		public Float4(Float4 other) => (x, y, z, w) = (other.x, other.y, other.z, other.w);

		public float this[int index]
		{
			get
			{
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 4, nameof( index )+ " is out of range!");
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
					case 3:
						return w;

					default:
						throw new IndexOutOfRangeException();
				}
                #endif
			}
		}

		public static Float4 MinValue => (Float4)float.MinValue;
		public static Float4 MaxValue => (Float4)float.MaxValue;
		public static Float4 Epsilon  => (Float4)float.Epsilon;

		public static Float4 Zero    => (Float4)0f;
		public static Float4 One     => (Float4)1f;
		public static Float4 Half    => (Float4).5f;
		public static Float4 Quarter => (Float4).25f;

		public static Float4 UnitY    => new Float4(y: 1f);
		public static Float4 NegUnitY => new Float4(y: -1f);
		public static Float4 UnitX    => new Float4(1f);
		public static Float4 NegUnitX => new Float4(-1f);
		public static Float4 UnitZ    => new Float4(z: 1f);
		public static Float4 NegUnitZ => new Float4(z: -1f);
		public static Float4 UnitW    => new Float4(w: 1f);
		public static Float4 NegUnitW => new Float4(w: -1f);

		public Int4 FloorInt => new Int4(x.FloorInt(), y.FloorInt(), z.FloorInt(), w.FloorInt());
		public Int4 CeilInt  => new Int4(x.CeilInt(), y.CeilInt(), z.CeilInt(), w.CeilInt());

		public Float4 Floor => new Float4(x.Floor(), y.Floor(), z.Floor(), w.Floor());
		public Float4 Ceil  => new Float4(x.Ceil(), y.Ceil(), z.Ceil(), w.Floor());
		public Float4 Halve => this * .5f;

		public float Sum => x + y + z + w;

		public float MaxPart => x > y ? x > z ? x > w ? x : w :
			z > w ? z : w :
			y > z ? y > w ? y : w :
			z > w ? z : w;

		public float MinPart => x < y ? x < z ? x < w ? x : w :
			z < w ? z : w :
			y < z ? y < w ? y : w :
			z < w ? z : w;

		public float SqrMagnitude => x * x + y * y + z * z;
		public float Magnitude    => (float)Math.Sqrt(SqrMagnitude);

		public Float4 Normalized => Magnitude == 0f ? Zero : this / Magnitude;

		[FieldOffset(12)] public readonly float w;
		[FieldOffset(0)]  public readonly float x;
		[FieldOffset(4)]  public readonly float y;
		[FieldOffset(8)]  public readonly float z;

		#region Operator overloading

		public static Float4 operator +(Float4 a, Float4 b) => new Float4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		public static Float4 operator -(Float4 a, Float4 b) => new Float4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		public static Float4 operator *(Float4 a, Float4 b) => new Float4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		public static Float4 operator /(Float4 a, Float4 b) => new Float4(a.x / b.x, a.y / b.y, a.x / b.x, a.w / b.w);
		public static Float4 operator *(Float4 a, float value) => new Float4(a.x * value, a.y * value, a.z * value, a.w * value);
		public static Float4 operator /(Float4 a, float value) => new Float4(a.x / value, a.y / value, a.z / value, a.w / value);
		public static Float4 operator *(float value, Float4 a) => a * value;
		public static Float4 operator /(float value, Float4 a) => a / value;
		public static Float4 operator -(Float4 a) => new Float4(-a.x, -a.y, -a.z, -a.w);

		public static bool operator ==(Float4 a, Float4 b) => a.x.AlmostEqual(b.x) && a.y.AlmostEqual(b.y) && a.z.AlmostEqual(b.z) && a.w.AlmostEqual(b.w);
		public static bool operator !=(Float4 a, Float4 b) => !(a == b);

		public static explicit operator Float4(float value) => new Float4(value, value, value, value);
		public static implicit operator Float4(Float3 value) => new Float4(value.x, value.y, value.z);
		public static implicit operator Float4(Float2 value) => new Float4(value.x, value.y);

		#endregion

		#region Utility

		public Float4 Min(Float4 other) => new Float4(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z), Math.Min(w, other.w));
		public Float4 Max(Float4 other) => new Float4(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z), Math.Max(w, other.w));

		public float Dot(Float2 other) => x * other.x + y * other.y;
		public float Dot(Float3 other) => x * other.x + y * other.y + z * other.z;
		public float Dot(Float4 other) => x * other.x + y * other.y + z * other.z + w * other.w;

		public Float4 Cross(Float4 other) => new Float4(
			y * other.z - z * other.y,
			z * other.x - x * other.z,
			x * other.y - y * other.x,
			w * other.w
		);

		public Float4 Reflect(Float4 normal) => this - 2f * Dot(normal) * normal;


		/// <summary>
		///     returns a new Float4 with a direction of this and a specified target magnitude
		/// </summary>
		public Float4 AsMagnitude(float magnitude) => Normalized * magnitude;
		public Float4 Map(Func<float, float> func) => new Float4(func(x), func(y), func(z), func(w));

		public Float4 OffsetX(float value) => new Float4(x + value, y, z, w);
		public Float4 OffsetY(float value) => new Float4(x, y + value, z, w);
		public Float4 OffsetZ(float value) => new Float4(x, y, z + value, w);
		public Float4 OffsetW(float value) => new Float4(x, y, z, w + value);

		public Float4 AsX(float value) => new Float4(value, y, z, w);
		public Float4 AsY(float value) => new Float4(x, value, z, w);
		public Float4 AsZ(float value) => new Float4(x, y, value, w);
		public Float4 AsW(float value) => new Float4(x, y, z, value);

		public string ToString(string format, IFormatProvider formatProvider) =>
			"(" + x.ToString(format, formatProvider) + ", " + y.ToString(format, formatProvider) + ", " + z.ToString(format, formatProvider) + ", " + w.ToString(format, formatProvider) + ")";

		public override string ToString() => "(" + x + ", " + y + ", " + z + ", " + w + ")";

		public string ToString(string format) => "(" + x.ToString(format) + ", " + y.ToString(format) + ", " + z.ToString(format) + ", " + w.ToString(format) + ")";

		public bool Equals(Float4 other) => x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && w.Equals(other.w);

		public override bool Equals(object obj) => obj is Float4 other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = x.GetHashCode();
				hashCode = (hashCode * 397) ^ y.GetHashCode();
				hashCode = (hashCode * 397) ^ z.GetHashCode();
				hashCode = (hashCode * 397) ^ w.GetHashCode();
				return hashCode;
			}
		}

		#endregion
	}
}
