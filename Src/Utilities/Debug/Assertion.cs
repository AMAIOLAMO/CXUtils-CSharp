using System;
using System.Diagnostics;
using CXUtils.Common;

namespace CXUtils.Debugging
{
    /// <summary>
    ///     A utility class for assertions
    /// </summary>
    public static class Assertion
    {
        [Conditional( "DEBUG" )]
        public static void Assert( bool condition, string message )
        {
            if ( condition ) return;

            throw new Exception( message );
        }

        [Conditional( "DEBUG" )]
        public static void AssertError( bool condition, Exception exception )
        {
            if ( condition ) return;

            throw exception;
        }

        [Conditional( "DEBUG" )]
        public static void AssertInvalid( bool condition, string valueName, object value, InvalidReason reason ) =>
            AssertError( condition, ExceptionUtils.Get( valueName, value, reason ) );

        [Conditional( "DEBUG" )]
        public static void AssertInvalid( bool condition, string valueName, InvalidReason reason ) =>
            AssertError( condition, ExceptionUtils.Get( valueName, reason ) );
    }
}
