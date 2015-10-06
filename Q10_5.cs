using System;

namespace ctci
{
	public class Q10_5
	{
		public static int Search(string[] strings, string str, int first, int last)
		{
			if (first > last)
				return -1;
			int mid = first + (last - first) / 2;

			if (strings[mid].Length == 0)
			{
				int left = mid - 1;
				int right = mid + 1;
				while (true) {
					if (left < first && right > last) {
						return -1;
					}
					if (left >= first && strings [left].Length > 0) {
						mid = left;
						break;
					} else if (right <= last && strings [right].Length > 0) {
						mid = right;
						break;
					}
					--left;
					++right;
				}
			}

			if (str == strings [mid])
				return mid;
			else if (str.CompareTo(strings [mid]) < 0)
				return Search (strings, str, first, mid - 1);
			else
				return Search (strings, str, mid + 1, last);
		}

		public static int Search(string[] strings, string str)
		{
			return Search (strings, str, 0, strings.Length - 1);
		}

		public static void RunTests ()
		{
			Console.WriteLine (Search(new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""}, "ball" ));
			Console.WriteLine (Search(new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""}, "dad" ));
		}
	}
}

