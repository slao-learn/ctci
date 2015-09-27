using System;
using System.Collections.Generic;

namespace ctci
{
	public static class Util
	{
		public static void Print(List<List<int>> a)
		{
			foreach (var list in a) {
				Console.Write ("{ ");
				foreach (var i in list) {
					Console.Write (i + " ");
				}
				Console.WriteLine ("}");
			}
			Console.WriteLine ();
		}
	}
}

