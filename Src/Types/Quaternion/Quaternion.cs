#nullable enable

using System;

namespace CXUtils.Types.Quaternion
{
    /// <summary>
    ///     Four floating points that represents a physical rotation in 3D
    /// </summary>
    public readonly struct Quaternion : IEquatable<Quaternion>, IFormattable
    {
        public readonly Float4 values;

        public Quaternion( Float4 value ) => values = value;
        public Quaternion( float x = 0f, float y = 0f, float z = 0f, float w = 0f ) => values = new Float4( x, y, z, w );

        public Quaternion( Float3 vector, float scalar ) => values = new Float4( vector.x, vector.y, vector.z, scalar );

        public static Quaternion Identity => new Quaternion( w: 1f );

        public float SqrMagnitude => values.SqrMagnitude;
        public float Magnitude    => values.Magnitude;

        #region Operators

        public static Quaternion operator +( Quaternion a, Quaternion b ) => new Quaternion( a.values + b.values );
        public static Quaternion operator -( Quaternion a, Quaternion b ) => new Quaternion( a.values - b.values );

        public static bool operator ==( Quaternion left, Quaternion right ) => left.values == right.values;
        public static bool operator !=( Quaternion left, Quaternion right ) => left.values != right.values;

        #endregion

        #region Methods

        public override string ToString() => values.ToString();
        public string ToString( string? format, IFormatProvider? formatProvider ) => values.ToString( format, formatProvider );

        public bool Equals( Quaternion other ) => values == other.values;
        public override bool Equals( object? obj ) => obj is Quaternion other && values == other.values;
        public override int GetHashCode() => values.GetHashCode();

        #endregion
    }
}
