using System;
using CXUtils.Domain;
using CXUtils.Domain.Types;

namespace CXUtils.Infrastructure
{
	/// <summary>
	///     A 2D Limited size / bounded grid system
	/// </summary>
	/// <typeparam name="T">The type that each cell stores</typeparam>
	public class BoundGrid2<T> : UnSpacedGrid2<T>, INullableGrid2<T>
	{
		#region Utilities

		public bool ContainsCell(int x, int y) =>
			x < 0 || y < 0 ||
			x > Width || y > Height;

		public bool ContainsCell(Int2 cell) =>
			cell.x < 0 || cell.y < 0 ||
			cell.x > Width || cell.y > Height;

		/// <summary>
		///     If the Global position given is contained in the grid
		/// </summary>
		public bool ContainsGlobal(Float2 global) => ContainsLocal(GlobalToLocal(global));

		/// <summary>
		///     If the local position given is contained in the grid
		/// </summary>
		public bool ContainsLocal(Float2 local)
		{
			Float2 wholeSize = WholeSize;

			return !(local.x < 0f || local.y < 0f ||
					 local.x > wholeSize.x || local.y > wholeSize.y);
		}

		#endregion

		#region Fields

		readonly T[,] data;

		public int Width  { get; }
		public int Height { get; }

		public override T this[int x, int y]
		{
			get => data[x, y];
			set => data[x, y] = value;
		}

		public override T this[in Int2 cell]
		{
			get => data[cell.x, cell.y];
			set => data[cell.x, cell.y] = value;
		}


		/// <summary>
		///     The total cell count
		/// </summary>
		public int CellCount => Width * Height;

		/// <summary>
		///     The whole <see cref="BoundGrid2{T}" />'s size
		/// </summary>
		public Int2 GridSize => new Int2(Width, Height);

		public Float2 WholeSize => CellSize * (Float2)GridSize;

		#endregion

		#region Constructors

		public BoundGrid2(int width, int height, in Float2 cellSize, in Float2 origin) : base(cellSize, origin)
		{
			(Width, Height) = (width, height);
			data = new T[Width, Height];
		}

		public BoundGrid2(int width, int height, in Float2 cellSize) :
			this(width, height, cellSize, Float2.Zero)
		{
		}

		public BoundGrid2(in Int2 gridSize, in Float2 cellSize, in Float2 origin) :
			this(gridSize.x, gridSize.y, cellSize, origin)
		{
		}

		public BoundGrid2(in Int2 gridSize, in Float2 cellSize) :
			this(gridSize.x, gridSize.y, cellSize)
		{
		}

		#endregion

		#region Values

		#region SetValues

		/// <summary>
		///     Tries to set a value using grid position <br />
		///     Returns if sets correctly
		/// </summary>
		public bool TrySetValue(int x, int y, in T value)
		{
			if (!ContainsCell(x, y))
				return false;

			data[x, y] = value;
			return true;
		}

		/// <summary>
		///     Tries to set a value using grid position <br />
		///     Returns if sets correctly
		/// </summary>
		public bool TrySetValue(in Int2 cell, in T value) =>
			TrySetValue(cell.x, cell.y, value);

		#endregion

		#region GetValues

		/// <summary>
		///     Gets the value using grid position <br />
		///     Returns if the grid position is valid
		/// </summary>
		public bool TryGetValue(int x, int y, out T value)
		{
			if (ContainsCell(x, y))
			{
				value = data[x, y];
				return true;
			}
			value = default;
			return false;
		}

		/// <summary>
		///     Gets the value using grid position <br />
		///     Returns if the grid position is valid
		/// </summary>
		public bool TryGetValue(in Int2 cell, out T value) =>
			TryGetValue(cell.x, cell.y, out value);

		#endregion

		#endregion

		#region Value manipulation

		/// <summary>
		///     Sets all the value in the grid to the given value
		/// </summary>
		public void Fill(in T value = default)
		{
			for (int x = 0; x < Width; ++x)
				for (int y = 0; y < Height; ++y)
					data[x, y] = value;
		}

		public void Fill(Func<Int2, T> fillFunc)
		{
			for (int x = 0; x < Width; ++x)
				for (int y = 0; y < Height; ++y)
					data[x, y] = fillFunc(new Int2(x, y));
		}

		public void Fill(Func<int, int, T> fillFunc)
		{
			for (int x = 0; x < Width; ++x)
				for (int y = 0; y < Height; ++y)
					data[x, y] = fillFunc(x, y);
		}

		/// <summary>
		///     Uses this function onto all the values on the grid
		/// </summary>
		public void Map(Func<BoundGrid2<T>, int, int, T> mapFunc)
		{
			for (int x = 0; x < Width; ++x)
				for (int y = 0; y < Height; ++y)
					data[x, y] = mapFunc.Invoke(this, x, y);
		}

		#endregion
	}
}
