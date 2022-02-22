using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
	/// <summary>
	///     Represents a grid where no space are in between
	/// </summary>
	public abstract class UnSpacedGrid2<T> : GridBase2<T>
	{
		protected UnSpacedGrid2(in Float2 cellSize, in Float2 origin = default) : base(cellSize, origin) { }

		public override Float2 CellToGlobal(int x, int y) => new Float2(x, y) * CellSize + Origin;
		public override Float2 CellToGlobal(in Int2 cell) => (Float2)cell * CellSize + Origin;

		public override Int2 GlobalToCell(float x, float y) => (GlobalToLocal(x, y) / CellSize).FloorInt;
		public override Int2 GlobalToCell(in Float2 global) => (GlobalToLocal(global) / CellSize).FloorInt;

		public override Float2 LocalToGlobal(float x, float y) => new Float2(x, y) + Origin;
		public override Float2 LocalToGlobal(in Float2 local) => local + Origin;

		public override Float2 GlobalToLocal(float x, float y) => new Float2(x, y) - Origin;
		public override Float2 GlobalToLocal(in Float2 global) => global - Origin;
	}
}
