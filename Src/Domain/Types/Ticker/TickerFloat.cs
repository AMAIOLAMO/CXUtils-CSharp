using System;
using System.Globalization;

namespace CXUtils.Common
{
	/// <summary>
	///     A floating point driven Ticker
	/// </summary>
	public class TickerFloat : ITicker<float>
	{
		public TickerFloat(float span) => Span = span;

		public TickerFloat() : this(0f) { }

		public TickerFloat(ITicker<float> other) : this(other.Span) { }

		public float Span { get; private set; }

		public void Tick(float delta)
		{
			Span += delta;
		}

		public bool TickMax(float delta, float max)
		{
			Span += delta;

			return LoopIf(max);
		}

		public bool LoopIf(float max)
		{
			//if current Timer is not over max timer
			if (Span < max) return false;

			Span -= max;

			Finished?.Invoke();

			return true;
		}

		public void SetSpan(float span) => Span = span;

		public void Reset() => Span = 0f;

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"Current Span: {Span.ToString(format, formatProvider)}";

		public event Action Finished;

		public override string ToString() =>
			$"Current Span: {Span.ToString(CultureInfo.InvariantCulture)}";
	}
}
