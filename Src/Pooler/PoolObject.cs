using System;
using System.Collections.Generic;

namespace CXUtils.Common
{
    /// <summary>
    ///     A wrapper around the pooled object so that it could be disposed
    /// </summary>
    public sealed class PoolObject<T> : IDisposable, IEquatable<PoolObject<T>>
    {
        readonly T             _pooledObject;
        readonly PoolBase<T> _rootPool;

        public bool IsDisposed { get; private set; }

        public PoolObject(T pooledObject, PoolBase<T> root)
        {
            _pooledObject = pooledObject;
            _rootPool = root;
        }

        public T Get() => _pooledObject;

        public void Dispose()
        {
            if ( IsDisposed ) return;

            IsDisposed = true;
            _rootPool.Free(this);
        }
        
        public bool Equals( PoolObject<T> other )
        {
            if ( ReferenceEquals( null, other ) ) return false;
            if ( ReferenceEquals( this, other ) ) return true;

            return EqualityComparer<T>.Default.Equals( _pooledObject, other._pooledObject ) && Equals( _rootPool, other._rootPool ) && IsDisposed == other.IsDisposed;
        }
        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) ) return false;
            if ( ReferenceEquals( this, obj ) ) return true;
            
            return obj.GetType() == GetType() && Equals( (PoolObject<T>)obj );
        }
        
        public override int GetHashCode() => HashCode.Combine( _pooledObject, _rootPool );
    }
}
