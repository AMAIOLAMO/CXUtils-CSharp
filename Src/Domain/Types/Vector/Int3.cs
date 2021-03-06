using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if CXUTILS_UNSAFE
using System.Diagnostics;
#endif

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     represents three integers
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Int3 : IVectorInt<Int3>
	{
		public Int3(int x = 0, int y = 0, int z = 0) => (this.x, this.y, this.z) = (x, y, z);
		public Int3(Int3 other) => (x, y, z) = (other.x, other.y, other.z);

		public static Int3 MinValue => (Int3)int.MinValue;
		public static Int3 MaxValue => (Int3)int.MaxValue;

		public static Int3 Zero => (Int3)0;
		public static Int3 One  => (Int3)1;

		public static Int3 UnitY    => new(y: 1);
		public static Int3 NegUnitY => new(y: -1);
		public static Int3 UnitX    => new(1);
		public static Int3 NegUnitX => new(-1);
		public static Int3 UnitZ    => new(z: 1);
		public static Int3 NegUnitZ => new(z: -1);

		public int this[int index]
		{
			get
			{
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 3, nameof( index )+ " is out of range!");
                    fixed ( int* ptr = &x ) return ptr[index];
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

		[FieldOffset(0)] public readonly int x;
		[FieldOffset(4)] public readonly int y;
		[FieldOffset(8)] public readonly int z;

		#region Operator overloading

		public static Int3 operator +(Int3 a, Int3 b) => new(a.x + b.x, a.y + b.y, a.z + b.z);
		public static Int3 operator -(Int3 a, Int3 b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
		public static Int3 operator *(Int3 a, Int3 b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
		public static Int3 operator /(Int3 a, Int3 b) => new(a.x / b.x, a.y / b.y, a.z / b.z);
		public static Int3 operator *(Int3 a, int value) => new(a.x * value, a.y * value, a.z * value);
		public static Int3 operator /(Int3 a, int value) => new(a.x / value, a.y / value, a.z / value);
		public static Int3 operator %(Int3 a, int value) => new(a.x % value, a.y % value, a.z % value);
		public static Int3 operator *(int value, Int3 a) => a * value;
		public static Int3 operator /(int value, Int3 a) => a / value;
		public static Int3 operator -(Int3 a) => new(-a.x, -a.y, -a.z);
		public static bool operator ==(Int3 a, Int3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
		public static bool operator !=(Int3 a, Int3 b) => a.x != b.x || a.y != b.y || a.z == b.z;
		public static explicit operator Int3(int value) => new(value, value, value);
		public static implicit operator Int3(Int2 value) => new(value.x, value.y);

		#endregion

		#region Utility

		public Int3 Min(Int3 other) => new(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z));
		public Int3 Max(Int3 other) => new(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z));

		public int Dot(Int2 other) => x * other.x + y * other.y;
		public int Dot(Int3 other) => x * other.x + y * other.y + z * other.z;

		public Int3 Apply(Func<int, int> func) => new(func(x), func(y), func(z));

		public Int3 OffsetX(int value) => new(x + value, y, z);
		public Int3 OffsetY(int value) => new(x, y + value, z);
		public Int3 OffsetZ(int value) => new(x, y, z + value);

		public Int3 WithX(int value) => new(value, y, z);
		public Int3 WithY(int value) => new(x, value, z);
		public Int3 WithZ(int value) => new(x, y, value);

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
		public override string ToString() =>
			$"({x}, {y}, {z})";
		public string ToString(string format) =>
			$"({x.ToString(format)}, {y.ToString(format)}, {z.ToString(format)})";

		public bool Equals(Int3 other) => x == other.x && y == other.y && z == other.z;
		public IEnumerator<Int3> GetEnumerator()
		{
			for (int x = 0; x < this.x; ++x)
				for (int y = 0; y < this.y; ++y)
					for (int z = 0; z < this.z; z++)
						yield return new Int3(x, y, z);
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public override bool Equals(object obj) => obj is Int3 other && Equals(other);
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

		#endregion
	}
}
