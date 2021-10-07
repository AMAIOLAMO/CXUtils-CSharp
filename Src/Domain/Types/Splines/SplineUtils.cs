namespace CXUtils.Domain.Types
{
    public static class SplineUtils
    {
        /// <summary>
        ///     Is this index a control point?
        /// </summary>
        public static bool IsControl( int pointIndex ) => pointIndex % 3 != 0;

        /// <summary>
        ///     Is this index an anchor point?
        /// </summary>
        public static bool IsAnchor( int pointIndex ) => pointIndex % 3 == 0;

        /// <summary>
        ///     Converts segment index to point index
        /// </summary>
        public static int SegmentIndexToPointIndex( int segmentIndex ) => segmentIndex * 3;

        /// <summary>
        ///     Converts point index to segment index
        /// </summary>
        public static int PointIndexToSegmentIndex( int pointIndex ) => pointIndex / 3;
    }
}
