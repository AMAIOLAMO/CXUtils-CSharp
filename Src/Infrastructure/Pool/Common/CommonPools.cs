using CXUtils.Infrastructure;

namespace CXUtils.Common
{
    public static class CommonPools
    {
        static StringBuilderPool _stringBuilderPool;

        public static StringBuilderPool StringBuilder => _stringBuilderPool ??= CommonPoolFactory.CreateStringBuilder();
    }
}
