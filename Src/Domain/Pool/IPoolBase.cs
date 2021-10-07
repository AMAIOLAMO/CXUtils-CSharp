namespace CXUtils.Domain
{
    public interface IPoolBase<T>
    {
        IPoolObject<T> Pop();
        IPoolObject<T> Pop( out T item );
        void Free( IPoolObject<T> poolObject );
    }
}
