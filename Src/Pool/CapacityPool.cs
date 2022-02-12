using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
    public class CapacityPool<T> : CapacityPoolBase<T>
    {
        public CapacityPool( int capacity, IPoolItemFactory<T> itemFactory, IPoolObjectFactory<T> poolObjectFactory ) :
            base( capacity, itemFactory, poolObjectFactory ) => Populate( capacity );
    }
}
