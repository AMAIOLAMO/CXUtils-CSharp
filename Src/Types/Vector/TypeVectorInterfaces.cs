using System;

namespace CXUtils.Types
{
    public interface ITypeVector<T, TValue> : IEquatable<T>, IFormattable
    {
        T Min( T other );
        T Max( T other );

        /// <summary>
        ///     Maps the <paramref name="mapFunction" /> to all axis
        /// </summary>
        T MapAxis( Func<TValue, TValue> mapFunction );
        TValue Dot( T other );
    }

    public interface ITypeVectorInt<T> : ITypeVector<T, int>
    {
    }

    public interface ITypeVectorFloat<T> : ITypeVector<T, float>
    {
        T Normalized { get; }

        float SqrMagnitude { get; }
        float Magnitude    { get; }

        T Floor { get; }
        T Ceil  { get; }

        T Halve { get; }

        T Reflect( T normal );

        /// <summary>
        ///     returns a new vector with a new magnitude of value
        /// </summary>
        T MagnitudeOf( float value );
    }
}
