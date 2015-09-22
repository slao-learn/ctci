using System;

namespace ctci
{
	public class Q4_8
	{
		public static BTNode FindFCA(BTNode n, BTNode a, BTNode b)
		{
			int c = 0;
			BTNode fca = Count (n, a, b, out c);
			return (c == 2 ? fca : null);
		}

		private static BTNode Count(BTNode n, BTNode a, BTNode b, out int c)
		{
			if (n == null) {
				c = 0;
				return null;
			}

			int left = 0;
			BTNode leftFCA = Count (n.left, a, b, out left);
			int right = 0;
			BTNode rightFCA = Count (n.right, a, b, out right);

			c = left + right;
			if (n == a || n == b) {
				c += 1;
				return n;
			}
			if (left == 1 && right == 1)
				return n;
			
			return leftFCA ?? rightFCA;
		}

		public static void RunTests()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12, 15, 16, 17, 20, 50, 75, 100 });
			Console.WriteLine (t);
			Console.WriteLine (FindFCA(t, t.left.left, t.left.right.left).data);
			Console.WriteLine (FindFCA (t, t.left, t.right).data);
			Console.WriteLine (FindFCA (t, t, t.right).data);
			Console.WriteLine (FindFCA (t, t.right.left, t.right.right).data);
			Console.WriteLine (FindFCA (t, t.right.left, new BTNode(150)) == null ? "null!" : "notnull");
		}
	}
}

