using System.Collections.Generic;
using System.Diagnostics;

namespace CXUtils.Common
{
    /// <summary>
    ///     A basic pooling class
    /// </summary>
    public abstract class PoolBase<T>
    {
        protected readonly HashSet<PoolObject<T>> occupiedObjects;
        protected readonly Queue<T>               poolObjects;

        protected PoolBase()
        {
            poolObjects = new Queue<T>();
            occupiedObjects = new HashSet<PoolObject<T>>();
        }

        public int Count => poolObjects.Count;

        #if DEBUG
        ~PoolBase()
        {
            if ( occupiedObjects.Count == 0 ) return;
            //else

            throw ExceptionUtils.MemoryNotReleased;
        }
        #endif

        public PoolObject<T> Pop()
        {
            Debug.Assert( poolObjects.Count != 0, "cannot pop from an empty pool!" );
            var poolObject = new PoolObject<T>( poolObjects.Dequeue(), this );
            occupiedObjects.Add( poolObject );
            return poolObject;
        }

        protected void Push( T obj ) => poolObjects.Enqueue( obj );

        public void Free( PoolObject<T> poolObject )
        {
            //remove from occupied objects
            occupiedObjects.Remove( poolObject );
            //then put in pool
            poolObjects.Enqueue( ItemRelease( poolObject.Get() ) );
        }

        protected abstract T ItemRelease( T value );
    }
}
