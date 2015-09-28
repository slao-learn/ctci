using System;

namespace ctci
{
	public class Q8_5
	{
		public static int Multiply(int a, int b)
		{
			if (b > a)
				return Multiply (b, a);
			
			if (a == 0)
				return 0;
			else if (a == 1)
				return b;

			int s = Multiply (a >> 1, b);
			if (a % 2 == 0)
				return s + s;
			else
				return s + s + b;
		}

		public static void RunTests ()
		{
			Console.WriteLine (Multiply(4, 5));
			Console.WriteLine (Multiply(3, 10));
			Console.WriteLine (Multiply(6, 11));
			Console.WriteLine (Multiply(0, 1));
			Console.WriteLine (Multiply(1, 10));
			Console.WriteLine (Multiply(20, 15));
		}
	}
}

