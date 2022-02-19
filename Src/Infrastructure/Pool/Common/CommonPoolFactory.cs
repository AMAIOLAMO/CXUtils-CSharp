using CXUtils.Infrastructure;

namespace CXUtils.Common
{
    /// <summary>
    ///     A common pooler factory, if a pool has capacity, it will use <see cref="CommonPoolCapacity" />
    /// </summary>
    public static class CommonPoolFactory
    {
        public const int CommonPoolCapacity = 5;

        public static StringBuilderPool CreateStringBuilder() => new StringBuilderPool( CommonPoolCapacity );
    }
}
