using System;

namespace ctci
{
	public class Q10_3
	{
		public static int FindElement(int[] arr, int value)
		{
			int l = 0, r = arr.Length - 1;
			while (l <= r) {
				int m = l + (r - l) / 2;
				if (arr [m] == value)
					return m;
				else if (arr [m] > arr [l]) {
					if (value >= arr [l] && value < arr [m])
						r = m - 1;
					else
						l = m + 1;
				} else if (arr [m] < arr [l]) {
					if (value > arr [m] && value <= arr [r])
						l = m + 1;
					else
						r = m - 1;
				} else {
					l = m + 1;
				}
			}
			return -1;
		}

		public static void RunTests ()
		{
			Console.WriteLine (FindElement(new int[] { 3, 4, 5, 6, 1, 2}, 1));
			Console.WriteLine (FindElement(new int[] { 3, 4, 5, 6, 1, 2}, 6));
			Console.WriteLine (FindElement(new int[] { 3, 4, 5, 6, 1, 2}, 3));
			Console.WriteLine (FindElement(new int[] { 3, 3, 3, 6, 1, 2}, 6));
			Console.WriteLine (FindElement(new int[] { 3, 3, 3, 6, 1, 2}, 1));
			Console.WriteLine (FindElement(new int[] { 3, 3, 3, 6, 1, 2}, 3));
			Console.WriteLine (FindElement(new int[] { 4, 1, 2, 3, 3, 3}, 4));
			Console.WriteLine (FindElement(new int[] { 4, 1, 2, 3, 3, 3}, 1));
			Console.WriteLine (FindElement(new int[] { 4, 1, 2, 3, 3, 3}, 3));
			Console.WriteLine (FindElement(new int[] { 3, 3, 3, 3, 3, 3}, 5));
			Console.WriteLine (FindElement(new int[] { 3, 4, 5, 1, 1, 2, 3}, 2));
			Console.WriteLine (FindElement(new int[] { 3, 4, 5, 1, 1, 2, 3}, 3));
			Console.WriteLine (FindElement(new int[] { 3, 4, 5, 1, 1, 2, 3}, 5));
		}
	}
}

