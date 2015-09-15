using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q1_2
	{
		public static bool ArePermutations(string a, string b)
		{
			if (a.Length != b.Length)
				return false;
			
			Dictionary<char, int> t = new Dictionary<char, int> ();
			for (int i = 0; i < a.Length; ++i) {
				char c = a [i];
				if (t.ContainsKey (c))
					++t [c];
				else
					t [c] = 1;
			}

			for (int i = 0; i < b.Length; ++i) {
				char c = b [i];
				if (!t.ContainsKey (c) || t [c] == 0)
					return false;
				--t [c];
			}
			return true;
		}

		public static void RunTests()
		{
			Console.WriteLine (ArePermutations ("abc", "bca"));
			Console.WriteLine (ArePermutations ("abc", "bcc"));
		}
	}
}

