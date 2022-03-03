using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
	/// <summary>
	///     Represents a grid where cells are tightly grouped together
	/// </summary>
	public abstract class TightGrid2<T> : GridBase2<T>
	{
		protected TightGrid2(in Float2 cellSize, in Float2 origin = default) : base(cellSize, origin) { }


		public override Float2 CellToGlobal(in Int2 cell) => (Float2)cell * CellSize + Origin;

		public override Int2 GlobalToCell(in Float2 global) => (GlobalToLocal(global) / CellSize).FloorInt;

		public override Float2 LocalToGlobal(in Float2 local) => local + Origin;
		
		public override Float2 GlobalToLocal(in Float2 global) => global - Origin;
	}
}
