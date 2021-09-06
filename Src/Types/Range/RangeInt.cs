using CXUtils.Common;
using System.Runtime.InteropServices;

namespace CXUtils.Types.Range
{
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct RangeInt : IRangeType<int>
    {
        public RangeInt( int min, int max ) => ( Min, Max ) = ( min, max );

        [field: FieldOffset( 0 )] public int Min { get; }
        [field: FieldOffset( 4 )] public int Max { get; }

        public int Delta => Max - Min;

        public int Clamp( int value ) => MathUtils.Clamp( value, Min, Max );
        public bool Intersect( int value ) => !( value < Min || value > Max );
        public int Loop( int value ) => ( value - Min ).Loop( Max - Min );

        public int MapFrom( int value, IRangeType<int> inRange ) => MathUtils.Map( value, inRange.Min, inRange.Max, Min, Max );
        public int MapFrom( int min, int inMin, int inMax ) => MathUtils.Map( inMax, min, inMin, Min, Max );
        public int MapTo( int value, IRangeType<int> outRange ) => MathUtils.Map( value, Min, Max, outRange.Min, outRange.Max );
        public int MapTo( int value, int outMin, int outMax ) => MathUtils.Map( value, Min, Max, outMin, outMax );
    }
}
