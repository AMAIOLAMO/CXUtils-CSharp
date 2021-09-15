using System;
using System.Runtime.InteropServices;
using CXUtils.Common;

namespace CXUtils.Types.Range
{
    [Serializable]
    [StructLayout( LayoutKind.Explicit )]
    public readonly struct RangeFloat : IRangeType<float>
    {
        public RangeFloat( float min, float max ) => ( Min, Max ) = ( min, max );

        [field: FieldOffset( 0 )] public float Min { get; }
        [field: FieldOffset( 4 )] public float Max { get; }

        public float Delta => Max - Min;

        public float Clamp( float value ) => MathUtils.Clamp( value, Min, Max );
        public bool Intersect( float value ) => !( value < Min || value > Max );
        public float Loop( float value ) => ( value - Min ).Loop( Max - Min );

        public float MapFrom( float value, IRangeType<float> inRange ) => MathUtils.Map( value, inRange.Min, inRange.Max, Min, Max );
        public float MapFrom( float value, float inMin, float inMax ) => MathUtils.Map( value, inMin, inMax, Min, Max );
        public float MapTo( float value, IRangeType<float> outRange ) => MathUtils.Map( value, Min, Max, outRange.Min, outRange.Max );
        public float MapTo( float value, float outMin, float outMax ) => MathUtils.Map( value, Min, Max, outMin, outMax );
    }
}
