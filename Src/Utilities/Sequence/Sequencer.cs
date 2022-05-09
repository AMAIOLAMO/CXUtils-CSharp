using System;
using System.Collections;
using System.Collections.Generic;

namespace CXUtils.Common
{
	/// <summary>
	///     A class that is used to enumerate through a list of <see cref="Action" />
	/// </summary>
	public class Sequencer : IEnumerable<Action>
	{
		public Sequencer() =>
			_actions = new List<Action>();
		public Sequencer(int capacity) =>
			_actions = new List<Action>(capacity);
		public Sequencer(IEnumerable<Action> collection) =>
			_actions = new List<Action>(collection);

		public IEnumerator<Action> GetEnumerator() => new Enumerator(_actions);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public Sequencer Append(Action action)
		{
			_actions.Add(action);
			return this;
		}

		public Sequencer RemoveAt(int index)
		{
			_actions.RemoveAt(index);
			return this;
		}

		public Action this[int index]
		{
			get => _actions[index];
			set => _actions[index] = value;
		}

		public int Capacity => _actions.Capacity;

		public int Count => _actions.Count;

		readonly List<Action> _actions;

		class Enumerator : IEnumerator<Action>
		{
			public Enumerator(IReadOnlyList<Action> actions) => this.actions = actions;

			public bool MoveNext()
			{
				index++;

				return index < actions.Count;
			}

			public void Reset() => index = 0;

			public Action Current => actions[index];

			object IEnumerator.Current => Current;

			public void Dispose() { }

			readonly IReadOnlyList<Action> actions;

			int index;
		}
	}
}
