using System.Diagnostics;
using CXUtils.Common;

namespace CXUtils.Types
{
    /// <summary>
    ///     A struct that represents a cubic bezier curve in 2D
    /// </summary>
    public readonly struct CubicBezier2D
    {
        readonly Float2[] _buffer;

        public Float2 Anchor1 => _buffer[0];
        public Float2 Control1 => _buffer[1];
        public Float2 Control2 => _buffer[2];
        public Float2 Anchor2 => _buffer[3];

        public CubicBezier2D( Float2 control1, Float2 anchor1, Float2 control2, Float2 anchor2 ) =>
            _buffer = new[] { anchor1, control1, control2, anchor2 };

        public CubicBezier2D( Float2[] points )
        {
            BezierHelper.AssertPoints(points);

            _buffer = points;
        }

        public Float2 Sample( float t ) => TweenUtils.CubicBezier( _buffer[0], _buffer[1], _buffer[2], _buffer[3], t );
    }

    /// <summary>
    ///     A struct that represents a cubic bezier curve in 2D
    /// </summary>
    public readonly struct CubicBezier3D
    {
        readonly Float3[] _buffer;

        public Float3 Anchor1 => _buffer[0];
        public Float3 Control1 => _buffer[1];
        public Float3 Control2 => _buffer[2];
        public Float3 Anchor2 => _buffer[3];

        public CubicBezier3D( Float3 control1, Float3 anchor1, Float3 control2, Float3 anchor2 ) =>
            _buffer = new[] { anchor1, control1, control2, anchor2 };

        public CubicBezier3D( Float3[] points )
        {
            BezierHelper.AssertPoints(points);

            _buffer = points;
        }

        public Float3 Sample( float t ) => TweenUtils.CubicBezier( _buffer[0], _buffer[1], _buffer[2], _buffer[3], t );
    }

    public static class BezierHelper
    {
        public static void AssertPoints<T>(T[] array) => Debug.Assert(array.Length == 4, nameof(array) + " must have 4 points to create a segment!");
    }
}
