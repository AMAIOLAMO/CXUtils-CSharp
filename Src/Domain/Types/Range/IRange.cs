namespace CXUtils.Domain.Types.Range
{
	public interface IRange<in TType, TValue> where TType : IRange<TType, TValue>
	{
		TValue Clamp(TValue value);
		bool Contains(TValue value);
		TValue Loop(TValue value);
		TValue RemapFrom(TValue value, TType inRange);
		TValue RemapFrom(TValue min, TValue inMin, TValue inMax);
		TValue RemapTo(TValue value, TType outRange);
		TValue RemapTo(TValue value, TValue outMin, TValue outMax);
		TValue Range { get; }
	}
}
