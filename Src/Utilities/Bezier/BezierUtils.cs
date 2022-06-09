using System.Diagnostics;

namespace CXUtils.Utilities
{
	public static class BezierUtils
	{
		[Conditional("DEBUG")]
		public static void AssertPointArrayLength<T>(T[] bezierData, int position = 0) =>
			Debug.Assert(bezierData.Length == position + 4, $"{nameof(bezierData)} must have {(position + 4).ToString()} points to create a segment!");
	}
}
