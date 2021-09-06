using System;

namespace CXUtils.Common
{
    public class CapacityPool<T> : CapacityPoolBase<T>
    {
        readonly Func<T>    _createFactory;
        readonly Func<T, T> _releaseFactory;

        public CapacityPool( int capacity, Func<T> createFactory = null, Func<T, T> releaseFactory = null ) : base( capacity )
        {
            _createFactory = createFactory ?? base.CreateItemFactory;
            _releaseFactory = releaseFactory ?? base.ItemReleaseFactory;

            Populate( capacity );
        }

        protected override T CreateItemFactory() => _createFactory();
        protected override T ItemReleaseFactory( T item ) => _releaseFactory( item );
    }
}
