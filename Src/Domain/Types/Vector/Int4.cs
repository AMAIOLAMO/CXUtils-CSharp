﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if CXUTILS_UNSAFE
using System.Diagnostics;
#endif

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     represents four integers
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Int4 : IVectorInt<Int4>
	{
		public Int4(int x = 0, int y = 0, int z = 0, int w = 0) => (this.x, this.y, this.z, this.w) = (x, y, z, w);
		public Int4(Int4 other) => (x, y, z, w) = (other.x, other.y, other.z, other.w);

		public static Int4 MinValue => (Int4)int.MinValue;
		public static Int4 MaxValue => (Int4)int.MaxValue;

		public static Int4 Zero => (Int4)0;
		public static Int4 One  => (Int4)1;

		public static Int4 UnitY    => new(y: 1);
		public static Int4 NegUnitY => new(y: -1);
		public static Int4 UnitX    => new(1);
		public static Int4 NegUnitX => new(-1);
		public static Int4 UnitZ    => new(z: 1);
		public static Int4 NegUnitZ => new(z: -1);
		public static Int4 UnitW    => new(w: 1);
		public static Int4 NegUnitW => new(w: -1);

		public int this[int index]
		{
			get
			{
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 4, nameof( index )+ " is out of range!");
                    fixed ( int* ptr = &x ) return ptr[index];
                }
                #else
				switch (index)
				{
					case 0: return x;
					case 1: return y;
					case 2: return z;
					case 3: return w;

					default:
						throw new IndexOutOfRangeException();
				}
                #endif
			}
		}

		[FieldOffset(12)] public readonly int w;
		[FieldOffset(0)]  public readonly int x;
		[FieldOffset(4)]  public readonly int y;
		[FieldOffset(8)]  public readonly int z;

		#region Operator overloading

		public static Int4 operator +(Int4 a, Int4 b) => new(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		public static Int4 operator -(Int4 a, Int4 b) => new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		public static Int4 operator *(Int4 a, Int4 b) => new(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		public static Int4 operator /(Int4 a, Int4 b) => new(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		public static Int4 operator *(Int4 a, int value) => new(a.x * value, a.y * value, a.z * value, a.w * value);
		public static Int4 operator /(Int4 a, int value) => new(a.x / value, a.y / value, a.z / value, a.w / value);
		public static Int4 operator %(Int4 a, int value) => new(a.x % value, a.y % value, a.z % value, a.w % value);
		public static Int4 operator *(int value, Int4 a) => a * value;
		public static Int4 operator /(int value, Int4 a) => a / value;
		public static Int4 operator -(Int4 a) => new(-a.x, -a.y, -a.z, -a.w);
		public static bool operator ==(Int4 a, Int4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
		public static bool operator !=(Int4 a, Int4 b) => a.x != b.x || a.y != b.y || a.z == b.z || a.w != b.w;
		public static explicit operator Int4(int value) => new(value, value, value, value);
		public static implicit operator Int4(Int2 value) => new(value.x, value.y);
		public static implicit operator Int4(Int3 value) => new(value.x, value.y, value.z);

		#endregion

		#region Utility

		public Int4 Min(Int4 other) => new(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z), Math.Min(w, other.w));
		public Int4 Max(Int4 other) => new(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z), Math.Min(w, other.w));

		public int Dot(Int2 other) => x * other.x + y * other.y;
		public int Dot(Int3 other) => x * other.x + y * other.y + z * other.z;
		public int Dot(Int4 other) => x * other.x + y * other.y + z * other.z + w * other.w;

		public Int4 Apply(Func<int, int> func) => new(func(x), func(y), func(z), func(w));

		public Int4 OffsetX(int value) => new(x + value, y, z, w);
		public Int4 OffsetY(int value) => new(x, y + value, z, w);
		public Int4 OffsetZ(int value) => new(x, y, z + value, w);
		public Int4 OffsetW(int value) => new(x, y, z, w + value);

		public Int4 WithX(int value) => new(value, y, z, w);
		public Int4 WithY(int value) => new(x, value, z, w);
		public Int4 WithZ(int value) => new(x, y, value, w);
		public Int4 WithW(int value) => new(x, y, z, value);

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";

		public override string ToString() =>
			$"({x}, {y}, {z}, {w})";
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public string ToString(string format) =>
			$"({x.ToString(format)}, {y.ToString(format)}, {z.ToString(format)}, {w.ToString(format)})";

		public bool Equals(Int4 other) => x == other.x && y == other.y && z == other.z && w == other.w;

		public IEnumerator<Int4> GetEnumerator()
		{
			for (int x = 0; x < this.x; ++x)
				for (int y = 0; y < this.y; ++y)
					for (int z = 0; z < this.z; ++z)
						for (int w = 0; w < this.w; ++w)
							yield return new Int4(x, y, z, w);
		}
		public override bool Equals(object obj) => obj is Int4 other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = x;
				hashCode = (hashCode * 397) ^ y;
				hashCode = (hashCode * 397) ^ z;
				hashCode = (hashCode * 397) ^ w;
				return hashCode;
			}
		}

		#endregion
	}
}
