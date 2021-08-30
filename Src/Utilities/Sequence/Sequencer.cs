using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CXUtils.Common
{
    /// <summary>
    ///     A class that is used to enumerate through triggers / <see cref="Action" />
    /// </summary>
    public class Sequencer : IEnumerable<Action>
    {
        readonly List<Action> _sequenceTriggerList;

        public Sequencer() => _sequenceTriggerList = new List<Action>();
        public IEnumerator<Action> GetEnumerator() => new SequencerEnumerator( _sequenceTriggerList );
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Sequencer Append( Action trigger )
        {
            _sequenceTriggerList.Add( trigger );
            return this;
        }

        class SequencerEnumerator : IEnumerator<Action>
        {
            readonly ReadOnlyCollection<Action> _actionCollection;
            Queue<Action> _actionQueue;
            public SequencerEnumerator( IList<Action> actions )
            {
                _actionCollection = new ReadOnlyCollection<Action>( actions );
                _actionQueue = new Queue<Action>( actions );
            }
            public bool MoveNext()
            {
                if ( _actionQueue.Count == 0 ) return false;

                Current = _actionQueue.Dequeue();
                return true;

            }
            public void Reset() => _actionQueue = new Queue<Action>( _actionCollection );
            public Action Current { get; private set; }
            object IEnumerator.Current => Current;
            public void Dispose() { }
        }
    }
}
