﻿using System;
using System.Runtime.InteropServices;
using CXUtils.Common;
#if CXUTILS_UNSAFE
using System.Diagnostics;
#endif

namespace CXUtils.Types
{
    /// <summary>
    ///     represents three floats
    /// </summary>
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct Float3 : ITypeVectorFloat<Float3>
    {
        [FieldOffset( 0 )] public readonly float x;
        [FieldOffset( 4 )] public readonly float y;
        [FieldOffset( 8 )] public readonly float z;
        public Float3( float x = .0f, float y = .0f, float z = .0f ) => ( this.x, this.y, this.z ) = ( x, y, z );
        public Float3( Float3 other ) => ( x, y, z ) = ( other.x, other.y, other.z );

        public float this[ int index ]
        {
            get
            {
                #if CXUTILS_UNSAFE
                unsafe
                {
                    Debug.Assert(index >= 0 && index < 3, nameof( index )+ " is out of range!");
                    return ((int*)x)[index];
                }
                #else
                switch ( index )
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

        public static Float3 MinValue => (Float3)float.MinValue;
        public static Float3 MaxValue => (Float3)float.MaxValue;
        public static Float3 Epsilon  => (Float3)float.Epsilon;

        public static Float3 Zero    => (Float3)0f;
        public static Float3 One     => (Float3)1f;
        public static Float3 Half    => (Float3).5f;
        public static Float3 Quarter => (Float3).25f;

        public static Float3 PosY => new( y: 1f );
        public static Float3 NegY => new( y: -1f );
        public static Float3 NegX => new( -1f );
        public static Float3 PosX => new( 1f );
        public static Float3 PosZ => new( z: 1f );
        public static Float3 NegZ => new( z: -1f );

        public Int3 FloorInt => new( x.FloorInt(), y.FloorInt(), z.FloorInt() );
        public Int3 CeilInt  => new( x.CeilInt(), y.CeilInt(), z.CeilInt() );

        public float SqrMagnitude => x * x + y * y + z * z;
        public float Magnitude    => (float)Math.Sqrt( SqrMagnitude );

        public Float3 Normalized => Magnitude == 0f ? Zero : this / Magnitude;

        public Float3 Floor => new( x.Floor(), y.Floor(), z.Floor() );
        public Float3 Ceil  => new( x.Ceil(), y.Ceil(), z.Ceil() );
        public Float3 Halve => this * .5f;


        #region Operator overloading

        public static Float3 operator +( Float3 a, Float3 b ) => new( a.x + b.x, a.y + b.y, a.z + b.z );
        public static Float3 operator -( Float3 a, Float3 b ) => new( a.x - b.x, a.y - b.y, a.z - b.z );
        public static Float3 operator *( Float3 a, Float3 b ) => new( a.x * b.x, a.y * b.y, a.z * b.z );
        public static Float3 operator /( Float3 a, Float3 b ) => new( a.x / b.x, a.y / b.y, a.x / b.x );

        public static Float3 operator *( Float3 a, float value ) => new( a.x * value, a.y * value, a.z * value );
        public static Float3 operator /( Float3 a, float value ) => new( a.x / value, a.y / value, a.z / value );
        public static Float3 operator *( float value, Float3 a ) => a * value;
        public static Float3 operator /( float value, Float3 a ) => a / value;
        public static Float3 operator -( Float3 a ) => new( -a.x, -a.y, -a.z );

        public static bool operator ==( Float3 a, Float3 b ) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=( Float3 a, Float3 b ) => a.x != b.x || a.y != b.y || a.z != b.z;

        public static explicit operator Float3( float value ) => new( value, value, value );
        public static explicit operator Float3( Int3 value ) => new( value.x, value.y, value.z );
        public static implicit operator Float3( Float2 value ) => new( value.x, value.y );

        #endregion

        #region Utility

        public bool Equals( Float3 other ) => x.Equals( other.x ) && y.Equals( other.y ) && z.Equals( other.z );
        public Float3 Min( Float3 other ) => new( Math.Min( x, other.x ), Math.Min( y, other.y ), Math.Min( z, other.z ) );
        public Float3 Max( Float3 other ) => new( Math.Max( x, other.x ), Math.Max( y, other.y ), Math.Max( z, other.z ) );

        public override bool Equals( object obj ) => obj is Float3 other && Equals( other );
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = x.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ y.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ z.GetHashCode();
                return hashCode;
            }
        }

        public float Dot( Float2 other ) => x * other.x + y * other.y;
        public float Dot( Float3 other ) => x * other.x + y * other.y + z * other.z;

        public Float3 Cross( Float3 other ) => new( y * other.z - z * other.y, z * other.x - x * other.z, x * other.y - y * other.x );

        public Float3 Reflect( Float3 normal ) => this - 2f * Dot( normal ) * normal;


        public Float3 MagnitudeOf( float magnitude ) => Normalized * magnitude;
        public Float3 MapAxis( Func<float, float> mapFunction ) => new( mapFunction( x ), mapFunction( y ), mapFunction( z ) );

        public string ToString( string format, IFormatProvider formatProvider ) =>
            "(" + x.ToString( format, formatProvider ) + ", " + y.ToString( format, formatProvider ) + ", " + z.ToString( format, formatProvider ) + ")";
        public override string ToString() => "(" + x + ", " + y + ", " + z + ")";
        public string ToString( string format ) => "(" + x.ToString( format ) + ", " + y.ToString( format ) + ", " + z.ToString( format ) + ")";

        #endregion
    }
}