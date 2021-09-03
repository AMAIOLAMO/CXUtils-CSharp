namespace CXUtils.Common
{
    public static class CommonPools
    {
        public const int COMMON_POOL_CAPACITY = 5;

        static        StringBuilderPool _stringBuilderPool;
        public static StringBuilderPool StringBuilder => _stringBuilderPool ??= new StringBuilderPool( COMMON_POOL_CAPACITY );
    }
}
