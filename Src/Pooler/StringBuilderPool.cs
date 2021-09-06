using System.Text;

namespace CXUtils.Common
{
    public sealed class StringBuilderPool : CapacityPoolBase<StringBuilder>
    {
        public StringBuilderPool( int capacity ) : base( capacity ) { Populate( capacity ); }
        protected override StringBuilder CreateItemFactory() => new StringBuilder();
        protected override StringBuilder ItemReleaseFactory( StringBuilder item ) => item.Clear();
    }
}
