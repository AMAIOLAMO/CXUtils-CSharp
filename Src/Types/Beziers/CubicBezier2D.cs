using CXUtils.Common;

namespace CXUtils.Types
{
    /// <summary>
    ///     A struct that represents a cubic bezier curve in 2D
    /// </summary>
    public readonly struct CubicBezier2D
    {
        readonly Float2[] _buffer;

        public Float2 Anchor1  => _buffer[0];
        public Float2 Control1 => _buffer[1];
        public Float2 Control2 => _buffer[2];
        public Float2 Anchor2  => _buffer[3];

        public CubicBezier2D( Float2 control1, Float2 anchor1, Float2 control2, Float2 anchor2 ) =>
            _buffer = new[] { anchor1, control1, control2, anchor2 };

        public CubicBezier2D( Float2[] points )
        {
            BezierHelper.AssertPoints(points);

            _buffer = points;
        }

        public Float2 Sample( float t ) => TweenUtils.CubicBezier( _buffer[0], _buffer[1], _buffer[2], _buffer[3], t );
    }
}
