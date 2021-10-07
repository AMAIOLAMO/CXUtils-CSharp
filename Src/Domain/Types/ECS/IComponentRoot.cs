﻿namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     Implements a Root for child Components
    /// </summary>
    public interface IComponentRoot<T> where T : IComponentRoot<T>
    {
        public TChild Find<TChild>() where TChild : ChildComponent<T>;
        public bool TryFind<TChild>( out TChild component ) where TChild : ChildComponent<T>;
    }
}