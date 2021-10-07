using System;
using System.Runtime.InteropServices;
using CXUtils.Common;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     Represents a single line in 3D
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct LineFloat3
    {
        [FieldOffset( 0 )]  public readonly Float3 positionA;
        [FieldOffset( 12 )] public readonly Float3 positionB;
        public LineFloat3( Float3 positionA, Float3 positionB ) => ( this.positionA, this.positionB ) = ( positionA, positionB );

        /// <summary>
        ///     Samples a point in between the two points using <paramref name="t" />
        /// </summary>
        public Float3 Sample( float t ) => positionA.Lerp( positionB, t );

        public static implicit operator LineFloat3( LineFloat2 value ) => new LineFloat3( value.positionA, value.positionB );
    }
}
