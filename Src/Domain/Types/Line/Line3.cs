﻿using System;
using System.Runtime.InteropServices;
using CXUtils.Common;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     Represents a single line in 3D
    /// </summary>
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct Line3
    {
        [FieldOffset( 0 )]  public readonly Float3 a;
        [FieldOffset( 12 )] public readonly Float3 b;
        public Line3( Float3 a, Float3 b ) => ( this.a, this.b ) = ( a, b );

        /// <summary>
        ///     Samples a point in between the two points using <paramref name="t" />
        /// </summary>
        public Float3 Sample( float t ) => a.Lerp( b, t );

        public static implicit operator Line3( Line2 value ) => new Line3( value.a, value.b );
    }
}