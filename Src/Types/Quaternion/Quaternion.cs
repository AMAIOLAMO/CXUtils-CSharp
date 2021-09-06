#nullable enable

using System;
using CXUtils.Common;
using CXUtils.Mathematics;

namespace CXUtils.Types.Quaternion
{
    /// <summary>
    ///     Four floating points that represents a physical rotation in 3D
    /// </summary>
    public readonly struct Quaternion : IEquatable<Quaternion>, IFormattable
    {
        /// <summary>
        ///     The main part of quaternions <br />
        ///     x: vector part of imaginary axis i [As for X axis] <br />
        ///     y: vector part of imaginary axis j [As for Y axis] <br />
        ///     z: vector part of imaginary axis k [As for Z axis] <br />
        ///     w: real / scalar part | rotation part of quaternions
        /// </summary>
        public readonly Float4 values;

        public Quaternion( Float4 value ) => values = value;
        public Quaternion( float x = 0f, float y = 0f, float z = 0f, float w = 0f ) => values = new Float4( x, y, z, w );

        public Quaternion( Float3 vector, float scalar ) => values = new Float4( vector.x, vector.y, vector.z, scalar );

        public static Quaternion Identity => new Quaternion( w: 1f );
        public static Quaternion Zero     => new Quaternion();

        public float SqrMagnitude => values.SqrMagnitude;
        public float Magnitude    => values.Magnitude;

        public Float3 EulerAngles
        {
            get
            {
                // X
                float sinXCosY = 2f * ( values.w * values.x + values.y * values.z );
                float cosXCosY = 1f - 2f * ( values.x * values.x + values.y * values.y );

                // Y
                float sinY = 2 * ( values.w * values.y - values.z * values.x );

                // Z
                float sinZCosY = 2f * ( values.w * values.z + values.x * values.y );
                float cosZCosY = 1f - 2f * ( values.y * values.y + values.z * values.z );

                return new Float3(
                    MathUtils.Atan2( sinXCosY, cosXCosY ),
                    Math.Abs( sinY ) >= 1f ? MathUtils.CopySign( Constants.HalfPI, sinY ) : MathUtils.Asin( sinY ),
                    MathUtils.Atan2( sinZCosY, cosZCosY )
                );
            }
        }

        #region Operators

        public static Quaternion operator +( Quaternion a, Quaternion b ) => new Quaternion( a.values + b.values );
        public static Quaternion operator -( Quaternion a, Quaternion b ) => new Quaternion( a.values - b.values );

        public static Quaternion operator -( Quaternion value ) => new Quaternion( -value.values.x, -value.values.y, -value.values.z, -value.values.w + Constants.TAU );

        public static bool operator ==( Quaternion left, Quaternion right ) => left.values == right.values;
        public static bool operator !=( Quaternion left, Quaternion right ) => left.values != right.values;

        #endregion

        #region Methods

        /// <summary>
        ///     Rotates the given <paramref name="vector"/>
        /// </summary>
        public Float3 Rotate( Float3 vector )
        {
            throw new NotImplementedException();
        }

        public override string ToString() => values.ToString();
        public string ToString( string? format, IFormatProvider? formatProvider ) => values.ToString( format, formatProvider );

        public string ToDetailedString() => "( scalar: " + values.w + ", vector: { " + values.x + "i, " + values.y + "j, " + values.z + "k } )";

        public bool Equals( Quaternion other ) => values == other.values;
        public override bool Equals( object? obj ) => obj is Quaternion other && values == other.values;
        public override int GetHashCode() => values.GetHashCode();

        #endregion

        #region Static methods

        public static Quaternion FromEulerAngles( Float3 rotation )
        {
            float cx = MathUtils.Cos( rotation.x * .5f );
            float sx = MathUtils.Sin( rotation.x * .5f );

            float cy = MathUtils.Cos( rotation.y * .5f );
            float sy = MathUtils.Sin( rotation.y * .5f );

            float cz = MathUtils.Cos( rotation.z * .5f );
            float sz = MathUtils.Sin( rotation.z * .5f );

            return new Quaternion(
                sx * cy * cz - cx * sy * sz,
                cx * sy * cz + sx * cy * sz,
                cx * cy * sz - sx * sy * cz,
                cx * cy * cz + sx * sy * sz
            );
        }

        /// <summary>
        ///     Creates a <see cref="Quaternion" /> using <paramref name="axis" /> with an angle of <see cref="angle" /> <br />
        ///     Note: <paramref name="axis" /> must be a Unit / Normalized Vector
        /// </summary>
        public static Quaternion FromAxis( Float3 axis, float angle )
        {
            float vectorScalar = MathUtils.Sin( angle );

            return new Quaternion( axis * vectorScalar, MathUtils.Cos( angle ) );
        }

        #endregion
    }
}
