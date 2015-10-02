using System;

namespace ctci
{
	public class Q8_11
	{
		public static int MakeChange(int n)
		{
			int[] denoms = new int[4] { 25, 10, 5, 1 };
			int[,] ways = new int[n+1,4];
			return MakeChange (n, denoms, 0, ways);
		}

		private static int MakeChange(int amount, int[] denoms, int index, int[,] ways)
		{
			if (index >= denoms.Length - 1)
				return 1;

			if (ways [amount,index] > 0)
				return ways [amount,index];

			int denomValue = denoms [index];
			int numWays = 0;
			for (int i = 0; i * denomValue <= amount; ++i) {
				int remaining = amount - i * denomValue;
				numWays += MakeChange (remaining, denoms, index + 1, ways);
			}
			ways [amount,index] = numWays;
			return numWays;
		}

		public static void RunTests ()
		{
			Console.WriteLine (MakeChange(1));
			Console.WriteLine (MakeChange(5)); 
			Console.WriteLine (MakeChange(10));
			Console.WriteLine (MakeChange(11));
			Console.WriteLine (MakeChange(25));
			Console.WriteLine (MakeChange(28));
			Console.WriteLine (MakeChange(50));
			Console.WriteLine (MakeChange(100));
		}
	}
}

