#nullable enable
using System;
using System.Runtime.InteropServices;
using System.Text;
using CXUtils.Common;

namespace CXUtils.Domain.Types
{
	/// <summary>
	///     Represents a 3x3 floating point matrix
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Float3x3 : IEquatable<Float3x3>, IFormattable
	{
		public Float3x3(Float3 iHat, Float3 jHat, Float3 kHat) => (this.iHat, this.jHat, this.kHat) = (iHat, jHat, kHat);

		public Float3x3(
			float v00, float v10, float v20,
			float v01, float v11, float v21,
			float v02, float v12, float v22
		) => (iHat, jHat, kHat) = (
			new Float3(v00, v01, v02),
			new Float3(v10, v11, v12),
			new Float3(v20, v21, v22)
		);

		public static Float3x3 Zero => new(Float3.Zero, Float3.Zero, Float3.Zero);
		public static Float3x3 Identity => new(
			new Float3(1f),
			new Float3(0f, 1f),
			new Float3(0f, 0f, 1f)
		);
		/// <summary>
		///     Left column: v00 | v01 | v02
		/// </summary>
		[FieldOffset(0)] public readonly Float3 iHat;
		/// <summary>
		///     Middle column: v10 | v11 | v12
		/// </summary>
		[FieldOffset(12)] public readonly Float3 jHat;
		/// <summary>
		///     Right column: v20 | v21 | v22
		/// </summary>
		[FieldOffset(24)] public readonly Float3 kHat;

		#region Operators

		public static Float3x3 operator +(Float3x3 a, Float3x3 b) => new(a.iHat + b.iHat, a.jHat + b.jHat, a.kHat + b.kHat);
		public static Float3x3 operator -(Float3x3 a, Float3x3 b) => new(a.iHat - b.iHat, a.jHat - b.jHat, a.kHat - b.kHat);

		public static Float3x3 operator *(Float3x3 matrix, float scalar) => new(matrix.iHat * scalar, matrix.jHat * scalar, matrix.kHat * scalar);
		/*public static Float3x3 operator *( Float3x3 a, Float3x3 b ) => new Float3x3(
			new Float2( a.iHat.x * b.iHat.x + a.jHat.x * b.iHat.y, a.iHat.x * b.jHat.x + a.jHat.x * b.jHat.y ),
			new Float2( a.iHat.y * b.iHat.x + a.jHat.y * b.iHat.y, a.iHat.y * b.jHat.x + a.jHat.y * b.jHat.y )
		);*/

		public static Float3 operator *(Float3 vector, Float3x3 matrix) => new(
			vector.x * matrix.iHat.x + vector.y * matrix.iHat.y + vector.z * matrix.iHat.z,
			vector.x * matrix.jHat.x + vector.y * matrix.jHat.y + vector.z * matrix.jHat.z,
			vector.x + matrix.kHat.x + vector.y * matrix.kHat.y + vector.z * matrix.kHat.z
		);

		public static Float3 operator *(Float3x3 matrix, Float3 matrix3x1) => new(
			matrix.iHat.x * matrix3x1.x + matrix.jHat.x * matrix3x1.y + matrix.kHat.x * matrix3x1.z,
			matrix.iHat.y * matrix3x1.x + matrix.jHat.y * matrix3x1.y + matrix.kHat.y * matrix3x1.z,
			matrix.iHat.z * matrix3x1.x + matrix.jHat.z * matrix3x1.y + matrix.kHat.z * matrix3x1.z
		);

		public static Float3x3 operator /(Float3x3 matrix, float scalar) => new(matrix.iHat / scalar, matrix.jHat / scalar, matrix.kHat / scalar);
		//public static Float3x3 operator /( Float3x3 a, Float3x3 b ) => a * b.GetInverse();

		public static bool operator ==(Float3x3 left, Float3x3 right) => left.iHat == right.iHat && left.jHat == right.jHat && left.kHat == right.kHat;

		public static bool operator !=(Float3x3 left, Float3x3 right) => left.iHat != right.iHat || left.jHat != right.jHat || left.kHat != right.kHat;

		public static Float3x3 operator -(Float3x3 matrix) => new(-matrix.iHat, -matrix.jHat, -matrix.kHat);

		#endregion

		#region Methods

		public bool Equals(Float3x3 other) => this == other;

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			using IPoolItem? _ = CommonPools.StringBuilder.PopScope(out StringBuilder? sb);

			sb.Append("| " + iHat.x + ", " + jHat.x + ", " + kHat.x + " |\n");
			sb.Append("| " + iHat.y + ", " + jHat.y + ", " + kHat.y + " |\n");
			sb.Append("| " + iHat.z + ", " + jHat.z + ", " + kHat.z + " |");
			return sb.ToString();
		}

		public override bool Equals(object? obj) => obj is Float3x3 other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = iHat.GetHashCode();
				hashCode = (hashCode * 397) ^ jHat.GetHashCode();
				hashCode = (hashCode * 397) ^ kHat.GetHashCode();
				return hashCode;
			}
		}

		#endregion

		#region Static Methods

		public static Float3x3 BuildDiagonal(Float3 value) => new(
			new Float3(value.x),
			new Float3(0f, value.y),
			new Float3(0f, 0f, value.z)
		);

		public static Float3x3 BuildScalar(float value) => new(
			new Float3(value),
			new Float3(0f, value),
			new Float3(0f, 0f, value)
		);

		#endregion
	}
}
