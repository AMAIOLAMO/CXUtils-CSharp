using CXUtils.Domain;
using CXUtils.Domain.Types;

namespace CXUtils.Domain
{
    public abstract class UnSpacedGridBase<T> : GridBase<T>
    {
        protected UnSpacedGridBase( Float2 cellSize, Float2 origin = default ) : base( cellSize, origin ) { }

        public override Float2 CellToWorld( int x, int y ) => new Float2( x, y ) * CellSize + Origin;
        public override Float2 CellToWorld( Int2 cellPosition ) => (Float2)cellPosition * CellSize + Origin;

        public override Int2 WorldToCell( float x, float y ) => ( WorldToLocal( x, y ) / CellSize ).FloorInt;
        public override Int2 WorldToCell( Float2 worldPosition ) => ( WorldToLocal( worldPosition ) / CellSize ).FloorInt;

        public override Float2 LocalToWorld( float x, float y ) => new Float2( x, y ) + Origin;
        public override Float2 LocalToWorld( Float2 localPosition ) => localPosition + Origin;

        public override Float2 WorldToLocal( float x, float y ) => new Float2( x, y ) - Origin;
        public override Float2 WorldToLocal( Float2 worldPosition ) => worldPosition - Origin;
    }
}
