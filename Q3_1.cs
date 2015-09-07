using System;
using System.Text;

namespace ctci
{
	public class Q3_1
	{
		public class MyStacks
		{
			private const int NUM_STACKS = 3;

			private int capacity;
			private int[] stacks;
			private int[] stackIndices;

			public MyStacks(int capacity)
			{
				this.capacity = capacity;
				stacks = new int[NUM_STACKS * capacity];
				stackIndices = new int[NUM_STACKS];
				for (int i = 0; i < NUM_STACKS; ++i)
				{
					stackIndices[i] = -1;
				}
			}

			public int Pop(int stackIndex)
			{
				if (stackIndices [stackIndex] < 0)
					throw new Exception ("Stack " + stackIndex + " is empty");
				int index = GetIndex (stackIndex);
				DecrementIndex (stackIndex);
				return stacks [index];
			}

			public void Push(int stackIndex, int value)
			{
				IncrementIndex (stackIndex);
				stacks [GetIndex(stackIndex)] = value;
			}

			public int Peek(int stackIndex)
			{
				if (stackIndices [stackIndex] < 0)
					throw new Exception ("Stack " + stackIndex + " is empty");
				return stacks [GetIndex(stackIndex)];
			}

			private int GetIndex(int stackIndex)
			{
				return stackIndex * capacity + stackIndices [stackIndex];
			}

			private void DecrementIndex(int stackIndex)
			{
				--stackIndices [stackIndex];
			}

			private void IncrementIndex(int stackIndex)
			{
				if (stackIndices [stackIndex] + 1 == capacity) {
					int newCapacity = capacity * 2;
					int[] newStacks = new int[newCapacity * NUM_STACKS];

					// copy values to new stacks array
					for (int si = 0; si < NUM_STACKS; ++si) {
						for (int i = 0; i <= stackIndices[si]; ++i) {
//							Console.WriteLine ("{0} {1} {2}", si, si * newCapacity + i, si * capacity + i);
							newStacks [si * newCapacity + i] = stacks [si * capacity + i];
						}
					}
					stacks = newStacks;
					capacity = newCapacity;
				}
				++stackIndices [stackIndex];
			}

			public bool IsEmpty(int stackIndex)
			{
				return stackIndices [stackIndex] < 0;
			}

			public override string ToString ()
			{
				StringBuilder sb = new StringBuilder ();
				for (int i = 0; i < stacks.Length; ++i) {
					sb.Append (stacks [i]).Append (" ");
				}
				sb.AppendLine ();
				return sb.ToString ();
			}
		}

		public static void RunTests()
		{
			MyStacks stacks = new MyStacks (3);
			stacks.Push (0, 1);
			Print (stacks);
			stacks.Push (1, 3);
			Print (stacks);
			stacks.Push (2, 5);
			Print (stacks);
			stacks.Push (1, 4);
			Print (stacks);
			stacks.Push (1, 6);
			Print (stacks);
			stacks.Push (1, 7);
			Print (stacks);
			stacks.Push (1, 8);
			Print (stacks);
			Console.WriteLine (stacks.Peek (1));
			Console.WriteLine (stacks.Pop (1));
			Console.WriteLine (stacks.Pop (2));
			Print (stacks);
			Console.WriteLine (stacks.Pop (1));
			Console.WriteLine (stacks.IsEmpty(2));
			Console.WriteLine (stacks.IsEmpty(1));
		}

		private static void Print(MyStacks stacks)
		{
			Console.WriteLine (stacks);
		}
	}
}

