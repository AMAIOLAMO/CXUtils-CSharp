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

        bool _timerEndedCheck;

        /// <summary>
        ///     Ticks the timer using the <see cref="delta" />
        /// </summary>
        public bool Tick( float delta )
        {
            if ( _timerEndedCheck ) return false;
            
            CurrentSpan += delta;

            //if current Timer is not over max timer
            if ( !( CurrentSpan >= MaxSpan ) ) return false;

            _timerEndedCheck = true;
            OnTriggered?.Invoke();

            return true;
        }

        public void SetSpan( float span ) => CurrentSpan = span;

        /// <summary>
        ///     reset's the <see cref="CurrentSpan" /> back to initial value, but doesn't count for first cycle
        /// </summary>
        void Reset()
        {
            CurrentSpan = 0f;
            _timerEndedCheck = false;
        }

        public event Action OnTriggered;
        
        public override string ToString() => "Current Span: " + CurrentSpan + ", Max Span: " + MaxSpan;

        public string ToString( string format, IFormatProvider formatProvider ) =>
            "Current Span: " + CurrentSpan.ToString( format, formatProvider ) + ", Max Span: " + MaxSpan.ToString( format, formatProvider );
    }
}
