using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q16_2
	{
		public static Dictionary<string, int> SetupDictionary(string[] book)
		{
			Dictionary<string, int> table = new Dictionary<string, int> ();
			foreach (string b in book)
			{
				if (!table.ContainsKey (b))
					table [b] = 0;
				++table [b];
			}
			return table;
		}

		public static int GetFrequency(Dictionary<string, int> table, string word)
		{
			if (word == null || table == null)
				return -1;
			word = word.ToLower ();
			int result = 0;
			table.TryGetValue (word, out result);
			return result;
		}

		public static void RunTests ()
		{
			Dictionary<string, int> table = SetupDictionary (new string[] { "the", "cat", "jumped", "over", "the", "cow" });
			Util.Print (table);
			Console.WriteLine (GetFrequency(table, "the"));
			Console.WriteLine (GetFrequency(table, "cow"));
			Console.WriteLine (GetFrequency(table, "blah"));
			Console.WriteLine (GetFrequency(table, "Jumped"));
			Console.WriteLine (GetFrequency(table, null));
		}
	}
}

