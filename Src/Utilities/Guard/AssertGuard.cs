﻿using System;

namespace CXUtils.Utilities
{
    /// <summary>
    ///     Consists of ASSERTIVE guard clauses for values
    /// </summary>
    public static class AssertGuard
    {
        #region Value Type

        public static int NegativeOrZero( int value, string nameOfValue )
        {
            #if DEBUG
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static int Negative( int value, string nameOfValue )
        {
            #if DEBUG
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );
            #endif

            return value;
        }

        public static int Zero( int value, string nameOfValue )
        {
            #if DEBUG
            if ( value == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static float NegativeOrZero( float value, string nameOfValue )
        {
            #if DEBUG
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static float Negative( float value, string nameOfValue )
        {
            #if DEBUG
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );
            #endif

            return value;
        }

        public static float Zero( float value, string nameOfValue )
        {
            #if DEBUG
            if ( value == 0f ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static double NegativeOrZero( double value, string nameOfValue )
        {
            #if DEBUG
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static double Negative( double value, string nameOfValue )
        {
            #if DEBUG
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );
            #endif

            return value;
        }

        public static double Zero( double value, string nameOfValue )
        {
            #if DEBUG
            if ( value == 0d ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );
            #endif

            return value;
        }

        #endregion

        #region Reference Type

        public static T Null<T>( T value, string nameOfValue ) where T : class
        {
            #if DEBUG
            if ( value == null ) throw new ArgumentNullException( nameOfValue );
            #endif

            return value;
        }

        public static T Null<T>( T value, string nameOfValue, string customMessage ) where T : class
        {
            #if DEBUG
            if ( value == null ) throw new ArgumentNullException( nameOfValue, customMessage );
            #endif

            return value;
        }

        #endregion

        #region String

        public static string NullOrEmpty( string value, string nameOfValue )
        {
            #if DEBUG
            if ( string.IsNullOrEmpty( value ) ) throw new ArgumentException( GuardMessage.MESSAGE_NULL_OR_EMPTY, nameOfValue );
            #endif

            return value;
        }

        public static string NullOrEmpty( string value, string nameOfValue, string customMessage )
        {
            #if DEBUG
            if ( string.IsNullOrEmpty( value ) ) throw new ArgumentException( customMessage, nameOfValue );
            #endif

            return value;
        }

        public static string NullOrWhiteSpace( string value, string nameOfValue )
        {
            #if DEBUG
            if ( string.IsNullOrWhiteSpace( value ) ) throw new ArgumentException( GuardMessage.MESSAGE_NULL_OR_WHITESPACE, nameOfValue );
            #endif

            return value;
        }

        public static string NullOrWhiteSpace( string value, string nameOfValue, string customMessage )
        {
            #if DEBUG
            if ( string.IsNullOrWhiteSpace( value ) ) throw new ArgumentException( customMessage, nameOfValue );
            #endif

            return value;
        }

        #endregion
    }
}
