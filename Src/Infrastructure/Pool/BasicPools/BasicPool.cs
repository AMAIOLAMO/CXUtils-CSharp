using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
    /// <summary>
    ///     A fairly basic pool <br />
    ///     == NOTE == <br/>
    ///     Can only create items with no arguments and no special action after freeing
    /// </summary>
    public class BasicPool<T> : PoolBase<T> where T : new()
    {
        public BasicPool() : base( new BasicPoolItemFactory<T>(), new BasicPoolObjectFactory<T>() ) { }
    }
}
