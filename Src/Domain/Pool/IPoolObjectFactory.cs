namespace CXUtils.Domain
{
    public interface IPoolObjectFactory<T>
    {
        public IPoolObject<T> Create( T obj, IPoolBase<T> pooler );
    }
}
