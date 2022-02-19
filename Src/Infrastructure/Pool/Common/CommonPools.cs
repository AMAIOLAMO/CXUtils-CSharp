using CXUtils.Infrastructure;

namespace CXUtils.Common
{
    public static class CommonPools
    {
        static StringBuilderPool stringBuilderPool;

        public static StringBuilderPool StringBuilder => stringBuilderPool ??= CommonPoolFactory.CreateStringBuilder();
    }
}
