using System.Collections;
#if DEBUG
using System;
#endif

namespace CXUtils.Utilities
{
    /// <summary>
    ///     Consists of ASSERTIVE guard clauses for values
    /// </summary>
    public static class AssertGuard
    {
        #region Generic

        public static T If<T>( T value, bool condition, string message )
        {
            #if DEBUG
            if ( condition ) throw new Exception( message );
            #endif

            return value;
        }

        #endregion

        #region Array & Collection

        public static T[] LengthZero<T>( T[] value, string nameOfValue )
        {
            #if DEBUG
            if ( value.Length == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_ARRAY_LENGTH_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static T[] LengthNotEqual<T>( T[] value, int length, string nameOfValue )
        {
            #if DEBUG
            if ( value.Length != length ) throw new ArgumentException( GuardMessage.MESSAGE_ARRAY_LENGTH_NOT_EQUAL_TO + $" {length}", nameOfValue );
            #endif

            return value;
        }

        public static T[] LengthLess<T>( T[] value, int length, string nameOfValue )
        {
            #if DEBUG
            if ( value.Length < length ) throw new ArgumentException( GuardMessage.MESSAGE_ARRAY_LENGTH_SMALLER_THAN + $" {length}", nameOfValue );
            #endif

            return value;
        }

        public static T LengthZero<T>( T value, string nameOfValue ) where T : ICollection
        {
            #if DEBUG
            if ( value.Count == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_COLLECTION_LENGTH_ZERO, nameOfValue );
            #endif

            return value;
        }

        public static T LengthNotEqual<T>( T value, int length, string nameOfValue ) where T : ICollection
        {
            #if DEBUG
            if ( value.Count != length ) throw new ArgumentException( GuardMessage.MESSAGE_COLLECTION_LENGTH_NOT_EQUAL_TO + $" {length}", nameOfValue );
            #endif

            return value;
        }

        public static T LengthLess<T>( T value, int length, string nameOfValue ) where T : ICollection
        {
            #if DEBUG
            if ( value.Count < length ) throw new ArgumentException( GuardMessage.MESSAGE_COLLECTION_LENGTH_SMALLER_THAN + $" {length}", nameOfValue );
            #endif

            return value;
        }

        #endregion

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
