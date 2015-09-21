using System;

namespace ctci
{
	public class Q4_6
	{
		public static BTNode GetInorderSuccessor(BTNode n)
		{
			if (n == null)
				return null;
			if (n.right != null) {	
				n = n.right;
				while (n.left != null)
					n = n.left;
				return n;
			} else {
				while (n.parent != null) {
					if (n.parent.left == n)
						return n.parent;
					n = n.parent;
				}
				return null;
			}
		}

		public static void RunTests()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12, 15, 16, 17, 20, 50, 75, 100 });
			Console.WriteLine (GetInorderSuccessor(t).data);
			Console.WriteLine (GetInorderSuccessor(t.left.right.right).data);
			Console.WriteLine (GetInorderSuccessor(t.right.right.right) == null ? "null" : "not null");
		}
	}
}
