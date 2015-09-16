using System;

namespace ctci
{
	public class Q3_2
	{
		public class MinStack : Stack<int>
		{
			private Stack<int> mMinStack = new Stack<int>();

			public override void Push(int value)
			{
				if (mMinStack.IsEmpty () || mMinStack.Peek () >= value)
					mMinStack.Push (value);
				base.Push (value);
			}

			public override int Pop()
			{
				int value = base.Pop ();
				if (mMinStack.Peek () == value)
					mMinStack.Pop ();
				return value;
			}

			public int Min()
			{
				if (mMinStack.IsEmpty())
					throw new Exception ("Empty stack");
				return mMinStack.Peek ();
			}
		}

		public static void RunTests()
		{
			MinStack stacks = new MinStack();
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
		}

		private static void Print(MinStack stacks)
		{
			Console.WriteLine (stacks);
			Console.WriteLine ("min=" + stacks.Min());
		}
	}
}

