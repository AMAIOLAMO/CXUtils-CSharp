using CXUtils.Common;

namespace CXUtils.Types.Range
{
    public interface IRangeType<T>
    {
        T Min { get; }
        T Max { get; }

        /// <summary>
        ///     The Difference between <see cref="Min" /> and <see cref="Max" /> (<see cref="Max" /> - <see cref="Min" />)
        /// </summary>
        T Delta { get; }

        /// <summary>
        ///     Clamps the given <paramref name="value" /> between <see cref="Min" /> ~ <see cref="Max" />
        /// </summary>
        T Clamp( T value );

        /// <summary>
        ///     Maps the given <paramref name="value" /> from the given <paramref name="inRange"/> to <see cref="Min"/> ~ <see cref="Max"/>
        /// </summary>
        T MapFrom( T value, IRangeType<T> inRange );
        /// <summary>
        ///     Maps the given <paramref name="value" /> from the given <paramref name="inMin"/> ~ <paramref name="inMax"/> to <see cref="Min"/> ~ <see cref="Max"/>
        /// </summary>
        T MapFrom( T value, T inMin, T inMax );
        
        /// <summary>
        ///     Maps the given <paramref name="value" /> from <see cref="Min"/> ~ <see cref="Max"/> to the given <paramref name="outRange"/>
        /// </summary>
        T MapTo( T value, IRangeType<T> outRange );
        /// <summary>
        ///     Maps the given <paramref name="value" /> from the given <paramref name="outMin"/> ~ <paramref name="outMax"/> to <see cref="Min"/> ~ <see cref="Max"/>
        /// </summary>
        T MapTo( T value, T outMin, T outMax );

        /// <summary>
        ///     Checks if <paramref name="value" /> is in the range of <see cref="Min" />(Included) ~ <see cref="Max" />(Included)
        /// </summary>
        bool Intersect( T value );

        /// <summary>
        ///     Wraps the given <paramref name="value" /> between <see cref="Min" /> ~ <see cref="Max" />
        /// </summary>
        T Loop( T value );
    }

    public readonly struct RangeFloat : IRangeType<float>
    {
        public RangeFloat( float min, float max ) => ( Min, Max ) = ( min, max );

        public float Min { get; }
        public float Max { get; }

        public float Delta => Max - Min;

        public float Clamp( float value ) => MathUtils.Clamp( value, Min, Max );
        public bool Intersect( float value ) => !( value < Min || value > Max );
        public float Loop( float value ) => ( value - Min ).Loop( Max - Min );

        public float MapFrom( float value, IRangeType<float> inRange ) => MathUtils.Map( value, inRange.Min, inRange.Max, Min, Max );
        public float MapFrom( float value, float inMin, float inMax ) => MathUtils.Map( value, inMin, inMax, Min, Max );
        public float MapTo( float value, IRangeType<float> outRange ) => MathUtils.Map( value, Min, Max, outRange.Min, outRange.Max);
        public float MapTo( float value, float outMin, float outMax ) => MathUtils.Map( value, Min, Max, outMin, outMax);
    }

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

    public readonly struct RangeInt : IRangeType<int>
    {
        public RangeInt( int min, int max ) => ( Min, Max ) = ( min, max );

        public int Min { get; }
        public int Max { get; }

        public int Delta => Max - Min;

        public int Clamp( int value ) => MathUtils.Clamp( value, Min, Max );
        public bool Intersect( int value ) => !( value < Min || value > Max );
        public int Loop( int value ) => ( value - Min ).Loop( Max - Min );

        public int MapFrom( int value, IRangeType<int> inRange ) => MathUtils.Map( value, inRange.Min, inRange.Max, Min, Max );
        public int MapFrom( int min, int inMin, int inMax ) => MathUtils.Map( inMax, min, inMin, Min, Max );
        public int MapTo( int value, IRangeType<int> outRange ) => MathUtils.Map( value, Min, Max, outRange.Min, outRange.Max);
        public int MapTo( int value, int outMin, int outMax ) => MathUtils.Map( value, Min, Max, outMin, outMax);
    }
}
