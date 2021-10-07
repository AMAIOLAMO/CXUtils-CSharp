using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     A floating point driven Ticker
    /// </summary>
    public class Ticker : ITicker<float>
    {
        public Ticker( float maxSpan ) => MaxSpan = maxSpan;

        public Ticker( ITicker<float> other )
        {
            MaxSpan = other.MaxSpan;
            CurrentSpan = other.CurrentSpan;
        }

        public float MaxSpan { get; }

        public float CurrentSpan { get; private set; }

        public bool Tick( float delta )
        {
            CurrentSpan += delta;

            //if current Timer is not over max timer
            if ( CurrentSpan < MaxSpan ) return false;

            OnTriggered?.Invoke();

            return true;
        }

        public void SetSpan( float span ) => CurrentSpan = span;

        public void Reset() => CurrentSpan = 0f;

        public string ToString( string format, IFormatProvider formatProvider ) =>
            "Current Span: " + CurrentSpan.ToString( format, formatProvider ) + ", Max Span: " + MaxSpan.ToString( format, formatProvider );

        public event Action OnTriggered;

        public override string ToString() => "Current Span: " + CurrentSpan + ", Max Span: " + MaxSpan;
    }
}
