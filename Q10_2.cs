using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q10_2
	{
		public static void GroupAnagrams(string[] words)
		{
			Dictionary<string, List<string>> map = new Dictionary<string, List<string>> ();
			for (int i = 0; i < words.Length; ++i) {
				string s = Sort (words [i]);
				if (map.ContainsKey (s))
					map [s].Add (words [i]);
				else
					map [s] = new List<string> () { words [i] };
			}

			int index = 0;
			foreach (string sorted in map.Keys) {
				List<string> l = map[sorted];
				foreach(string s in l)
				{
					words [index++] = s;
				}
			}
		}

		private static string Sort(string s)
		{
			char[] chars = s.ToCharArray ();
			Array.Sort (chars);
			return new string (chars);
		}

		public static void RunTests ()
		{
			string[] words = new string[] { "abc", "def", "cba", "123", "fed" };
			GroupAnagrams (words);
			Util.Print (words);
		}
	}
}

