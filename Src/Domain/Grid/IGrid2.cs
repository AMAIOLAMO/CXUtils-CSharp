using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
	/// <summary>
	///     Implements a Grid in 2D
	/// </summary>
	public interface IGrid2<T>
	{
		/// <summary>
		///     Converts from cell to global position
		/// </summary>
		Float2 CellToGlobal(int x, int y);

		/// <inheritdoc cref="CellToGlobal(int,int)" />
		Float2 CellToGlobal(in Int2 cell);

		/// <summary>
		///     Converts global position to cell position
		/// </summary>
		Int2 GlobalToCell(float x, float y);

		/// <inheritdoc cref="GlobalToCell(float,float)" />
		Int2 GlobalToCell(in Float2 global);

		/// <summary>
		///     Converts from local position to global position
		/// </summary>
		Float2 LocalToGlobal(float x, float y);

		/// <inheritdoc cref="LocalToGlobal(float,float)" />
		Float2 LocalToGlobal(in Float2 local);

		/// <summary>
		///     Converts global position to local position
		/// </summary>
		Float2 GlobalToLocal(float x, float y);

		/// <inheritdoc cref="GlobalToLocal(float,float)" />
		Float2 GlobalToLocal(in Float2 global);

		/// <summary>
		///     Swaps two cells' contents
		/// </summary>
		void Swap(int x1, int y1, int x2, int y2);

		/// <inheritdoc cref="Swap(int,int,int,int)" />
		void Swap(in Int2 cell1, in Int2 cell2);

		string ToString(int x, int y);
		string ToString(in Int2 cell);

		T this[int x, int y] { get; set; }
		T this[in Int2 cell] { get; set; }
	}
}
