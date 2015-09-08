using System;

namespace ctci
{
	public class Q8_1
	{
		public static long CountWays(int n)
		{
			long[] memo = new long[n + 1];
			for (int i = 0; i < memo.Length; ++i) {
				memo [i] = -1;
			}
			return CountWays (n, memo);
		}

		private static long CountWays(int n, long[] memo)
		{
			if (n == 0)
				return 1;
			if (n < 0)
				return 0;
			if (memo [n] > -1)
				return memo [n];
			memo [n] = CountWays (n - 1, memo) + CountWays (n - 2, memo) + CountWays (n - 3, memo);
			return memo [n];
		}

		public static void RunTests()
		{
			Console.WriteLine (CountWays (100));
			Console.WriteLine (CountWays (30));
			Console.WriteLine (CountWays (3));
			Console.WriteLine (CountWays (4));
			Console.WriteLine (CountWays (5));
		}
	}
}

