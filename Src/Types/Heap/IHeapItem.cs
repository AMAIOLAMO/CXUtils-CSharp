using System;

namespace CXUtils.Common.Generic
{
    /// <summary> A single heap item </summary>
    public interface IHeapItem<in T> : IComparable<T> where T : class
    {
        int HeapIndex { get; set; }
    }

}
