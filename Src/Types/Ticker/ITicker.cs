using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     Implements a basic timer
    /// </summary>
    public interface ITicker<TSpan> : IFormattable
    {
        TSpan MaxSpan     { get; }
        TSpan CurrentSpan { get; }

        /// <summary>
        ///     Ticks the timer using the given <see cref="delta" /> <br />
        ///     NOTE: this method requires you to reset the timer yourself, <br />
        ///     or else when the timer is over it will trigger <see cref="Ticker.OnTriggered" /> every single
        ///     <see cref="Ticker.Tick" /> call
        /// </summary>
        bool Tick( TSpan delta );

        void SetSpan( TSpan span );

        /// <summary>
        ///     reset's the <see cref="Ticker.CurrentSpan" /> back to initial value
        /// </summary>
        void Reset();
        event Action OnTriggered;
    }
}
