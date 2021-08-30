using System;
using System.Collections.Generic;

namespace CXUtils.Types
{
    /// <summary>
    ///     A modifiable value that could register values on it to modify the out come
    /// </summary>
    public class Modifiable<T> : IModifiable<T>
    {
        public Modifiable() => ModifierDict = new Dictionary<int, Func<T, T>>();

        public Modifiable( T initialValue )
        {
            Value = initialValue;
            ModifierDict = new Dictionary<int, Func<T, T>>();
        }

        /// <summary>
        ///     A quick way of calling GetModified()
        /// </summary>
        public T Modified => GetModified();
        public T Value { get; set; }

        public Dictionary<int, Func<T, T>> ModifierDict { get; }

        public T GetModified()
        {
            var resultValue = Value;

            foreach ( var modifier in ModifierDict.Values )
                resultValue = modifier( resultValue );

            return resultValue;
        }

        public int RegisterModifier( in Func<T, T> modifier )
        {
            int hash;
            ModifierDict.Add( hash = modifier.GetHashCode(), modifier );
            return hash;
        }

        public void UnRegisterModifier( int value )
        {
            ModifierDict.Remove( value );
        }

        public bool TryUnRegisterModifier( int value )
        {
            if ( !ModifierDict.ContainsKey( value ) ) return false;

            ModifierDict.Remove( value );
            return true;
        }
    }
}
