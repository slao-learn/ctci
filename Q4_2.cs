using System;

namespace ctci
{
	public class Q4_2
	{
		public static BTNode CreateMinimalBST(int[] arr)
		{
			return CreateMinimalBST (arr, 0, arr.Length - 1);
		}

		private static BTNode CreateMinimalBST(int[] arr, int left, int right)
		{
			if (left > right)
				return null;
			int mid = left + (right - left) / 2;
			BTNode n = new BTNode (arr [mid]);
			n.left = CreateMinimalBST (arr, left, mid - 1);
			n.right = CreateMinimalBST (arr, mid + 1, right);
			return n;
		}

		public static void RunTests()
		{
//			BTNode t = new BTNode (1);
//			t.left = new BTNode (2);
//			t.right = new BTNode (3);
//			t.left.right = new BTNode (4);
//			t.right.left = new BTNode (5);
//			Console.WriteLine (t);

			Console.WriteLine (CreateMinimalBST (new int[] { 1 }));
			Console.WriteLine (CreateMinimalBST (new int[] { 1, 2, 3 }));
			Console.WriteLine (CreateMinimalBST (new int[] { 1, 2, 3, 4, 5, 6 }));
			Console.WriteLine (CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10 }));
		}

	}
}

