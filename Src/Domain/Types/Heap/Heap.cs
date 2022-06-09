using System;

namespace CXUtils.Common.Generic
{
	/// <summary>
	///     A simple heap
	/// </summary>
	public sealed class Heap<T> : ICloneable where T : class, IHeapItem<T>
	{
		public Heap(int size) => _items = new T[size];

		/// <summary>
		///     Total length of not null items in this Heap
		/// </summary>
		public int Count { get; private set; }
		
		T[] _items;

		#region Script Methods

		/// <summary>
		///     Check if this heap contains this item
		/// </summary>
		public bool Contains(T item) => Equals(_items[item.HeapIndex], item);

		/// <summary>
		///     Adds an item to the bottom and sort it up
		/// </summary>
		public void Add(T item)
		{
			item.HeapIndex = Count;
			_items[Count] = item;
			SortUp(item);
			++Count;
		}

		/// <summary>
		///     Pop the first item out
		/// </summary>
		public T PopFirst()
		{
			T firstItem = _items[0];
			--Count;
			_items[0] = _items[Count];
			_items[0].HeapIndex = 0;
			SortDown(_items[0]);
			return firstItem;
		}

		/// <summary>
		///     Updates an item if an item needs to be sorted
		/// </summary>
		public void UpdateItem(T item)
		{
			SortUp(item);
			SortDown(item);
		}

		/// <summary>
		///     Sort the item down
		/// </summary>
		public void SortDown(T item)
		{
			while (true)
			{
				int childIndexLeft = item.HeapIndex * 2 + 1;
				int childIndexRight = childIndexLeft + 1;

				//if no child
				if (childIndexLeft >= Count)
					return;

				int swapIndex = childIndexLeft;

				if (childIndexRight < Count && _items[childIndexLeft].CompareTo(_items[childIndexRight]) < 0) swapIndex = childIndexRight;

				if (item.CompareTo(_items[swapIndex]) < 0) Swap(item, _items[swapIndex]);

				return;
			}
		}

		/// <summary>
		///     Sort the item up
		/// </summary>
		public void SortUp(T item)
		{
			int parentIndex = (item.HeapIndex - 1) / 2;
			while (true)
			{
				T parentItem = _items[parentIndex];

				if (item.CompareTo(parentItem) > 0) Swap(item, parentItem);
				else break;

				parentIndex = (item.HeapIndex - 1) / 2;
			}
		}

		/// <summary>
		///     swaps two items inside the heap
		/// </summary>
		public void Swap(T itemA, T itemB)
		{
			(_items[itemA.HeapIndex], _items[itemB.HeapIndex]) = (itemB, itemA);
			(itemA.HeapIndex, itemB.HeapIndex) = (itemB.HeapIndex, itemA.HeapIndex);
		}

		public object Clone() => new Heap<T>(_items.Length) { _items = _items.Clone() as T[] };

		#endregion
	}
}
