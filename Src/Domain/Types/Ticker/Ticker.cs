using System;
using System.Globalization;

namespace CXUtils.Common
{
	/// <summary>
	///     A floating point driven Ticker
	/// </summary>
	public class Ticker : ITicker<float>
	{
		public Ticker() => Span = 0f;

		public Ticker(ITicker<float> other) => Span = other.Span;

		public float Span { get; private set; }

		public void Tick(float delta)
		{
			Span += delta;
		}
		
		public bool TickMax(float delta, float max)
		{
			Span += delta;

			//if current Timer is not over max timer
			if (Span < max) return false;

			Span -= max;

			MaxTicked?.Invoke();

			return true;
		}
		
		
		
		public void SetSpan(float span) => Span = span;

		public void Reset() => Span = 0f;

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"Current Span: {Span.ToString(format, formatProvider)}";

		public event Action MaxTicked;

		public override string ToString() => $"Current Span: {Span.ToString(CultureInfo.InvariantCulture)}";
	}
}
