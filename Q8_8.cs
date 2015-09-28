using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_8
	{
		public static List<string> GetPermutations(string s)
		{
			List<string> results = new List<string> ();
			Dictionary<char, int> map = MapChars(s);
			char[] keySet = new char[map.Keys.Count];
			map.Keys.CopyTo (keySet, 0);
			GetPermutations (map, keySet, "", s.Length, results);
			return results;
		}

		private static Dictionary<char, int> MapChars(string s)
		{
			Dictionary<char, int> map = new Dictionary<char, int> ();
			for (int i = 0; i < s.Length; ++i)
			{
				if (!map.ContainsKey (s [i]))
				{
					map [s [i]] = 0;
				}
				++map [s [i]];
			}
			return map;
		}

		private static void GetPermutations(Dictionary<char, int> map, char[] keySet, string prefix, int remaining, List<string> list)
		{
			if (remaining == 0) {
				list.Add (prefix);
			}
			for (int i = 0; i < keySet.Length; ++i)
			{
				char c = keySet [i];
				int count = map [c];
				if (count > 0) {
					map [c] = count - 1;
					GetPermutations (map, keySet, prefix + c, remaining - 1, list);
					map [c] = count; 
				}
			}
		}

		public static void RunTests ()
		{
			Util.Print (GetPermutations ("abcd"));
			Util.Print (GetPermutations ("aabb"));
			Util.Print (GetPermutations ("aaaa"));
		}
	}
}

