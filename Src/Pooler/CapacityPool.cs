using System;

namespace CXUtils.Common
{
    public class CapacityPool<T> : PoolBase<T>
    {
        public int Capacity { get; protected set; }

        public CapacityPool( int capacity, Func<T> factory )
        {
            Capacity = capacity;
            for ( int i = 0; i < capacity; ++i ) Push( factory() );
        }
    }
}
