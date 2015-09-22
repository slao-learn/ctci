using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q4_9
	{
		public static List<List<int>> GetArrays(BTNode t)
		{
			List<List<int>> all = new List<List<int>> ();

			if (t == null) {
				all.Add (new List<int> ());
				return all;
			}

			List<int> prefix = new List<int> ();
			prefix.Add (t.data);

			List<List<int>> leftLists = GetArrays (t.left);
			List<List<int>> rightLists = GetArrays (t.right);

			foreach (var leftList in leftLists) {
				foreach (var rightList in rightLists) {
					List<List<int>> weavedLists = new List<List<int>> ();
					Weave (leftList, rightList, weavedLists, prefix);
					all.AddRange (weavedLists);
				}
			}
			return all;
		}

		private static void Weave(List<int> first, List<int> second, List<List<int>> weaved, List<int> prefix)
		{
			if (first.Count == 0 || second.Count == 0) {
				List<int> newList = new List<int> (prefix);
				newList.AddRange (first);
				newList.AddRange (second);
				weaved.Add (newList);
				return;
			}

			int removed = first [0];
			first.RemoveAt (0);
			prefix.Add (removed);
			Weave (first, second, weaved, prefix);
			prefix.Remove (removed);
			first.Insert(0, removed);

			removed = second [0];
			second.RemoveAt (0);
			prefix.Add (removed);
			Weave (first, second, weaved, prefix);
			prefix.Remove (removed);
			second.Insert (0, removed);
		}

		public static void RunTests()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { 1, 2, 3 });
			Console.WriteLine (t);
			Print (GetArrays(t));

			t = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12 });
			Console.WriteLine (t);
			Print (GetArrays(t));
		}

		private static void Print(List<List<int>> lists)
		{
			foreach (var list in lists) {
				Print (list);
			}
		}

		private static void Print(List<int> list)
		{
			foreach (var v in list) {
				Console.Write (v + " ");
			}
			Console.WriteLine ();
		}
	}
}

