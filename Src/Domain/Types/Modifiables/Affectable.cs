using System;
using System.Collections.Generic;

namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     A modifiable value that could register values on it to modify the out come
    /// </summary>
    public sealed class Affectable<T> : IAffectable<T>
    {
        readonly Dictionary<int, Func<T, T>> _effects;
        public Affectable() => _effects = new Dictionary<int, Func<T, T>>();

        public Affectable( T initialValue )
        {
            Value = initialValue;
            _effects = new Dictionary<int, Func<T, T>>();
        }

        /// <summary>
        ///     The affected value
        /// </summary>
        public T Affected => GetAffected();
        /// <summary>
        ///     The unaffected value
        /// </summary>
        public T Value { get; set; }

        public T GetAffected()
        {
            var resultValue = Value;

            foreach ( var modifier in _effects.Values ) resultValue = modifier( resultValue );

            return resultValue;
        }

        public int RegisterEffect( in Func<T, T> modifier )
        {
            int hash;
            _effects.Add( hash = modifier.GetHashCode(), modifier );
            return hash;
        }

        public void UnRegisterEffect( int value ) => _effects.Remove( value );

        public bool TryUnRegisterEffect( int value )
        {
            if ( !_effects.ContainsKey( value ) ) return false;

            _effects.Remove( value );
            return true;
        }
    }
}
