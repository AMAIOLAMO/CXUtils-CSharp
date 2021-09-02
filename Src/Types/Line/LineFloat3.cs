using CXUtils.Common;

namespace CXUtils.Types
{
    /// <summary>
    ///     Represents a single line in 3D
    /// </summary>
    public readonly struct LineFloat3
    {
        public readonly Float3 positionA, positionB;
        public LineFloat3( Float3 positionA, Float3 positionB ) => ( this.positionA, this.positionB ) = ( positionA, positionB );

        /// <summary>
        ///     Samples a point in between the two points using <paramref name="t" />
        /// </summary>
        public Float3 Sample( float t ) => positionA.Lerp( positionB, t );

        public static implicit operator LineFloat3( LineFloat2 value ) => new LineFloat3( value.positionA, value.positionB );
    }
}
