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
        readonly Queue<Action> _actionList;

        public Sequencer() => _actionList = new Queue<Action>();
        public IEnumerator<Action> GetEnumerator() => new SequencerEnumerator( _actionList );
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Sequencer Append( Action action )
        {
            _actionList.Enqueue( action );
            return this;
        }

        public IEnumerator<Action> Enumerate()
        {
            var sequenceQueue = new Queue<Action>( _actionList );
            
            while ( sequenceQueue.Count != 0 ) yield return sequenceQueue.Dequeue();
        }

        class SequencerEnumerator : IEnumerator<Action>
        {
            readonly Queue<Action> _originalQueue;
            Queue<Action>          _actionQueue;
            public SequencerEnumerator( Queue<Action> actions )
            {
                _originalQueue = actions;
                _actionQueue = new Queue<Action>( actions );
            }
            public bool MoveNext()
            {
                if ( _actionQueue.Count == 0 ) return false;

                Current = _actionQueue.Dequeue();
                return true;
            }
            public void Reset() => _actionQueue = new Queue<Action>( _originalQueue );
            public Action Current { get; private set; }
            object IEnumerator.Current => Current;
            public void Dispose() { }
        }
    }
}
