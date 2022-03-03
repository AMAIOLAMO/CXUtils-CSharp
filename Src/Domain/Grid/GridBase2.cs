using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
	public abstract class GridBase2<T> : IGrid2<T>
	{
		protected GridBase2(in Float2 cellSize, in Float2 origin) =>
			(Origin, CellSize) = (origin, cellSize);

		protected GridBase2(in Float2 cellSize) :
			this(cellSize, Float2.Zero)
		{
		}

		public abstract T this[int x, int y] { get; set; }
		public abstract T this[in Int2 cell] { get; set; }

		public Float2 CellSize { get; }
		public Float2 Origin   { get; }

		public float HalfCellX => CellSize.x / 2f;
		public float HalfCellY => CellSize.y / 2f;

		/// <summary>
		///     The half size of the cell size
		/// </summary>
		public Float2 HalfCellSize => CellSize.Halve;

		#region Utilities

		public virtual Float2 CellToGlobal(int x, int y) => CellToGlobal(new Int2(x, y));
		public abstract Float2 CellToGlobal(in Int2 cell);

		public virtual Int2 GlobalToCell(float x, float y) => GlobalToCell(new Float2(x, y));
		public abstract Int2 GlobalToCell(in Float2 global);

		public virtual Float2 LocalToGlobal(float x, float y) => LocalToGlobal(new Float2(x, y));
		public abstract Float2 LocalToGlobal(in Float2 local);

		public virtual Float2 GlobalToLocal(float x, float y) => GlobalToLocal(new Float2(x, y));
		public abstract Float2 GlobalToLocal(in Float2 global);

		public virtual void Swap(int x1, int y1, int x2, int y2) =>
			(this[x1, y1], this[x2, y2]) = (this[x2, y2], this[x1, y1]);

		public virtual void Swap(in Int2 cell1, in Int2 cell2) =>
			(this[cell1], this[cell2]) = (this[cell2], this[cell1]);

		public virtual string ToString(int x, int y) => this[x, y].ToString();
		public virtual string ToString(in Int2 cell) => this[cell.x, cell.y].ToString();

		#endregion
	}
}
