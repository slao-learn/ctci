using System;

namespace ctci
{
	public class Q17_1
	{
		public static int Add(int a, int b)
		{
			while (b != 0) {
				int sum = a ^ b;
				int carry = (a & b) << 1;
				a = sum;
				b = carry;
			}
			return a;
		}

		public static void RunTests()
		{
			Console.WriteLine (Add(1, 1));
			Console.WriteLine (Add(4, 0));
			Console.WriteLine (Add(-1, 4));
		}
	}
}

