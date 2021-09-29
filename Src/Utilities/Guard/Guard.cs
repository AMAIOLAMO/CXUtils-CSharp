using System;

namespace CXUtils.Utilities
{
    /// <summary>
    ///     Consists of NON-ASSERTIVE guard clauses for values
    /// </summary>
    public static class Guard
    {
        #region Value Type

        public static int NegativeOrZero( int value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        public static int Negative( int value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static int Zero( int value, string nameOfValue )
        {
            if ( value == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );

            return value;
        }

        public static float NegativeOrZero( float value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        public static float Negative( float value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static float Zero( float value, string nameOfValue )
        {
            if ( value == 0f ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );

            return value;
        }

        public static double NegativeOrZero( double value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        public static double Negative( double value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static double Zero( double value, string nameOfValue )
        {
            if ( value == 0d ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );

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
            if ( string.IsNullOrEmpty( value ) ) throw new ArgumentException( GuardMessage.MESSAGE_NULL_OR_EMPTY, nameOfValue );

            return value;
        }

        public static string NullOrEmpty( string value, string nameOfValue, string customMessage )
        {
            if ( string.IsNullOrEmpty( value ) ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static string NullOrWhiteSpace( string value, string nameOfValue )
        {
            if ( string.IsNullOrWhiteSpace( value ) ) throw new ArgumentException( GuardMessage.MESSAGE_NULL_OR_WHITESPACE, nameOfValue );

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
