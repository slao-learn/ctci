using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_7
	{
		public static List<string> GetPermutations(string s)
		{
			List<string> results = new List<string> ();
			GetPermutations ("", s, results);
			return results;
		}

		private static void GetPermutations(string prefix, string remainder, List<string> list)
		{
			if (remainder.Length == 0) {
				list.Add (prefix);
			}
			for (int i = 0; i < remainder.Length; ++i) {
				string before = remainder.Substring (0, i);
				string after = remainder.Substring (i + 1, remainder.Length - i - 1);
				char c = remainder [i];
				GetPermutations (prefix + c, before + after, list);
			}
		}

		public static void RunTests ()
		{
			Util.Print (GetPermutations ("abcd"));
		}
	}
}

