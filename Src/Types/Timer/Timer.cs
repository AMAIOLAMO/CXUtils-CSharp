using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     A timer that ticks by manual control
    /// </summary>
    public class Timer : IFormattable
    {
        public Timer( float maxSpan ) => MaxSpan = maxSpan;

        public Timer( Timer other )
        {
            MaxSpan = other.MaxSpan;
            CurrentSpan = other.CurrentSpan;
        }

        public float MaxSpan { get; }

        public float CurrentSpan { get; private set; }

        public string ToString( string format, IFormatProvider formatProvider ) =>
            "Current Span: " + CurrentSpan.ToString( format, formatProvider ) + ", Max Span: " + MaxSpan.ToString( format, formatProvider );
        
        /// <summary>
        ///     Ticks the timer using the given <see cref="delta" /> <br />
        ///     NOTE: this method requires you to reset the timer yourself, <br />
        ///     or else when the timer is over it will trigger <see cref="OnTriggered"/> every single <see cref="Tick"/> call
        /// </summary>
        public bool Tick( float delta )
        {
            CurrentSpan += delta;

            //if current Timer is not over max timer
            if ( !( CurrentSpan >= MaxSpan ) ) return false;

            OnTriggered?.Invoke();

            return true;
        }

        public void SetSpan( float span ) => CurrentSpan = span;

        /// <summary>
        ///     reset's the <see cref="CurrentSpan" /> back to initial value
        /// </summary>
        void Reset() => CurrentSpan = 0f;

        public event Action OnTriggered;

        public override string ToString() => "Current Span: " + CurrentSpan + ", Max Span: " + MaxSpan;
    }
}
