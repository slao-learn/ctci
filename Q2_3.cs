using System;

namespace ctci
{
	public class Q2_3
	{
		public static bool DeleteNode(LinkedListNode<int> n)
		{
			if (n == null || n.next == null) {
				return false;
			}
			n.data = n.next.data;
			n.next = n.next.next;
			return true;
		}

		public static void RunTests()
		{
			LinkedListNode<int> l = new LinkedListNode<int> (4, 5, 6, 5, 2, 1, 9, 2, 0);
			Console.WriteLine (l);
			Console.WriteLine (DeleteNode (l.next.next.next));
			Console.WriteLine (l);
			Console.WriteLine (DeleteNode (l.next.next.next));
			Console.WriteLine (l);
		}
	}
}

