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
			actions = new List<Action>();
		public Sequencer(int capacity) =>
			actions = new List<Action>(capacity);
		public Sequencer(IEnumerable<Action> collection) =>
			actions = new List<Action>(collection);

		public IEnumerator<Action> GetEnumerator() => new Enumerator(actions);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public Sequencer Append(Action action)
		{
			actions.Add(action);
			return this;
		}

		public Sequencer RemoveAt(int index)
		{
			actions.RemoveAt(index);
			return this;
		}

		public Action this[int index]
		{
			get => actions[index];
			set => actions[index] = value;
		}

		public int Capacity => actions.Capacity;

		public int Count => actions.Count;

		readonly List<Action> actions;

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
