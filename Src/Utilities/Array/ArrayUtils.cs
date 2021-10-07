using CXUtils.Common;

namespace CXUtils.Utilities.Array
{
    public static class ArrayUtils
    {
        public static string ToString<T>( this T[] array, string between = ", " )
        {
            using var poolObj = CommonPools.StringBuilder.Pop( out var builder );

            for ( int i = 0; i < array.Length - 1; ++i )
            {
                builder.Append( array[i] );
                builder.Append( between );
            }
            //and last
            builder.Append( array[array.Length - 1] );

            return builder.ToString();
        }
    }
}
