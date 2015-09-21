using System;

namespace ctci
{
	public class Q4_5
	{
		public static bool IsBinarySearchTree(BTNode t)
		{
			return ValidateBST (t, int.MinValue, int.MaxValue);
		}

		private static bool ValidateBST(BTNode n, int min, int max)
		{
			if (n == null)
				return true;
			return (n.data >= min && n.data <= max &&
					ValidateBST (n.left, min, n.data) &&
					ValidateBST (n.right, n.data + 1, max));
		}

		public static void RunTests()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12, 15, 16, 17, 20, 50, 75, 100 });
			Console.WriteLine (t);
			Console.WriteLine (IsBinarySearchTree(t));
			t.left.data = 16;
			Console.WriteLine (IsBinarySearchTree(t));
			t = new BTNode (0);
			t.left = new BTNode (-1);
			Console.WriteLine (IsBinarySearchTree(t));
			t.left.data = 0;
			Console.WriteLine (IsBinarySearchTree(t));
			t.right = new BTNode (-1);
			Console.WriteLine (IsBinarySearchTree(t));

		}
	}
}

