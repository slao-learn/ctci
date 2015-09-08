using System;

namespace ctci
{
	public class Q5_1
	{
		public static int Insert(int n, int m, int i, int j)
		{
			// clear bits i..j in n
			int mask = (1 << i) - 1;
			mask |= -1 << (j + 1);
			n &= mask;
			return n | (m << i);
		}

		public static void RunTests()
		{
			int n = 1 << 10;
			int m = 19;
			PrintBinary (n);
			PrintBinary (m);
			PrintBinary(Insert (n, m, 2, 6));
		}

		private static void PrintBinary(int i)
		{
			Console.WriteLine(Convert.ToString(i, 2));
		}
	}
}