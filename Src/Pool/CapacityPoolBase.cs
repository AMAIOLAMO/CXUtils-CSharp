using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
    public abstract class CapacityPoolBase<T> : PoolBase<T>
    {
        public CapacityPoolBase( int capacity, IPoolItemFactory<T> itemFactory, IPoolObjectFactory<T> poolObjectFactory ) :
            base( itemFactory, poolObjectFactory ) => Capacity = capacity;

        public int Capacity { get; }
    }
}
