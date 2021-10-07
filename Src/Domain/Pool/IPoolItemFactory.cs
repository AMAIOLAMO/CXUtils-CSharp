namespace CXUtils.Domain
{
    public interface IPoolItemFactory<T>
    {
        T Create();
        T Release( T item );
    }
}
