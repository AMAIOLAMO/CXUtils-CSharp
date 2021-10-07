using CXUtils.Common;
using CXUtils.Domain.Types;
using CXUtils.Domain.Types.Utils;

namespace CXUtils.PlaneSystem
{
    /// <summary>
    ///     Options for Plane Dimensions
    /// </summary>
    public enum DimensionType { XY, XZ, YZ }

    /// <summary>
    ///     A data structure for converting plane axis to 3D axis
    /// </summary>
    public static class DimensionConverter
    {
        /// <summary>
        ///     Samples a plane position and converts to a world position according to the plane
        /// </summary>
        public static Float3 ToFloat3( Float2 planePosition, DimensionType type )
        {
            switch ( type )
            {
                case DimensionType.XY: return planePosition;
                case DimensionType.XZ: return planePosition.X_Y();
                case DimensionType.YZ: return planePosition._XY();

                default: throw ExceptionUtils.PossibilityNotImplemented;
            }
        }
    }
}
