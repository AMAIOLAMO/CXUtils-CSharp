namespace CXUtils.Common
{
    public abstract class CapacityPoolBase<T> : PoolBase<T>
    {
        public CapacityPoolBase( int capacity ) => Capacity = capacity;

        public int Capacity { get; }
    }
}
