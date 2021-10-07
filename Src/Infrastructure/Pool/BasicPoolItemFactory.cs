using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
    public class BasicPoolItemFactory<T> : IPoolItemFactory<T> where T : new()
    {
        public T Create() => new T();
        public T Release( T item ) => item;
    }
}
