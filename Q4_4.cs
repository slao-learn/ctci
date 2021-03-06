﻿using System;

namespace ctci
{
	public class Q4_4
	{
		public static bool IsBalanced(BTNode t)
		{
			return GetHeight (t) > 0;
		}

		private static int GetHeight(BTNode n)
		{
			if (n == null)
				return 0;
			int left = GetHeight (n.left);
			if (left == -1) return -1;
			int right = GetHeight (n.right);
			if (right == -1) return -1;
			if (Math.Abs(left - right) > 1) return -1;
			return Math.Max(left, right) + 1;
		}

		public static void RunTests()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { 1, 3, 4, 5, 6, 7, 10, 12, 15, 16, 17, 20, 50, 75, 100 });
			Console.WriteLine (t);
			Console.WriteLine (IsBalanced(t));

			t = new BTNode (1);
			t.left = new BTNode (2);
			Console.WriteLine (IsBalanced(t));
			t.left.right = new BTNode (3);
			Console.WriteLine (IsBalanced(t));
			t.right = new BTNode (4);
			Console.WriteLine (IsBalanced(t));
		}
	}
}

