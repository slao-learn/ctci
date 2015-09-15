using System;

namespace ctci
{
	public class Q1_3
	{
		public static void URLify(char[] s, int l)
		{
			int tail = s.Length - 1;
			for (int i = l - 1; i >= 0 && i != tail; --i) {
				if (s [i] == ' ') {
					s [tail--] = '0';
					s [tail--] = '2';
					s [tail--] = '%';
				} else {
					s [tail--] = s [i];
				}
			}
		}

		public static void RunTests()
		{
			char[] s = "a b c    ".ToCharArray ();
			URLify (s, 5);
			Console.WriteLine (new String(s));
		}
	}
}

