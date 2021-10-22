using System;
using System.Collections;

namespace CXUtils.Utilities
{
    /// <summary>
    ///     Consists of NON-ASSERTIVE guard clauses for values
    /// </summary>
    public static class Guard
    {
        #region Generic

        /// <summary>
        ///     Guards against the given <paramref name="condition" /> <br />
        ///     thus it will guard if condition is true
        /// </summary>
        public static T Against<T>( T value, bool condition, string message )
        {
            if ( !condition ) throw new Exception( message );

            return value;
        }

        #endregion

        #region Array & Collection

        // == ARRAY == //

        public static T[] LengthZero<T>( T[] value, string nameOfValue )
        {
            if ( value.Length == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_ARRAY_LENGTH_ZERO, nameOfValue );

            return value;
        }

        public static T[] LengthNotEqual<T>( T[] value, int length, string nameOfValue )
        {
            if ( value.Length != length ) throw new ArgumentException( GuardMessage.MESSAGE_ARRAY_LENGTH_NOT_EQUAL_TO + $" {length}", nameOfValue );

            return value;
        }

        public static T[] LengthLess<T>( T[] value, int length, string nameOfValue )
        {
            if ( value.Length < length ) throw new ArgumentException( GuardMessage.MESSAGE_ARRAY_LENGTH_SMALLER_THAN + $" {length}", nameOfValue );

            return value;
        }

        public static T[] LengthZero<T>( T[] value, string nameOfValue, string customMessage )
        {
            if ( value.Length == 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static T[] LengthNotEqual<T>( T[] value, int length, string nameOfValue, string customMessage )
        {
            if ( value.Length != length ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static T[] LengthLess<T>( T[] value, int length, string nameOfValue, string customMessage )
        {
            if ( value.Length < length ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        // == COLLECTION == //

        public static T LengthZero<T>( T value, string nameOfValue ) where T : ICollection
        {
            if ( value.Count == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_COLLECTION_LENGTH_ZERO, nameOfValue );

            return value;
        }

        public static T LengthNotEqual<T>( T value, int length, string nameOfValue ) where T : ICollection
        {
            if ( value.Count != length ) throw new ArgumentException( GuardMessage.MESSAGE_COLLECTION_LENGTH_NOT_EQUAL_TO + $" {length}", nameOfValue );

            return value;
        }

        public static T LengthLess<T>( T value, int length, string nameOfValue ) where T : ICollection
        {
            if ( value.Count < length ) throw new ArgumentException( GuardMessage.MESSAGE_COLLECTION_LENGTH_SMALLER_THAN + $" {length}", nameOfValue );

            return value;
        }

        public static T LengthZero<T>( T value, string nameOfValue, string customMessage ) where T : ICollection
        {
            if ( value.Count == 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static T LengthNotEqual<T>( T value, int length, string nameOfValue, string customMessage ) where T : ICollection
        {
            if ( value.Count != length ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static T LengthLess<T>( T value, int length, string nameOfValue, string customMessage ) where T : ICollection
        {
            if ( value.Count < length ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        #endregion

        #region Value Type

        // == INT == //

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

        public static int NegativeOrZero( int value, string nameOfValue, string customMessage )
        {
            if ( value <= 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static int Negative( int value, string nameOfValue, string customMessage )
        {
            if ( value < 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static int Zero( int value, string nameOfValue, string customMessage )
        {
            if ( value == 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        // == FLOAT == //

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

        public static float NegativeOrZero( float value, string nameOfValue, string customMessage )
        {
            if ( value <= 0f ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static float Negative( float value, string nameOfValue, string customMessage )
        {
            if ( value < 0f ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static float Zero( float value, string nameOfValue, string customMessage )
        {
            if ( value == 0f ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        // == DOUBLE == //

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
        public static double NegativeOrZero( double value, string nameOfValue, string customMessage )
        {
            if ( value <= 0d ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static double Negative( double value, string nameOfValue, string customMessage )
        {
            if ( value < 0d ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static double Zero( double value, string nameOfValue, string customMessage )
        {
            if ( value == 0d ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static decimal NegativeOrZero( decimal value, string nameOfValue )
        {
            if ( value <= 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE_OR_ZERO, nameOfValue );

            return value;
        }

        // == DECIMAL == //

        public static decimal Negative( decimal value, string nameOfValue )
        {
            if ( value < 0 ) throw new ArgumentException( GuardMessage.MESSAGE_NEGATIVE, nameOfValue );

            return value;
        }

        public static decimal Zero( decimal value, string nameOfValue )
        {
            if ( value == 0 ) throw new ArgumentException( GuardMessage.MESSAGE_ZERO, nameOfValue );

            return value;
        }

        public static decimal NegativeOrZero( decimal value, string nameOfValue, string customMessage )
        {
            if ( value <= 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static decimal Negative( decimal value, string nameOfValue, string customMessage )
        {
            if ( value < 0 ) throw new ArgumentException( customMessage, nameOfValue );

            return value;
        }

        public static decimal Zero( decimal value, string nameOfValue, string customMessage )
        {
            if ( value == 0 ) throw new ArgumentException( customMessage, nameOfValue );

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

        public static T RefNull<T>( T value, string nameOfValue ) where T : class
        {
            if ( value is null ) throw new ArgumentNullException( nameOfValue );

            return value;
        }

        public static T RefNull<T>( T value, string nameOfValue, string customMessage ) where T : class
        {
            if ( value is null ) throw new ArgumentNullException( nameOfValue, customMessage );

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
