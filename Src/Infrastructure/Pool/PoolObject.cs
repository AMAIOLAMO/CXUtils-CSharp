using System.Collections.Generic;
using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
    /// <summary>
    ///     A wrapper around the pooled object so that it could be disposed
    /// </summary>
    public sealed class PoolObject<T> : IPoolObject<T>
    {
        readonly IPoolBase<T> _rootPool;
        readonly T            _pooledObject;

        bool _isDisposed;

        public PoolObject( T value, IPoolBase<T> root )
        {
            _pooledObject = value;
            _rootPool = root;
        }

        public void Dispose()
        {
            if ( _isDisposed ) return;

            _isDisposed = true;
            _rootPool.Free( this );
        }

        public T Get() => _pooledObject;

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = EqualityComparer<T>.Default.GetHashCode( _pooledObject );
                hashCode = ( hashCode * 397 ) ^ ( _rootPool != null ? _rootPool.GetHashCode() : 0 );
                return hashCode;
            }
        }
        
        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) ) return false;
            if ( ReferenceEquals( this, obj ) ) return true;

            return obj.GetType() == GetType() && Equals( (PoolObject<T>)obj );
        }
    }
}
