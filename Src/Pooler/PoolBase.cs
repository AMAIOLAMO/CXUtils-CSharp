using System.Diagnostics;
using System.Collections.Generic;

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

        public PoolObject<T> Pop( out T item )
        {
            var poolObj = Pop();
            item = poolObj.Get();
            return poolObj;
        }

        public void Free( PoolObject<T> poolObject )
        {
            //remove from occupied objects
            occupiedObjects.Remove( poolObject );
            //then put in pool
            poolObjects.Enqueue( ItemReleaseFactory( poolObject.Get() ) );
        }

        protected void Push( T item ) => poolObjects.Enqueue( item );

        protected void Populate( int amount )
        {
            for ( int i = 0; i < amount; ++i ) Push( CreateItemFactory() );
        }

        protected virtual T CreateItemFactory() => default;
        protected virtual T ItemReleaseFactory( T item ) => item;
    }
}
