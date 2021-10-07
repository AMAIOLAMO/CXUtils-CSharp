using System.Diagnostics;

namespace CXUtils.Domain.Types
{
    public static class BezierHelper
    {
        [Conditional( "DEBUG" )]
        public static void AssertPoints<T>( T[] bezierData ) => Debug.Assert( bezierData.Length == 4, nameof( bezierData ) + " must have 4 points to create a segment!" );
    }
}
