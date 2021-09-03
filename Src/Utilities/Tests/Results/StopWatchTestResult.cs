using System.Reflection;

namespace CXUtils.Utilities.Tests
{
    public readonly struct StopWatchTestResult
    {
        public readonly MethodInfo methodInfo;
        public readonly long       elapsedMilliseconds;

        public StopWatchTestResult( MethodInfo methodInfo, long elapsedMilliseconds )
        {
            this.methodInfo = methodInfo;
            this.elapsedMilliseconds = elapsedMilliseconds;
        }
    }
}
