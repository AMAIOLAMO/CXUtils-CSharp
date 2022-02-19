using System;

namespace CXUtils.Common.Generic
{
	/// <summary>
	///     A simple heap
	/// </summary>
	public sealed class Heap<T> : ICloneable where T : class, IHeapItem<T>
	{
		public Heap(int size) => items = new T[size];

		/// <summary>
		///     Total length of not null items in this Heap
		/// </summary>
		public int Count { get; private set; }
		
		T[] items;

		#region Script Methods

		/// <summary>
		///     Check if this heap contains this item
		/// </summary>
		public bool Contains(T item) => Equals(items[item.HeapIndex], item);

		/// <summary>
		///     Adds an item to the bottom and sort it up
		/// </summary>
		public void Add(T item)
		{
			item.HeapIndex = Count;
			items[Count] = item;
			SortUp(item);
			++Count;
		}

		/// <summary>
		///     Pop the first item out
		/// </summary>
		public T PopFirst()
		{
			T firstItem = items[0];
			--Count;
			items[0] = items[Count];
			items[0].HeapIndex = 0;
			SortDown(items[0]);
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

				if (childIndexRight < Count && items[childIndexLeft].CompareTo(items[childIndexRight]) < 0) swapIndex = childIndexRight;

				if (item.CompareTo(items[swapIndex]) < 0) Swap(item, items[swapIndex]);

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
				T parentItem = items[parentIndex];

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
			(items[itemA.HeapIndex], items[itemB.HeapIndex]) = (itemB, itemA);
			(itemA.HeapIndex, itemB.HeapIndex) = (itemB.HeapIndex, itemA.HeapIndex);
		}

		public object Clone() => new Heap<T>(items.Length) { items = items.Clone() as T[] };

		#endregion
	}
}
