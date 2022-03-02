using System.Text;

namespace CXUtils.Infrastructure
{
	public sealed class StringBuilderPool : Pool<StringBuilder>
	{
		public StringBuilderPool(int amount) : base(amount) => Populate(amount);

		protected override StringBuilder Create() => new StringBuilder();
		protected override StringBuilder Release(StringBuilder item) => item.Clear();
	}
}
