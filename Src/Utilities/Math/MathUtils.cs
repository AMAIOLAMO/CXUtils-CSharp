using System;
using CXUtils.Mathematics;

namespace CXUtils.Common
{
    /// <summary>
    ///     Math Function Class
    /// </summary>
    public static class MathUtils
    {

        /// <summary>
        ///     This will map the whole real Number line into the range of 0 - 1 <br />
        ///     Equation: 1f / (Math.Pow(Math.E, -x));
        /// </summary>
        public static float Sigmoid( float x ) => 1f / (float)Math.Pow( Constants.E, -x );

        /// <summary>
        ///     This will map the whole real Number line into the range of 0 - 1 <br />
        ///     Equation: 1f / (Math.Pow(Math.E, -x));
        /// </summary>
        public static double Sigmoid( double x ) => 1f / Math.Pow( Constants.E, -x );
        #region Extensions

        public static float Floor( this float value )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Floor( value );
            #else
            return FloorInt( value );
            #endif
        }

        public static float Ceil( this float value )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Ceiling( value );
            #else
            return CeilInt( value );
            #endif
        }

        public static int FloorInt( this float value )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return (int)value.Floor();
            #else
            int valueInt = (int)value;

            return value < valueInt ? valueInt - 1 : valueInt;
            #endif
        }

        public static int CeilInt( this float value )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return (int)value.Ceil();
            #else
            int valueInt = (int)value;

            return value > valueInt ? valueInt + 1 : valueInt;
            #endif
        }

        public static bool IsApproximate( this float value, float compared = 0f, float precision = float.Epsilon ) => Math.Abs( value - compared ) < precision;
        public static bool IsApproximate( this double value, double compared = 0d, double precision = double.Epsilon ) => Math.Abs( value - compared ) < precision;

        /// <summary>
        ///     This will loop the <paramref name="value" /> back to 0, when <paramref name="value" /> is an integer
        /// </summary>
        public static float Frac( this float value ) => value - Floor( value );

        /// <inheritdoc cref="Frac(float)" />
        public static double Frac( this double value ) => value - Math.Floor( value );

        /// <summary>
        ///     Loops the <paramref name="value" /> back to 0 when <paramref name="value" /> is a multiple of
        ///     <paramref name="amount" />
        /// </summary>
        public static float Loop( this float value, float amount ) => value - Floor( value / amount ) * amount;

        /// <inheritdoc cref="Loop(float, float)" />
        public static int Loop( this int value, int amount ) => value % amount;

        /// <inheritdoc cref="Loop(float, float)" />
        public static double Loop( this double value, double amount ) => value - Math.Floor( value / amount ) * amount;

        #endregion

        #region Math Functions

        public static float Cos( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Cos( angle );
            #else
            return (float)Math.Cos( angle );
            #endif
        }

        public static float Acos( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Acos( angle );
            #else
            return (float)Math.Acos( angle );
            #endif
        }

        public static float Acosh( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Acosh( angle );
            #else
            return (float)Math.Acosh( angle );
            #endif
        }

        public static float Sin( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Sin( angle );
            #else
            return (float)Math.Sin( angle );
            #endif
        }

        public static float Asin( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Asin( angle );
            #else
            return (float)Math.Asin( angle );
            #endif
        }

        public static float Asinh( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Asinh( angle );
            #else
            return (float)Math.Asinh( angle );
            #endif
        }

        public static float Tan( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Tan( angle );
            #else
            return (float)Math.Tan( angle );
            #endif
        }

        public static float ATan( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Atan( angle );
            #else
            return (float)Math.Atan( angle );
            #endif
        }

        public static float ATanh( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Atanh( angle );
            #else
            return (float)Math.Atanh( angle );
            #endif
        }

        public static float Atan2( float y, float x )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Atan2( y, x );
            #else
            return (float)Math.Atan2( y, x );
            #endif
        }

        public static float CopySign( float value, float sign )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.CopySign( value, sign );
            #else
            return Math.Abs( value ) * Math.Sign( sign );
            #endif
        }

        public static float Sqrt( float value )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Sqrt( value );
            #else
            return (float)Math.Sqrt( value );
            #endif
        }

        public static float Pow( float value, float power )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Pow( value, power );
            #else
            return (float)Math.Pow( value, power );
            #endif
        }

        #endregion

        #region Range

        /// <summary>
        ///     Maps the given value from the given range to the another given range <br />
        ///     NOTE: If values overflow, it will cause unexpected behaviour
        /// </summary>
        public static float Map( float value, float inMin, float inMax, float outMin, float outMax ) => ( value - inMin ) * ( outMax - outMin ) / ( inMax - inMin ) + outMin;
        /// <inheritdoc cref="Map(float,float,float,float,float)" />
        public static double Map( double value, double inMin, double inMax, double outMin, double outMax ) => ( value - inMin ) * ( outMax - outMin ) / ( inMax - inMin ) + outMin;
        /// <inheritdoc cref="Map(float,float,float,float,float)" />
        public static int Map( int value, int inMin, int inMax, int outMin, int outMax ) => ( value - inMin ) * ( outMax - outMin ) / ( inMax - inMin ) + outMin;

        /// <summary>
        ///     Maps the given value from (-1 ~ 1) to (0 ~ 1)
        /// </summary>
        public static float MapNeg11To01( float value ) => value * .5f + .5f;

        public static float Clamp( float value, float min, float max ) => value < min ? min : value > max ? max : value;
        public static double Clamp( double value, double min, double max ) => value < min ? min : value > max ? max : value;
        public static int Clamp( int value, int min, int max ) => value < min ? min : value > max ? max : value;

        public static float Clamp01( float value ) => Clamp( value, 0f, 1f );
        public static double Clamp01( double value ) => Clamp( value, 0f, 1f );

        #endregion

        #region Other

        public static float RoundOnStep( float value, float step )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Round( value / step ) * step;
            #else
            return (float)Math.Round( value / step ) * step;
            #endif
        }
        public static double RoundOnStep( double value, double step ) => Math.Round( value / step ) * step;

        #endregion
    }
}
