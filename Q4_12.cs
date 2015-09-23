using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q4_12
	{
		// O(n^2) runtime
		public static int CountPathsSimple(BTNode t, int sum)
		{
			if (t == null)
				return 0;
			int preCount = 0;
			if (t.data == sum)
				preCount = 1;
			return preCount +
					CountPaths (t.left, sum - t.data) +
					CountPaths (t.right, sum - t.data) +
					CountPaths (t.left, sum) +
					CountPaths (t.right, sum);
		}

		// O(n) runtime
		public static int CountPaths(BTNode t, int sum)
		{
 			Dictionary<int, int> h = new Dictionary<int, int> ();
			IncrementHashCount (h, 0);
			int total = CountPaths (t, sum, 0, h);
			if (sum == 0) // special case, do not include initial 0 count (don't include empty paths)
				--total;
			return total;
		}

		private static void IncrementHashCount(Dictionary<int, int> h, int key)
		{
			if (h.ContainsKey (key))
				++h [key];
			else
				h [key] = 1;
		}

		private static int CountPaths(BTNode t, int target, int running, Dictionary<int, int> h)
		{
			if (t == null)
				return 0;
			
			running += t.data;
			IncrementHashCount (h, running);

			int keySubPaths = running - target;
			int totalPaths = h.ContainsKey (keySubPaths) ? h[keySubPaths] : 0;
			if (target == 0) // special case, do not include increment from this iteration
				--totalPaths;

			totalPaths += CountPaths (t.left, target, running, h);
			totalPaths += CountPaths (t.right, target, running, h);

			// revert changes to traverse different paths
			--h[running];

			return totalPaths;
		}

		public static void RunTests ()
		{
			BTNode t = Q4_2.CreateMinimalBST (new int[] { -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			Console.WriteLine (t);
			Console.WriteLine (CountPaths(t, 0));
			Console.WriteLine (CountPaths(t, 7));
			Console.WriteLine (CountPaths(t, 3));
			Console.WriteLine (CountPaths(t, 1));
			Console.WriteLine (CountPaths(t, 9));
			Console.WriteLine (CountPaths(t, -3));
		}
	}
}

