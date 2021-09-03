using System.Diagnostics;

namespace CXUtils.Types
{
    public static class BezierHelper
    {
        [Conditional("DEBUG")]
        public static void AssertPoints<T>(T[] array) => Debug.Assert(array.Length == 4, nameof(array) + " must have 4 points to create a segment!");
    }
}
