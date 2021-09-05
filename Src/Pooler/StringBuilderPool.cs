using System.Text;

namespace CXUtils.Common
{
    public sealed class StringBuilderPool : CapacityPool<StringBuilder>
    {
        public StringBuilderPool( int capacity ) : base( capacity, MakeObject, ReleaseObject ) { }
        static StringBuilder MakeObject() => new StringBuilder();
        static StringBuilder ReleaseObject( StringBuilder item ) => item.Clear();
    }
}
