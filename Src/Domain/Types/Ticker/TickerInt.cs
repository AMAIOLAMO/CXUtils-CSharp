using System;
using System.Globalization;

namespace CXUtils.Common
{
	/// <summary>
	///     An integer driven Ticker
	/// </summary>
	public class TickerInt : ITicker<int>
	{
		public TickerInt(int span) => Span = span;

		public TickerInt() : this(0) { }

		public TickerInt(ITicker<int> other) : this(other.Span) { }

		public int Span { get; private set; }

		public void Tick(int delta)
		{
			Span += delta;
		}

		public bool TickMax(int delta, int max)
		{
			Span += delta;

			return LoopIf(max);
		}

		public bool LoopIf(int max)
		{
			//if current Timer is not over max timer
			if (Span < max) return false;

			Span -= max;

			Finished?.Invoke();

			return true;
		}

		public void SetSpan(int span) =>
			Span = span;

		public void Reset() =>
			Span = 0;

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"Current Span: {Span.ToString(format, formatProvider)}";

		public event Action Finished;

		public override string ToString() =>
			$"Current Span: {Span.ToString(CultureInfo.InvariantCulture)}";
	}
}
