using System;

namespace ctci
{
	public class Stack<T>
	{
		protected class StackNode
		{
			public T data;
			public StackNode next;

			public StackNode(T data)
			{
				this.data = data;
			}
		}

		private StackNode top;

		public Stack ()
		{
		}

		public T Pop()
		{
			if (top == null)
				throw new Exception ("Empty stack");
			T result = top.data;
			top = top.next;
			return result;
		}

		public void Push(T value)
		{
			StackNode newNode = new StackNode (value);
			newNode.next = top;
			top = newNode;
		}

		public T Peek()
		{
			if (top == null)
				throw new Exception ("Empty stack");
			return top.data;
		}

		public bool IsEmpty()
		{
			return (top == null);
		}
	}
}

