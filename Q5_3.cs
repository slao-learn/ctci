using System;

namespace ctci
{
	public class Q5_3
	{
		public static int FlipBit(int n)
		{
			int count1 = 0, count2 = 0, max = 1;
			bool flipped1 = false, flipped2 = false;
			while (n != 0) {
				if ((n & 1) == 1) {
					++count1;
					++count2;
				} else if (!flipped1) {
					flipped1 = true;
					++count1;
					flipped2 = false;
					count2 = 0;
				} else if (!flipped2) {
					flipped2 = true;
					++count2;
					flipped1 = false;
					count1 = 0;
				}
				max = Math.Max (max, count1);
				max = Math.Max (max, count2);
				n = (int)((uint)n >> 1);
			}
			return max;
		}

		public static void RunTests()
		{
			Console.WriteLine (FlipBit(-1));
			Console.WriteLine (FlipBit(-10));
			Console.WriteLine (FlipBit(0));
			Console.WriteLine (FlipBit(15));
			Console.WriteLine (FlipBit(1775));
		}
	}
}

