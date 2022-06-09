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
	///     represents two integers
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Int2 : IVectorInt<Int2>
	{
		public Int2(int x = 0, int y = 0) => (this.x, this.y) = (x, y);
		public Int2(Int2 other) => (x, y) = (other.x, other.y);

		public static Int2 MinValue => (Int2)int.MinValue;
		public static Int2 MaxValue => (Int2)int.MaxValue;

		public static Int2 Zero => (Int2)0;
		public static Int2 One  => (Int2)1;

		public static Int2 UnitY    => new(y: 1);
		public static Int2 NegUnitY => new(y: -1);
		public static Int2 UnitX    => new(1);
		public static Int2 NegUnitX => new(-1);

		public int this[int index]
		{
			get
			{
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 2, nameof( index )+ " is out of range!");
                    fixed ( int* ptr = &x ) return ptr[index];
                }
                #else
				switch (index)
				{
					case 0:
						return x;
					case 1:
						return y;

					default:
						throw new IndexOutOfRangeException();
				}
                #endif
			}
		}

		[FieldOffset(0)] public readonly int x;
		[FieldOffset(4)] public readonly int y;

		#region Operator overloading

		public static Int2 operator +(Int2 a, Int2 b) => new(a.x + b.x, a.y + b.y);
		public static Int2 operator -(Int2 a, Int2 b) => new(a.x - b.x, a.y - b.y);
		public static Int2 operator *(Int2 a, Int2 b) => new(a.x * b.x, a.y * b.y);
		public static Int2 operator /(Int2 a, Int2 b) => new(a.x / b.x, a.y / b.y);
		public static Int2 operator *(Int2 a, int value) => new(a.x * value, a.y * value);
		public static Int2 operator /(Int2 a, int value) => new(a.x / value, a.y / value);
		public static Int2 operator %(Int2 a, int value) => new(a.x % value, a.y % value);
		public static Int2 operator *(int value, Int2 a) => a * value;
		public static Int2 operator /(int value, Int2 a) => a / value;
		public static Int2 operator -(Int2 a) => new(-a.x, -a.y);
		public static bool operator ==(Int2 a, Int2 b) => a.x == b.x && a.y == b.y;
		public static bool operator !=(Int2 a, Int2 b) => a.x != b.x || a.y != b.y;

		public static explicit operator Int2(Int3 value) => new(value.x, value.y);
		public static explicit operator Int2(int value) => new(value, value);

		#endregion

		#region Utility

		public Int2 Min(Int2 other) => new(Math.Min(x, other.x), Math.Min(y, other.y));
		public Int2 Max(Int2 other) => new(Math.Max(x, other.x), Math.Max(y, other.y));

		public int Dot(Int2 other) => x * other.x + y * other.y;

		public Int2 Apply(Func<int, int> func) => new(func(x), func(y));

		public Int2 OffsetX(int value) => new(x + value, y);
		public Int2 OffsetY(int value) => new(x, y + value);

		public Int2 WithX(int value) => new(value, y);
		public Int2 WithY(int value) => new(x, value);

		public bool Equals(Int2 other) => x == other.x && y == other.y;

		public string ToString(string format, IFormatProvider formatProvider) =>
			"(" + x.ToString(format, formatProvider) + ", " + y.ToString(format, formatProvider) + ")";
		public override bool Equals(object obj) => obj is Int2 other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return (x.GetHashCode() * 397) ^ y.GetHashCode();
			}
		}

		public override string ToString() => $"({x}, {y})";
		public IEnumerator<Int2> GetEnumerator()
		{
			for (int y = 0; y < this.y; ++y)
				for (int x = 0; x < this.x; ++x)
					yield return new Int2(x, y);
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public string ToString(string format) =>
			$"({x.ToString(format)}, {y.ToString(format)})";

		#endregion
	}
}
