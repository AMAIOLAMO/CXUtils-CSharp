using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CXUtils.Utilities.Tests
{
    /// <summary>
    ///     A utility class all for testing
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        ///     Runs all the test attribute bounded methods
        /// </summary>
        public static void RunTests()
        {
            var methods =
            (
                from type in Assembly.GetCallingAssembly().GetTypes()
                from method in type.GetMethods( BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic )
                from attribute in method.GetCustomAttributes<TestAttribute>()
                select method
            ).ToArray();

            if ( methods.Length == 0 )
                throw new Exception( $"There's no {nameof( TestAttribute )} in the Executing Assembly, cannot Run Tests!" );
            //else

            foreach ( var method in methods ) method.Invoke( null, null );
        }

        public static long[] RunStopWatchTests()
        {
            var methods =
            (
                from type in Assembly.GetCallingAssembly().GetTypes()
                from method in type.GetMethods( BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic )
                from attribute in method.GetCustomAttributes<StopWatchTestAttribute>()
                select method
            ).ToArray();

            if ( methods.Length == 0 )
                throw new Exception( $"There's no {nameof( StopWatchTestAttribute )} in the Executing Assembly, cannot Run StopWatch tests!" );
            //else

            var stopWatch = new Stopwatch();

            long[] elapsedTimes = new long[methods.Length];

            for ( int i = 0; i < methods.Length; ++i )
            {
                var method = methods[i];
                stopWatch.Restart();
                method.Invoke( null, null );
                stopWatch.Stop();

                elapsedTimes[i] = stopWatch.ElapsedMilliseconds;
            }

            return elapsedTimes;
        }
    }
}
