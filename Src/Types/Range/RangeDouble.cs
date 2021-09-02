using CXUtils.Common;

namespace CXUtils.Types.Range
{
    public readonly struct RangeDouble : IRangeType<double>
    {
        public RangeDouble( double min, double max ) => ( Min, Max ) = ( min, max );

        public double Min { get; }
        public double Max { get; }

        public double Delta => Max - Min;

        public double Clamp( double value ) => MathUtils.Clamp( value, Min, Max );
        public bool Intersect( double value ) => !( value < Min || value > Max );
        public double Loop( double value ) => ( value - Min ).Loop( Max - Min );

        public double MapFrom( double value, IRangeType<double> inRange ) => MathUtils.Map( value, inRange.Min, inRange.Max, Min, Max );
        public double MapFrom( double value, double inMin, double inMax ) => MathUtils.Map( value, inMin, inMax, Min, Max );
        public double MapTo( double value, IRangeType<double> outRange ) => MathUtils.Map( value, Min, Max, outRange.Min, outRange.Max);
        public double MapTo( double value, double outMin, double outMax ) => MathUtils.Map( value, Min, Max, outMin, outMax);
    }
}
