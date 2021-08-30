using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     A timer that ticks by manual control
    /// </summary>
    public class Timer : ICloneable, IFormattable
    {
        public Timer( float maxSpan, bool cycleReset = true )
        {
            MaxSpan = maxSpan;
            CycleReset = cycleReset;
            FirstCycleCompleted = false;
        }

        /// <summary>
        ///     Deep copies (everything, even the current state) the whole timer
        /// </summary>
        public Timer( Timer other )
        {
            MaxSpan = other.MaxSpan;
            CurrentSpan = other.CurrentSpan;
            CycleReset = other.CycleReset;
            FirstCycleCompleted = other.FirstCycleCompleted;
        }

        public float MaxSpan { get; }

        public float CurrentSpan { get; private set; }
        public bool CycleReset { get; }

        public bool FirstCycleCompleted { get; private set; }

        /// <summary>
        ///     Deep clones the timer
        /// </summary>
        public object Clone() => new Timer( this );

        public string ToString( string format, IFormatProvider formatProvider ) =>
            "Current Span: " + CurrentSpan.ToString( format, formatProvider ) + ", Max Span: " + MaxSpan.ToString( format, formatProvider );

        /// <summary>
        ///     Ticks the timer using the <see cref="delta" />
        /// </summary>
        public bool Tick( float delta )
        {
            //if not gonna cycle reset and the first cycle is already completed
            if ( !CycleReset && FirstCycleCompleted )
                return false;

            CurrentSpan += delta;

            //if current Timer is not over max timer
            if ( !( CurrentSpan >= MaxSpan ) )
                return false;

            DoCycleCompleted();

            return true;
        }

        /// <summary>
        ///     reset's the <see cref="CurrentSpan" /> back to initial value, but doesn't count for first cycle
        /// </summary>
        void Reset() => CurrentSpan = 0;

        /// <summary>
        ///     set's the <see cref="CurrentSpan" /> back to initial value and resets the <see cref="FirstCycleCompleted" />
        /// </summary>
        void FullReset()
        {
            CurrentSpan = 0;
            FirstCycleCompleted = false;
        }

        void DoCycleCompleted()
        {
            CurrentSpan = 0;

            OnCycleComplete?.Invoke();

            if ( !FirstCycleCompleted )
                FirstCycleCompleted = true;
        }

        public event Action OnCycleComplete;

        public override string ToString() => "Current Span: " + CurrentSpan + ", Max Span: " + MaxSpan;
    }
}
