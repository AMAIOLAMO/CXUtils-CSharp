using System.Text;

namespace CXUtils.Common
{
    public sealed class StringBuilderPool : CapacityPool<StringBuilder>
    {
        public StringBuilderPool( int capacity ) : base( capacity, MakeObject ) { }
        static StringBuilder MakeObject() => new StringBuilder();
    }
}
