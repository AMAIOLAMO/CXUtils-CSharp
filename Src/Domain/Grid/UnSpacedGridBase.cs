using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
	/// <summary>
	///     Represents a grid where no space are in between
	/// </summary>
	public abstract class UnSpacedGridBase<T> : GridBase<T>
	{
		protected UnSpacedGridBase(Float2 cellSize, Float2 origin = default) : base(cellSize, origin) { }

		public override Float2 CellToGlobal(int x, int y) => new Float2(x, y) * CellSize + Origin;
		public override Float2 CellToGlobal(Int2 cell) => (Float2)cell * CellSize + Origin;

		public override Int2 GlobalToCell(float x, float y) => (GlobalToLocal(x, y) / CellSize).FloorInt;
		public override Int2 GlobalToCell(Float2 global) => (GlobalToLocal(global) / CellSize).FloorInt;

		public override Float2 LocalToGlobal(float x, float y) => new Float2(x, y) + Origin;
		public override Float2 LocalToGlobal(Float2 local) => local + Origin;

		public override Float2 GlobalToLocal(float x, float y) => new Float2(x, y) - Origin;
		public override Float2 GlobalToLocal(Float2 global) => global - Origin;
	}
}
