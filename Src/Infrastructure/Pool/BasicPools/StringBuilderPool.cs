using System.Text;
using CXUtils.Domain;

namespace CXUtils.Infrastructure
{
	public sealed class StringBuilderPool : CapacityPoolBase<StringBuilder>
	{
		public StringBuilderPool(int capacity) :
			base(capacity, ItemFactory.Single, new BasicPoolObjectFactory<StringBuilder>()) =>
			Populate(capacity);

		internal sealed class ItemFactory : IPoolItemFactory<StringBuilder>
		{
			public StringBuilder Create() => new StringBuilder();
			public StringBuilder Release(StringBuilder item) => item.Clear();
			public static readonly ItemFactory Single = new ItemFactory();
		}
	}
}
