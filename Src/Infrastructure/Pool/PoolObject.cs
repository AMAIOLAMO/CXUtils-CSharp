using System.Collections.Generic;
using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
	/// <summary>
	///     A wrapper around the pooled object so that it could be automatically disposed
	/// </summary>
	public sealed class PoolObject<T> : IPoolObject<T>
	{
		public PoolObject(T value, IPoolBase<T> root)
		{
			pooledObject = value;
			rootPool = root;
		}

		public void Dispose()
		{
			if (disposed) return;

			disposed = true;
			rootPool.Free(this);
		}

		public T Get() => pooledObject;
		
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = EqualityComparer<T>.Default.GetHashCode(pooledObject);
				hashCode = (hashCode * 397) ^ (rootPool != null ? rootPool.GetHashCode() : 0);
				return hashCode;
			}
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;

			return obj.GetType() == GetType() && Equals((PoolObject<T>)obj);
		}
		readonly IPoolBase<T> rootPool;

		readonly T pooledObject;

		bool disposed;
	}
}
