using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q3_3
	{
		public class SetOfStacks<T>
		{
			private List<Stack<T>> stacks;
			private int capacity;
			private int size;

			public SetOfStacks(int capacity)
			{
				this.capacity = capacity;
				stacks = new List<Stack<T>>();
				size = 0;
			}

			public void Push(T val)
			{
				if (size++ % capacity == 0) {
					stacks.Add (new Stack<T> ());
				}
				stacks [stacks.Count - 1].Push (val);
			}

			public T Pop()
			{
				if (size == 0)
					throw new Exception ("empty stack");
				Stack<T> s = stacks [stacks.Count - 1];
				if (--size % capacity == 0 && stacks.Count > 1) {
					stacks.Remove (s);
				}
				return s.Pop ();
			}

			public T Peek()
			{
				if (size == 0)
					throw new Exception ("empty stack");
				return stacks [stacks.Count - 1].Peek ();
			}

			public bool IsEmpty()
			{
				return size == 0;
			}

			public override string ToString ()
			{
				string s = "";
				foreach (var stack in stacks) {
					s += stack.ToString () + "\n";
				}
				return s;
			}
		}

		public static void RunTests()
		{
			SetOfStacks<int> stacks = new SetOfStacks<int>(3);
			stacks.Push (3);
			Print (stacks);
			stacks.Push (3);
			Print (stacks);
			stacks.Push (5);
			Print (stacks);
			stacks.Push (4);
			Print (stacks);
			stacks.Push (2);
			Print (stacks);
			stacks.Push (7);
			Print (stacks);
			stacks.Push (8);
			Print (stacks);
			Console.WriteLine (stacks.Peek ());
			Console.WriteLine (stacks.Pop());
			Print (stacks);
			Console.WriteLine (stacks.Pop());
			Print (stacks);
			Console.WriteLine (stacks.Pop());
			Print (stacks);
			Console.WriteLine (stacks.Pop());
			Print (stacks);
			Console.WriteLine (stacks.Pop());
			Print (stacks);
		}

		private static void Print(SetOfStacks<int> stacks)
		{
			Console.WriteLine (stacks);
		}
	}
}

