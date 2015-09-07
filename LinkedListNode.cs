using System;

namespace ctci
{
	public class LinkedListNode<T>
	{
		public T data;
		public LinkedListNode<T> next;

		public LinkedListNode(T data, LinkedListNode<T> next)
		{
			this.data = data;
			this.next = next;
		}

		public LinkedListNode(T data) : this(data, null)
		{
		}

		public LinkedListNode(params T[] values)
		{
			this.data = values [0];
			LinkedListNode<T> curNode = this;
			for (int i = 1; i < values.Length; ++i) {
				LinkedListNode<T> newNode = new LinkedListNode<T> (values [i]);
				curNode.next = newNode;
				curNode = newNode;
			}
		}

		public override string ToString ()
		{
			string result = "";
			LinkedListNode<T> cur = this;
			while (cur != null)
			{
				if (cur.next != null)
					result += cur.data + " -> ";
				else
					result += cur.data;
				cur = cur.next;
			}
			return result;
		}
	}
}

