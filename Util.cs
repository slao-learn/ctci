﻿using System;
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

		public static void Print(List<int[]> a)
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


		public static void Print(List<int> list)
		{
			foreach(var i in list)
				Console.Write (i + " ");
			Console.WriteLine ();
		}

		public static void Print(List<string> list)
		{
			foreach(var i in list)
				Console.WriteLine (i + " ");
			Console.WriteLine ();
		}



	}
}

