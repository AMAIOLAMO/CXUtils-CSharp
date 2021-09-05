using System;

namespace CXUtils.Common
{
    public class CapacityPool<T> : PoolBase<T>
    {
        readonly Func<T, T> _releaseFactory;

        public CapacityPool( int capacity, Func<T> factory, Func<T, T> releaseFactory = null )
        {
            Capacity = capacity;
            for ( int i = 0; i < capacity; ++i ) Push( factory() );
            _releaseFactory = releaseFactory ?? DefaultItemReleaseFactory;
        }
        
        public int Capacity { get; protected set; }

        protected override T ItemRelease( T value ) => _releaseFactory( value );

        T DefaultItemReleaseFactory( T value ) => value;
    }
}
