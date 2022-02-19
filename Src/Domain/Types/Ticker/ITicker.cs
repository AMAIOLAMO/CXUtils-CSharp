using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     Implements a basic timer
    /// </summary>
    public interface ITicker<TSpan> : IFormattable
    {
        TSpan Span { get; }

        /// <summary>
        ///     Ticks the timer using the given <see cref="delta" /> <br />
        ///     NOTE: this method requires you to reset the timer yourself, <br />
        ///     or else when the timer is over it will trigger <see cref="Ticker.MaxTicked" /> every single
        ///     <see cref="Ticker.TickMax" /> call
        /// </summary>
        bool TickMax( TSpan delta, TSpan max );

        void SetSpan( TSpan span );

        /// <summary>
        ///     reset's the <see cref="Ticker.Span" /> back to initial value
        /// </summary>
        void Reset();
        event Action MaxTicked;
    }
}
