using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q4_3
	{
		public static List<LinkedList<BTNode>> GetDepthListsDepthFirst(BTNode t)
		{
			List<LinkedList<BTNode>> list = new List<LinkedList<BTNode>> ();
			GetDepthListsDepthFirst (t, 0, list);
			return list;
		}

		private static void GetDepthListsDepthFirst(BTNode t, int depth, List<LinkedList<BTNode>> list)
		{
			if (t == null)
				return;
			if (list.Count < depth + 1)
				list.Add(new LinkedList<BTNode> ());
			list [depth].AddLast (t);
			GetDepthListsDepthFirst (t.left, depth + 1, list);
			GetDepthListsDepthFirst (t.right, depth + 1, list);
		}

		public static List<LinkedList<BTNode>> GetDepthListsBreadthFirst(BTNode t)
		{
			List<LinkedList<BTNode>> result = new List<LinkedList<BTNode>> ();
			LinkedList<BTNode> current = new LinkedList<BTNode> ();
			current.AddLast (t);
			while (current.Count > 0) {
				result.Add (current);
				LinkedList<BTNode> parents = current;
				current = new LinkedList<BTNode> ();
				var e = parents.GetEnumerator ();
				while (e.MoveNext ()) {
					if (e.Current.left != null)
						current.AddLast (e.Current.left);
					if (e.Current.right != null)
						current.AddLast (e.Current.right);
				}
			}
			return result;
		}

		public static void RunTests()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12, 15, 16, 17, 20, 50, 75, 100 });
			Console.WriteLine (t);
			Print (GetDepthListsDepthFirst (t));
			Print (GetDepthListsBreadthFirst (t));
		}

		private static void Print(List<LinkedList<BTNode>> result)
		{
			for (int i = 0; i < result.Count; ++i) {
				Console.Write ("depth: " + i + ": ");
				var enumerator = result [i].GetEnumerator ();
				if (enumerator.MoveNext ())
				{
					Console.Write (enumerator.Current.data);
					while (enumerator.MoveNext ()) {
						Console.Write (" -> " + enumerator.Current.data);
					}
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}
	}
}

