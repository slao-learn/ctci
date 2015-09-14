using System;

namespace ctci
{
	public class Q16_1
	{
		public static void Swap(int a, int b)
		{
			Console.WriteLine ("Before: {0} {1}", a, b);
			a = a ^ b;
			b = a ^ b;
			a = a ^ b;
			Console.WriteLine ("After: {0} {1}", a, b);
		}

		public static void RunTests()
		{
			Swap (1, 3);
			Swap (5, -10);
			Swap (0, 1);
		}
	}
}

