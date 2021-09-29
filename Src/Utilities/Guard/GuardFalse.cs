using System;

namespace CXUtils.Utilities
{
    /// <summary>
    ///     A Guard Clause for Guarding if the check is false
    /// </summary>
    public static class GuardFalse
    {
        const string MESSAGE_NULL_OR_EMPTY      = "The given string is null or empty.";
        const string MESSAGE_NULL_OR_WHITESPACE = "The given string is null or whitespace.";

        const string MESSAGE_NEGATIVE         = "The given value is negative.";
        const string MESSAGE_ZERO             = "The given value is zero.";
        const string MESSAGE_NEGATIVE_OR_ZERO = "The given value is negative or zero.";

        #region Value Type

        public static int NegativeOrZero( int value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        public static int Negative( int value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static int Zero( int value, string nameOfValue )
        {
            if ( value == 0 ) throw new ArgumentException( MESSAGE_ZERO, nameOfValue );

            return value;
        }

        public static float NegativeOrZero( float value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        public static float Negative( float value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static float Zero( float value, string nameOfValue )
        {
            if ( value == 0f ) throw new ArgumentException( MESSAGE_ZERO, nameOfValue );

            return value;
        }

        public static double NegativeOrZero( double value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        public static double Negative( double value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static double Zero( double value, string nameOfValue )
        {
            if ( value == 0d ) throw new ArgumentException( MESSAGE_ZERO, nameOfValue );

            return value;
        }

        #endregion

        #region Reference Type

        public static T Null<T>( T value, string nameOfValue ) where T : class
        {
            if ( value == null ) throw new ArgumentNullException( nameOfValue );

            return value;
        }

        public static T Null<T>( T value, string nameOfValue, string customMessage ) where T : class
        {
            if ( value == null ) throw new ArgumentNullException( nameOfValue, customMessage );

            return value;
        }

        #endregion

        #region String

        public static string NullOrEmpty( string value, string nameOfValue )
        {
            if ( string.IsNullOrEmpty( value ) ) throw new ArgumentException( MESSAGE_NULL_OR_EMPTY, nameOfValue );

            return value;
        }

        public static string NullOrEmpty( string value, string nameOfValue, string customMessage )
        {
            if ( string.IsNullOrEmpty( value ) ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static string NullOrWhiteSpace( string value, string nameOfValue )
        {
            if ( string.IsNullOrWhiteSpace( value ) ) throw new ArgumentException( MESSAGE_NULL_OR_WHITESPACE, nameOfValue );

            return value;
        }

        public static string NullOrWhiteSpace( string value, string nameOfValue, string customMessage )
        {
            if ( string.IsNullOrWhiteSpace( value ) ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        #endregion
    }
}
