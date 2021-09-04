using System;

namespace CXUtils.Types
{
    /// <summary>
    /// Implements a modifiable for a target value
    /// </summary>
    public interface IAffectable<T>
    {
        T Value { get; }

        int RegisterEffect(in Func<T, T> modifier);
        void UnRegisterEffect(int value);
        bool TryUnRegisterEffect(int value);

        T GetAffected();
    }
}
