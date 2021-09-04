using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

namespace CXUtils.Utilities.Tests
{
    /// <summary>
    ///     A utility class all for testing
    /// </summary>
    public static class TestUtils
    {
        const BindingFlags TEST_ATTRIBUTE_METHOD_FLAGS = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        ///     Runs all the test attribute bounded methods
        /// </summary>
        public static void RunTests()
        {
            var methods =
                ( from type in Assembly.GetCallingAssembly().GetTypes()
                    from method in type.GetMethods( TEST_ATTRIBUTE_METHOD_FLAGS )
                    from attribute in method.GetCustomAttributes<TestAttribute>()
                    select method ).ToArray();

            if ( methods.Length == 0 )
                throw new Exception( $"There's no {nameof( TestAttribute )} in the Calling Assembly, cannot Run Tests!" );
            //else

            foreach ( var method in methods ) method.Invoke( null, null );
        }

        public static IEnumerable<StopWatchTestResult> RunStopWatchTests()
        {
            var methods =
                ( from type in Assembly.GetCallingAssembly().GetTypes()
                    from method in type.GetMethods( TEST_ATTRIBUTE_METHOD_FLAGS )
                    from attribute in method.GetCustomAttributes<StopWatchTestAttribute>()
                    select method ).ToArray();

            if ( methods.Length == 0 )
                throw new Exception( $"There's no {nameof( StopWatchTestAttribute )} in the Calling Assembly, cannot Run StopWatch tests!" );
            //else

            var stopWatch = new Stopwatch();

            var results = new StopWatchTestResult[methods.Length];

            for ( int i = 0; i < methods.Length; ++i )
            {
                var method = methods[i];
                stopWatch.Restart();
                method.Invoke( null, null );
                stopWatch.Stop();

                results[i] = new StopWatchTestResult( methods[i], stopWatch.ElapsedMilliseconds );
            }

            return results;
        }

        public static UnitTestResult[] RunUnitTests()
        {
            var methods =
                ( from type in Assembly.GetCallingAssembly().GetTypes()
                    from method in type.GetMethods( TEST_ATTRIBUTE_METHOD_FLAGS )
                    where method.ReturnType == typeof( bool )
                    from attribute in method.GetCustomAttributes<UnitTestAttribute>()
                    select method ).ToArray();

            if ( methods.Length == 0 )
                throw new Exception( $"There's no {nameof( UnitTestAttribute )} in the Calling Assembly, cannot Run Unit tests!" );

            //else
            var results = new UnitTestResult[methods.Length];

            for ( int i = 0; i < methods.Length; ++i ) results[i] = new UnitTestResult( methods[i], (bool)methods[i].Invoke( null, null ) );

            return results;
        }
    }
}
