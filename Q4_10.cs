using System;

namespace ctci
{
	public class Q4_10
	{
		// This only works if all nodes are distinct
		public static bool IsSubtreeDistinct(BTNode t1, BTNode t2)
		{
			if (t1 == null)
				return t2 == null;
			if (t2 == null)
				return true;
			
			if (t1.data != t2.data) {
				return IsSubtreeDistinct (t1.left, t2) || IsSubtreeDistinct (t1.right, t2);
			} else {
				return IsSubtreeDistinct (t1.left, t2.left) && IsSubtreeDistinct (t1.right, t2.right);
			}
		}

		public static bool IsSubtree(BTNode t1, BTNode t2)
		{
			if (t1 == null)
				return false;
			if (t2 == null)
				return true;

			if (t1.data == t2.data && Match (t1, t2))
				return true;
			else
				return IsSubtree (t1.left, t2) || IsSubtree (t1.right, t2);
		}

		private static bool Match(BTNode t1, BTNode t2)
		{
			if (t1 == null)
				return (t2 == null);
			if (t2 == null || t1.data != t2.data)
				return false;
			return Match (t1.left, t2.left) && Match (t1.right, t2.right);
		}

		public static void RunTests ()
		{
			BTNode t1 = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12, 15, 16, 17, 20, 50, 75, 100 });
			Console.WriteLine (t1);

			BTNode t2 = Q4_2.CreateMinimalBST (new int[] { 6, 7, 10 });
			Console.WriteLine (t2);

			Console.WriteLine (IsSubtree(t1, t2));

			BTNode t3 = Q4_2.CreateMinimalBST (new int[] { 6, 7, 12 });
			Console.WriteLine (t3);
			Console.WriteLine (IsSubtree(t1, t3));
			t2.left.left = t3;
			Console.WriteLine (IsSubtree(t2, t3));

		}
	}
}

