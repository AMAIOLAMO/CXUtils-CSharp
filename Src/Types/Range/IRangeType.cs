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
}
