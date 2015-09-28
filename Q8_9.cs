using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_9
	{
		public static List<string> GetParenSet(int n)
		{
			List<string> list = new List<string> ();
			GetParenSet (n, n, new char[2*n], 0, list);
			return list;
		}

		private static void GetParenSet(int leftParens, int rightParens, char[] s, int index, List<string> list)
		{
			if (leftParens < 0 || rightParens < 0)
				return;
			
			if (leftParens == 0 && rightParens == 0) {
				list.Add(new String (s));
				return;
			}

			s [index] = '(';
			GetParenSet (leftParens - 1, rightParens, s, index + 1, list);

			if (leftParens < rightParens) {
				s [index] = ')';
				GetParenSet (leftParens, rightParens - 1, s, index + 1, list);
			}
		}

		public static void RunTests ()
		{
			Util.Print(GetParenSet (0));
			Util.Print(GetParenSet (1));
			Util.Print(GetParenSet (3));
			Util.Print(GetParenSet (5));
		}
	}
}

