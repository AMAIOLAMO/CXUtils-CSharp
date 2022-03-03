using System;
using System.Collections.Generic;

namespace CXUtils.Domain.Types
{
    public interface IVector<T, TValue> : IEquatable<T>, IFormattable
    {
        T Min( T other );
        T Max( T other );

        /// <summary>
        ///     Maps the <paramref name="func" /> to all axis
        /// </summary>
        T Map( Func<TValue, TValue> func );
        TValue Dot( T other );
    }

    public interface IVectorInt<T> : IVector<T, int>, IEnumerable<T>
    {
    }

    public interface IVectorFloat<T> : IVector<T, float>
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
        T AsMagnitude( float value );
    }
}
