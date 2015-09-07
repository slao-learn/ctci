using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q2_1
	{
		public static LinkedListNode<int> RemoveDupes(LinkedListNode<int> l)
		{
			HashSet<int> found = new HashSet<int> ();
			found.Add (l.data);
			LinkedListNode<int> a = l;
			while (a.next != null)
			{
				if (!found.Contains (a.next.data)) {
					found.Add (a.next.data);
					a = a.next;
				} else {
					a.next = a.next.next;
				}
			}
			return l;
		}

		public static LinkedListNode<int> RemoveDupesNoBuffer(LinkedListNode<int> l)
		{
			LinkedListNode<int> head = l;
			while (l != null) {
				LinkedListNode<int> m = l;
				while (m.next != null) {
					if (m.next.data == l.data)
						m.next = m.next.next;
					else
						m = m.next;
				}
				l = l.next;
			}
			return head;
		}

		public static void RunTests()
		{
			LinkedListNode<int> l = new LinkedListNode<int> (4, 5, 6, 5, 2, 1, 9, 2, 0);
			Console.WriteLine (l);
			Console.WriteLine (RemoveDupes (l));

			l = new LinkedListNode<int> (4, 5, 6, 5, 2, 1, 9, 2, 0);
			Console.WriteLine (RemoveDupesNoBuffer (l));
		}
	}
}

