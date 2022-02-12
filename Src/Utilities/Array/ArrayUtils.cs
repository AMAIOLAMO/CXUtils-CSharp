using System.Text;
using CXUtils.Common;
using CXUtils.Domain;

namespace CXUtils.Utilities.Array
{
	public static class ArrayUtils
	{
		public static string ToFormatString<T>(this T[] array, string between = ", ")
		{
			using IPoolObject<StringBuilder> poolObj = CommonPools.StringBuilder.Pop(out StringBuilder builder);

			for (int i = 0; i < array.Length - 1; ++i)
			{
				builder.Append(array[i]);
				builder.Append(between);
			}

			//and last
			builder.Append(array[array.Length - 1]);

			return builder.ToString();
		}
	}
}
