using System.Diagnostics;

namespace CXUtils.Utilities
{
    public static class BezierUtils
    {
        [Conditional( "DEBUG" )]
        public static void AssertPoints<T>( T[] bezierData ) => Debug.Assert( bezierData.Length == 4, nameof( bezierData ) + " must have 4 points to create a segment!" );
    }
}
