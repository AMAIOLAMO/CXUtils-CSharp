using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace CXUtils.Common
{
    /// <summary>
    ///     A wrapper around the pooled object so that it could be disposed
    /// </summary>
    public class PoolObject<T> : IDisposable
    {
        readonly T _pooledObject;
        readonly PoolerBase<T> _rootPooler;

        public bool IsDisposed { get; private set; }

        public PoolObject(T pooledObject, PoolerBase<T> root)
        {
            _pooledObject = pooledObject;
            _rootPooler = root;
        }

        public T Get() => _pooledObject;

        public virtual void Dispose()
        {
            if ( IsDisposed ) return;

            IsDisposed = true;
            _rootPooler.Free(this);
        }
    }

    /// <summary>
    ///     A basic pooling class that uses <see cref="IDisposable"/> with <see cref="PoolObject{T}"/>
    /// </summary>
    public class PoolerBase<T>
    {
        protected readonly Queue<T> poolObjects;
        protected readonly HashSet<PoolObject<T>> occupiedObjects;

        public int Count => poolObjects.Count;

        public PoolerBase()
        {
            poolObjects = new Queue<T>();
            occupiedObjects = new HashSet<PoolObject<T>>();
        }

        public PoolerBase(int capacity, Func<int, T> initializeFunction) : this()
        {
            Debug.Assert(initializeFunction != null, nameof(initializeFunction) + " cannot be null!");
            for(int i = 0; i < capacity; ++i ) poolObjects.Enqueue(initializeFunction(i));
        }

        public virtual PoolObject<T> Pop()
        {
            Debug.Assert(poolObjects.Count == 0, "pool is empty! cannot pop elements!");
            var poolObject = new PoolObject<T>(poolObjects.Dequeue(), this);
            occupiedObjects.Add(poolObject);
            return poolObject;
        }

        /// <summary>
        ///     Pushes an item into the pool
        /// </summary>
        public virtual void Push(T item) => poolObjects.Enqueue(item);

        public virtual void Free(PoolObject<T> poolObject)
        {
            //remove from occupied objects
            occupiedObjects.Remove(poolObject);
            //then put in pool
            poolObjects.Enqueue(poolObject.Get());
        }
    }
}
