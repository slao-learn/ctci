using System;

namespace ctci
{
	public class Q8_3
	{
		public static int FindMagicIndexBrute(int[] a)
		{
			for (int i = 0; i < a.Length; ++i) {
				if (a [i] == i)
					return i;
			}
			return -1;
		}

		public static int FindMagicIndexDistinct(int[] a)
		{
			int l = 0, r = a.Length - 1;
			while (l <= r) {
				int m = (l + r) / 2;
				if (a [m] == m) {
					return m;
				} else if (a [m] > m) {
					r = m - 1;
				} else {
					l = m + 1;
				}
			}
			return -1;
		}

		public static int FindMagicIndex(int[] a)
		{
			return FindMagicIndex (a, 0, a.Length - 1);
		}

		private static int FindMagicIndex(int[] a, int l, int r)
		{
			if (l == r) {
				return a [l] == l ? l : -1;
			}

			int m = (l + r) / 2;
			if (a [m] == m) {
				return m;
			} else
			{
				int lMax = Math.Min (a [m], m - 1);
				if (lMax >= l) {
					int leftFind = FindMagicIndex (a, l, lMax);
					if (leftFind >= 0)
						return leftFind;
				}

				int rMin = Math.Max (a [m], m + 1);
				if (rMin <= r) {
					int rightFind = FindMagicIndex (a, rMin, r);
					return rightFind;
				}

				return -1;
			}
		}

		public static void RunTests ()
		{
			Console.WriteLine (FindMagicIndex (new int[] { -2, 0, 5, 6, 7, 8, 10 }));
			Console.WriteLine (FindMagicIndex (new int[] { -2, 0, 2, 5, 6, 9, 10 }));
			Console.WriteLine (FindMagicIndex (new int[] { -2, 0, 3, 2, 3, 4, 6 }));
			Console.WriteLine (FindMagicIndex (new int[] { -2, -2, -2, 2, 3, 4, 6, 8, 10 }));
		}
	}
}

