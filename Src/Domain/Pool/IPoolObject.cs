using System;

namespace CXUtils.Domain
{
    /// <summary>
    ///     Implements a simple wrapper around a object that is pooled <br/>
    ///     == NOTE ==
    ///     Use using on this
    /// </summary>
    public interface IPoolObject<out T> : IDisposable
    {
        T Get();
    }
}
