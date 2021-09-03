using System.Reflection;

namespace CXUtils.Utilities.Tests
{
    public readonly struct UnitTestResult
    {
        public readonly MethodInfo methodInfo;
        public readonly bool       isSuccess;

        public UnitTestResult( MethodInfo methodInfo, bool isSuccess )
        {
            this.methodInfo = methodInfo;
            this.isSuccess = isSuccess;
        }
    }
}
