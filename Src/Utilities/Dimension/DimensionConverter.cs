using CXUtils.Common;
using CXUtils.Domain.Types;
using CXUtils.Domain.Types.Utils;

namespace CXUtils.Utilities
{

    /// <summary>
    ///     A data structure for converting plane axis to 3D axis
    /// </summary>
    public static class DimensionConverter
    {
        /// <summary>
        ///     Samples a plane position and converts to a world position according to the plane
        /// </summary>
        public static Float3 To( Float2 position, DimensionType type )
        {
            switch ( type )
            {
                case DimensionType.XY: return position;
                case DimensionType.XZ: return position.X_Y();
                case DimensionType.YZ: return position._XY();

                default: throw ExceptionUtils.PossibilityNotImplemented;
            }
        }
    }
}
