using System;

namespace ctci
{
	public class Q2_2
	{
		public static LinkedListNode<int> KthFromLastRecursive(LinkedListNode<int> l, int k)
		{
			int index = 0;
			return KthFromLastRecursive (l, k, out index);
		}

		private static LinkedListNode<int> KthFromLastRecursive(LinkedListNode<int> l, int k, out int index)
		{
			if (l == null) {
				index = 0;
				return null;
			}

			LinkedListNode<int> n = KthFromLastRecursive (l.next, k, out index);
			index += 1;
			if (index == k)
				return l;
			return n;
		}

		public static LinkedListNode<int> KthFromLast(LinkedListNode<int> l, int k)
		{
			LinkedListNode<int> t = l;
			for (int i = 0; i < k; ++i) {
				if (t == null)
					throw new Exception ("invalid input");
				t = t.next;
			}

			while (t != null) {
				l = l.next;
				t = t.next;
			}

			return l;
		}

		public static void RunTests()
		{
			LinkedListNode<int> l = new LinkedListNode<int> (4, 5, 6, 5, 2, 1, 9, 2, 0);
			Console.WriteLine (l);
			Console.WriteLine (KthFromLastRecursive (l, 2).data);
			Console.WriteLine (KthFromLastRecursive (l, 3).data);
			Console.WriteLine (KthFromLastRecursive (l, 1).data);
			Console.WriteLine (KthFromLast (l, 2).data);
			Console.WriteLine (KthFromLast (l, 3).data);
			Console.WriteLine (KthFromLast (l, 1).data);

		}
	}
}

