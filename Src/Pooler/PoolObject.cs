using System;
using System.Collections.Generic;

namespace CXUtils.Common
{
    /// <summary>
    ///     A wrapper around the pooled object so that it could be disposed
    /// </summary>
    public sealed class PoolObject<T> : IDisposable
    {
        readonly T           _pooledObject;
        readonly PoolBase<T> _rootPool;
        
        public PoolObject( T pooledObject, PoolBase<T> root )
        {
            _pooledObject = pooledObject;
            _rootPool = root;
        }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            if ( IsDisposed ) return;

            IsDisposed = true;
            _rootPool.Free( this );
        }

        public T Get() => _pooledObject;
        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) ) return false;
            if ( ReferenceEquals( this, obj ) ) return true;

            return obj.GetType() == GetType() && Equals( (PoolObject<T>)obj );
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = EqualityComparer<T>.Default.GetHashCode( _pooledObject );
                hashCode = ( hashCode * 397 ) ^ ( _rootPool != null ? _rootPool.GetHashCode() : 0 );
                return hashCode;
            }
        }
    }
}
