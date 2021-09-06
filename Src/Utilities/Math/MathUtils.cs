using System;
using CXUtils.Mathematics;

namespace CXUtils.Common
{
    /// <summary>
    ///     Math Function Class
    /// </summary>
    public static class MathUtils
    {
        public static float Floor( this float value ) => FloorInt( value );

        public static float Ceil( this float value ) => CeilInt( value );

        public static int FloorInt( this float value )
        {
            int valueInt = (int)value;

            return value < valueInt ? valueInt - 1 : valueInt;
        }

        public static int CeilInt( this float value )
        {
            int valueInt = (int)value;

            return value > valueInt ? valueInt + 1 : valueInt;
        }

        /// <summary>
        ///     This will map the whole real Number line into the range of 0 - 1 <br />
        ///     using calculation 1f / (Math.Pow(Math.E, -x));
        /// </summary>
        public static float Sigmoid( float x ) => 1f / (float)Math.Pow( Constants.E, -x );

        public static bool IsApproximate( this float value, float x, float precision = float.Epsilon ) => Math.Abs( value - x ) < precision;

        /// <summary>
        ///     This will loop the <paramref name="value" /> back to 0, when <paramref name="value" /> is an integer
        /// </summary>
        public static float Frac( this float value ) => value - Floor( value );
        /// <summary>
        ///     Loops the <paramref name="value" /> back to 0 when <paramref name="value" /> is a multiple of
        ///     <paramref name="amount" />
        /// </summary>
        public static float Loop( this float value, float amount ) => value - Floor( value / amount ) * amount;

        /// <inheritdoc cref="Loop(float, float)" />
        public static int Loop( this int value, int amount ) => value % amount;

        /// <inheritdoc cref="Loop(float, float)" />
        public static double Loop( this double value, double amount ) => value - Math.Floor( value / amount ) * amount;

        #region Math Functions

        public static float Cos( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Cos( angle );
            #else
            return (float)Math.Cos( angle );
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

        public static float Tan( float angle )
        {
            #if NETCOREAPP2_0_OR_GREATER
            return MathF.Tan( angle );
            #else
            return (float)Math.Tan( angle );
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
            return (float)Math.CopySign( value, sign );
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

        public static float RoundOnStep( float value, float step ) => (float)Math.Round( value / step ) * step;
        public static double RoundOnStep( double value, double step ) => Math.Round( value / step ) * step;

        #endregion
    }
}
