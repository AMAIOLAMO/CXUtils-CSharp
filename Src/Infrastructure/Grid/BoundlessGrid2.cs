using System.Collections.Generic;
using System.Collections.ObjectModel;
using CXUtils.Domain;
using CXUtils.Domain.Types;

namespace CXUtils.Infrastructure
{
	/// <summary>
	///     A 2D Infinite sized / boundless grid system
	/// </summary>
	public class BoundlessGrid2<T> : TightGrid2<T>, INullableGrid2<T>
	{
		public BoundlessGrid2(in Float2 cellSize, in Float2 origin = default) : base(cellSize, origin) =>
			data = new Dictionary<Int2, T>();

		public override T this[int x, int y]
		{
			get => this[new Int2(x, y)];
			set => this[new Int2(x, y)] = value;
		}
		
		public override T this[in Int2 cell]
		{
			get => data[cell];
			set
			{
				if (data.ContainsKey(cell))
				{
					data[cell] = value;
					return;
				}

				//else
				data.Add(cell, value);
			}
		}

		public bool TryGetValue(int x, int y, out T value) =>
			TryGetValue(new Int2(x, y), out value);
		public bool TryGetValue(in Int2 cell, out T value)
		{
			value = default;

			if (!CellExists(cell))
				return false;

			value = this[cell];
			return true;
		}

		public bool TryPopCell(in Int2 cellPosition, out T value)
		{
			value = default;
			if (!CellExists(cellPosition))
				return false;

			value = PopCell(cellPosition);
			return true;
		}

		public bool TryPopCell(int x, int y, out T value) => TryPopCell(new Int2(x, y), out value);

		/// <summary>
		///     Removes the cell content from the grid and pops it out
		/// </summary>
		public T PopCell(in Int2 cellPosition)
		{
			T content = data[cellPosition];

			data.Remove(cellPosition);

			return content;
		}

		/// <inheritdoc cref="PopCell(Int2)" />
		public T PopCell(int x, int y) => PopCell(new Int2(x, y));

		public bool TryRemoveCell(in Int2 cell)
		{
			if (!CellExists(cell)) return false;
			// else
			
			RemoveCell(cell);
			return true;
		}

		public bool TryRemoveCell(int x, int y) => TryRemoveCell(new Int2(x, y));

		public void RemoveCell(in Int2 cell) => data.Remove(cell);
		public void RemoveCell(int x, int y) => RemoveCell(new Int2(x, y));


		public bool CellExists(in Int2 cell) => data.ContainsKey(cell);

		public bool CellExists(int x, int y) => CellExists(new Int2(x, y));

		public ReadOnlyDictionary<Int2, T> GetAllCells() => new ReadOnlyDictionary<Int2, T>(data);
		
		readonly Dictionary<Int2, T> data;
	}
}
