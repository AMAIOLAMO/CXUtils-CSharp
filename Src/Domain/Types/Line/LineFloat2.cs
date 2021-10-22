using System;
using System.Runtime.InteropServices;
using CXUtils.Common;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     Represents a single line in 2D
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct LineFloat2
    {
        [FieldOffset( 0 )] public readonly Float2 positionA;
        [FieldOffset( 8 )] public readonly Float2 positionB;
        public LineFloat2( Float2 positionA, Float2 positionB ) => ( this.positionA, this.positionB ) = ( positionA, positionB );

        /// <summary>
        ///     Samples a point in between the two points using <paramref name="t" />
        /// </summary>
        public Float2 Sample( float t ) => positionA.Lerp( positionB, t );

        /// <summary>
        ///     Checks if two lines intersect
        /// </summary>
        public bool Intersect( LineFloat2 other, out float t, out float u )
        {
            float x1Mx2 = positionA.x - positionB.x,
                x1Mx3 = positionA.x - other.positionA.x,
                x3Mx4 = other.positionA.x - other.positionB.x,
                y1My2 = positionA.y - positionB.y,
                y1My3 = positionA.y - other.positionA.y,
                y3My4 = other.positionA.y - other.positionB.y;

            float tUp = x1Mx3 * y3My4 - y1My3 * x3Mx4;
            float uUp = -( x1Mx2 * y1My3 - y1My2 * x1Mx3 );
            float den = x1Mx2 * y3My4 - y1My2 * x3Mx4;

            ( t, u ) = ( tUp / den, uUp / den );

            bool tBool, uBool;
            ( tBool, uBool ) = ( t >= 0f && t <= 1f, u >= 0f && u <= 1f );

            return tBool && uBool;
        }

        public static explicit operator LineFloat2( LineFloat3 value ) => new LineFloat2( (Float2)value.positionA, (Float2)value.positionB );
    }
}
