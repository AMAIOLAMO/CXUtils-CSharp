using System.Text;
using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
    public sealed class StringBuilderPool : CapacityPoolBase<StringBuilder>
    {
        public StringBuilderPool( int capacity ) :
            base( capacity, new ItemFactory(), new BasicPoolObjectFactory<StringBuilder>() ) =>
            Populate( capacity );

        class ItemFactory : IPoolItemFactory<StringBuilder>
        {
            public StringBuilder Create() => new StringBuilder();
            public StringBuilder Release( StringBuilder item ) => item.Clear();
        }
    }
}
