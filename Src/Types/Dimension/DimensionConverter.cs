using System;
using CXUtils.Common;
using CXUtils.Types;

namespace CXUtils.PlaneSystem
{
    /// <summary>
    ///     Options for Plane Dimensions
    /// </summary>
    public enum DimensionType { XY, XZ, YZ }

    /// <summary>
    ///     A data structure for converting plane axis to 3D axis
    /// </summary>
    public readonly struct DimensionConverter : IEquatable<DimensionConverter>, IFormattable
    {
        public DimensionConverter( DimensionType dimension ) => this.dimension = dimension;

        public readonly DimensionType dimension;

        /// <summary>
        /// Samples a plane position and converts to a world position according to the plane
        /// </summary>
        public Float3 Sample( Float2 planePosition )
        {
            switch ( dimension )
            {
                case DimensionType.XY: return new Float3( planePosition.x, planePosition.y, 0 );
                case DimensionType.XZ: return new Float3( planePosition.x, 0, planePosition.y );
                case DimensionType.YZ: return new Float3( 0f, planePosition.x, planePosition.y );
                
                default: throw ExceptionUtils.Error.NotAccessible;
            }
        }

        public bool Equals( DimensionConverter other ) => other.dimension.Equals( dimension );
        public string ToString( string format, IFormatProvider formatProvider ) => "dimension: " + dimension;
    }
}
