using CXUtils.Infrastructure;

namespace CXUtils.Common
{
    /// <summary>
    ///     A common pooler factory, if a pool has capacity, it will use <see cref="COMMON_POOL_CAPACITY" />
    /// </summary>
    public static class CommonPoolFactory
    {
        public const int COMMON_POOL_CAPACITY = 5;

        public static StringBuilderPool CreateStringBuilder() => new StringBuilderPool( COMMON_POOL_CAPACITY );
    }
}
