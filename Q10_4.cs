using System;

namespace ctci
{
	public class Q10_4
	{
		public static int Find(int[] arr, int n)
		{
			int i = 1;
			while (ElementAt (arr, i) < n && ElementAt (arr, i) != -1) {
				i <<= 1;
			}
			int l = i >> 1;
			int r = i;
			while (l <= r) {
				int m = l + (r - l) / 2;
				if (ElementAt (arr, m) == n)
					return m;
				else if (ElementAt (arr, m) == -1 || n < ElementAt (arr, m))
					r = m - 1;
				else
					l = m + 1;
			}
			return -1;
		}

		private static int ElementAt(int[] arr, int i)
		{
			if (i >= arr.Length || i < 0)
				return -1;
			else
				return arr [i];
		}

		public static void RunTests ()
		{
			Console.WriteLine (Find(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5));	
			Console.WriteLine (Find(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7));	
			Console.WriteLine (Find(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1));
			Console.WriteLine (Find(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 10));
			Console.WriteLine (Find (new int[] { 1, 2, 2, 4, 5, 5, 7 }, 5));
		}
	}
}

