using System;

namespace ctci
{
	public class Q8_6
	{
		public class Tower
		{
			private System.Collections.Generic.Stack<int> disks = new System.Collections.Generic.Stack<int>();

			public void Add(int d)
			{
				if (disks.Count != 0 && disks.Peek () <= d) {
					Console.WriteLine ("Error placing disk " + d);
				} else {
					disks.Push (d);
				}
			}

			public void MoveToTop(Tower t)
			{
				int top = disks.Pop ();
				t.Add (top);
			}

			public void MoveDisks(int n, Tower destination, Tower buffer)
			{
				if (n > 0) {
					MoveDisks (n - 1, buffer, destination);
					MoveToTop (destination);
					buffer.MoveDisks (n - 1, destination, this);
				}
			}

			public override string ToString ()
			{
				string s = "";
				if (disks.Count == 0) {
					s = "empty";
				} else {
					foreach (int i in disks)
						s += (i + " ");
				}
				return s;
			}
		}

		public static void RunTowersOfHanoi (int n)
		{
			Tower[] towers = new Tower[3];
			for (int i = 0; i < 3; ++i) {
				towers [i] = new Tower ();
			}
			for (int i = n - 1; i >= 0; --i) {
				towers [0].Add (i);
			}
			Print (towers);
			towers [0].MoveDisks (n, towers [2], towers [1]);
			Print (towers);
		}

		public static void RunTests ()
		{
			RunTowersOfHanoi (5);
		}

		private static void Print(Tower[] t)
		{
			for (int i = 0; i < 3; ++i) {
				Console.WriteLine (t[i]);
			}
			Console.WriteLine ();
		}
	}
}

