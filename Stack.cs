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

		public virtual T Pop()
		{
			if (top == null)
				throw new Exception ("Empty stack");
			T result = top.data;
			top = top.next;
			return result;
		}

		public virtual void Push(T value)
		{
			StackNode newNode = new StackNode (value);
			newNode.next = top;
			top = newNode;
		}

		public virtual T Peek()
		{
			if (top == null)
				throw new Exception ("Empty stack");
			return top.data;
		}

		public virtual bool IsEmpty()
		{
			return (top == null);
		}

		public override string ToString ()
		{
			if (top == null)
				return "null";
			
			string s = "";
			StackNode n = top;
			while (n != null) {
				if (n.next != null)
					s += n.data + " -> ";
				else
					s += n.data;
				n = n.next;
			}

			return s;
		}
	}
}

