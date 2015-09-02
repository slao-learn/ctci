using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q1_1
	{
		public static bool IsUnique (string s)
		{
			// TODO check for null

			List<char> found = new List<char> ();
			for (int i = 0; i < s.Length; ++i) {
				if (!found.Contains (s [i]))
					found.Add (s [i]);
				else
					return false;
			}
			return true;
		}

		public static bool IsUnique26Chars(string s)
		{
			// TODO check for null

			int check = 0;
			for (int i = 0; i < s.Length; ++i) {
				int val = (int)(s [i] - 'a');
				if ((check & (1 << val)) > 0)
					return false;
				check |= 1 << val;
			}
			return true;
		}

		public static void RunTests()
		{
			Console.WriteLine (IsUnique ("abcdefg"));
			Console.WriteLine (IsUnique ("abcdecfg"));

			Console.WriteLine (IsUnique26Chars ("abcdefg"));
			Console.WriteLine (IsUnique26Chars ("abcdecfg"));
		}
	}
}

