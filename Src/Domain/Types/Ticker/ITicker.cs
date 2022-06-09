using System;

namespace CXUtils.Common
{
	/// <summary>
	///     Implements a basic timer
	/// </summary>
	public interface ITicker<TSpan> : IFormattable
	{
		/// <summary>
		///     Ticks the ticker using the given <paramref name="delta" />
		/// </summary>
		void Tick(TSpan delta);

		/// <summary>
		///     Ticks the ticker using the given <see cref="delta" /> <br />
		///     And when <see cref="Span" /> is over <paramref name="max" /> it will reset the ticker
		/// </summary>
		bool TickMax(TSpan delta, TSpan max);

		/// <summary>
		///     Doesn't tick the ticker, but loops the ticker and fires <see cref="Finished"/> when <see cref="Span"/> reaches <paramref name="max" />
		/// </summary>
		public bool LoopIf(TSpan max);

		/// <summary>
		///     Set's the span value to the given <paramref name="span" />
		/// </summary>
		void SetSpan(TSpan span);

		/// <summary>
		///     reset's the <see cref="TickerFloat.Span" /> back to initial value
		/// </summary>
		void Reset();

		event Action Finished;

		TSpan Span { get; }
	}
}
