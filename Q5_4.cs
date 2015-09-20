using System;

namespace ctci
{
	public class Q5_4
	{
		public static void PrintNextNumbers(int n)
		{
			Console.WriteLine ("n={0}, next={1}, prev={2}", n, GetNext(n), GetPrev(n));
		}

		private static int GetNext(int n)
		{
			int r = n;
			int c0 = 0, c1 = 0;

			while (r != 0 && (r & 1) == 0) {
				++c0;
				r >>= 1;
			}

			while ((r & 1) == 1) {
				++c1;
				r >>= 1;
			}

			int p = c0 + c1;
			if (p == 0 || p >= sizeof(int) * 8 - 1)
				return -1;

			n |= (1 << p);
			n &= ~((1 << p) - 1);
			n |= (1 << (c1 - 1)) - 1;

			return n;
		}

		private static int GetPrev(int n)
		{
			int r = n;
			int c0 = 0, c1 = 0;

			while ((r & 1) == 1) {
				++c1;
				r >>= 1;
			}

			while (r != 0 && (r & 1) == 0) {
				++c0;
				r >>= 1;
			}

			int p = c0 + c1;
			if (p == 0 || c0 == 0)
				return -1;

			n &= ~(1 << (p + 1) - 1);
			n |= (1 << (c0 - 1)) - 1;

			return n;
		}

		public static void RunTests()
		{
			PrintNextNumbers(10);
			PrintNextNumbers(int.MaxValue - 1);
			PrintNextNumbers(1);
			PrintNextNumbers(13948);
			PrintNextNumbers(12345);
		}
	}
}

