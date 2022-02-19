using System.Collections.Generic;
using System.Diagnostics;
using CXUtils.Domain;
#if DEBUG
using CXUtils.Common;
#endif

namespace CXUtils.Infrastructure
{
	/// <summary>
	///     A basic pooling class
	/// </summary>
	public abstract class PoolBase<T> : IPoolBase<T>
	{
		readonly IPoolItemFactory<T>   itemFactory;
		readonly IPoolObjectFactory<T> poolObjectFactory;

		readonly object @lock = new();

		#if DEBUG
		readonly HashSet<IPoolObject<T>> _occupiedObjects;
		#endif

		readonly Queue<T> poolObjects;

		protected PoolBase(IPoolItemFactory<T> itemFactory, IPoolObjectFactory<T> poolObjectFactory)
		{
			poolObjects = new Queue<T>();
			#if DEBUG
			_occupiedObjects = new HashSet<IPoolObject<T>>();
			#endif

			this.itemFactory = itemFactory;
			this.poolObjectFactory = poolObjectFactory;
		}

		public int Count => poolObjects.Count;

		public IPoolObject<T> Pop()
		{
			Debug.Assert(poolObjects.Count != 0, "cannot pop from an empty pool!");

			IPoolObject<T> poolObject;

			lock (@lock)
			{
			#if DEBUG
				_occupiedObjects.Add(poolObject = _poolObjectFactory.Create(_poolObjects.Dequeue(), this));
			#else
				poolObject = poolObjectFactory.Create(poolObjects.Dequeue(), this);
			#endif
			}

			return poolObject;
		}

		public IPoolObject<T> Pop(out T item)
		{
			IPoolObject<T> poolObj = Pop();
			item = poolObj.Get();
			return poolObj;
		}

		public void Free(IPoolObject<T> poolObject)
		{
			//remove from occupied objects
			#if DEBUG
			_occupiedObjects.Remove(poolObject);
			#endif
			//then put in pool
			poolObjects.Enqueue(itemFactory.Release(poolObject.Get()));
		}

		void Push(T item) => poolObjects.Enqueue(item);

        #if DEBUG
        ~PoolBase()
        {
            if ( _occupiedObjects.Count == 0 ) return;
            //else

            throw ExceptionUtils.MemoryNotReleased;
        }
        #endif

		/// <summary>
		///     Populates the pool using <see cref="itemFactory" />
		/// </summary>
		protected void Populate(int amount)
		{
			for (int i = 0; i < amount; ++i) Push(itemFactory.Create());
		}
	}
}
