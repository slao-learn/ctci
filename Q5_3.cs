using System;

namespace ctci
{
	public class Q5_3
	{
		public static int FlipBit(int n)
		{
			const int NUM_BITS = sizeof(int) * 8;
			int count1 = 0, count2 = 0, max = 1;
			bool flipped1 = false;
			for (int i = 0; i < NUM_BITS; ++i)
			{
				if ((n & 1) == 1) {
					++count1;
					++count2;
				} else if (!flipped1) {
					flipped1 = true;
					++count1;
					count2 = 0;
				} else {
					flipped1 = false;
					++count2;
					count1 = 0;
				}
				max = Math.Max (max, Math.Max(count1, count2));
				if (n == 0) break;
				n = (int)((uint)n >> 1);
			}
			return max;
		}

		public static void RunTests()
		{
			Console.WriteLine (FlipBit(-1));
			Console.WriteLine (FlipBit(int.MaxValue));
			Console.WriteLine (FlipBit(-10));
			Console.WriteLine (FlipBit(0));
			Console.WriteLine (FlipBit(1));
			Console.WriteLine (FlipBit(15));
			Console.WriteLine (FlipBit(1775));
		}
	}
}

