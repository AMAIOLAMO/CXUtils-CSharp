using System.Text;
using CXUtils.Common;
using CXUtils.Domain;

namespace CXUtils.Utilities.Array
{
	public static class ArrayUtils
	{
		public static string ToFormatString<T>(this T[] array, string between = ", ")
		{
			using IPoolItem _ = CommonPools.StringBuilder.PopScope(out StringBuilder builder);

			for (int i = 0; i < array.Length - 1; ++i)
			{
				builder.Append(array[i]);
				builder.Append(between);
			}

			//and last
			builder.Append(array.LastElement());

			return builder.ToString();
		}

		public static T LastElement<T>(this T[] array) =>
			array[array.Length - 1];

		public static T FirstElement<T>(this T[] array) =>
			array[0];
	}
}
