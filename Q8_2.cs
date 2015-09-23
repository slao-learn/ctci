using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_2
	{
		public enum Movement
		{
			RIGHT,
			DOWN
		}

		public static List<Movement> FindPath(bool[,] blocks)
		{
			int r = blocks.GetLength (0);
			int c = blocks.GetLength (1);
			return FindPath (0, 0, r - 1, c - 1, new List<Movement> (), blocks);
		}

		private static List<Movement> FindPath(int r, int c, int dr, int dc, List<Movement> path, bool[,] blocks)
		{
			if (r == dr && c == dc)
				return path;
			
			blocks [r, c] = true;

			if (CanMove (r, c, Movement.DOWN, blocks)) {
				path.Add (Movement.DOWN);
				List<Movement> finalPath = FindPath (r + 1, c, dr, dc, path, blocks);
				if (finalPath != null)
					return finalPath;
				else
					path.RemoveAt (path.Count - 1);
			}

			if (CanMove (r, c, Movement.RIGHT, blocks)) {
				path.Add (Movement.RIGHT);
				List<Movement> finalPath = FindPath (r, c + 1, dr, dc, path, blocks);
				if (finalPath != null)
					return finalPath;
				else
					path.RemoveAt (path.Count - 1);
			}

			return null;
		}

		private static bool CanMove(int r, int c, Movement m, bool[,] blocks)
		{
			int nr = m == Movement.DOWN ? r + 1 : r;
			int nc = m == Movement.RIGHT ? c + 1 : c;
			return (nr >= 0 && nr < blocks.GetLength(0) &&
				nc >= 0 && nc < blocks.GetLength(1) &&
				!blocks[nr, nc]);
		}

		public static void RunTests ()
		{
			bool[,] blocks = new bool[5, 6];
			blocks [0, 4] = true;
			blocks [4, 0] = true;
			blocks [1, 1] = true;
			blocks [2, 2] = true;
			blocks [2, 3] = true;
			blocks [3, 4] = true;
			blocks [4, 2] = true;
			Print (blocks);
			Print(FindPath (blocks));
		}

		private static void Print(bool[,] t)
		{
			for (int i = 0; i < t.GetLength (0); ++i) {
				for (int j = 0; j < t.GetLength (1); ++j) {
					if (t[i, j])
						Console.Write("1 ");
					else
						Console.Write("0 ");
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}

		private static void Print(List<Movement> l)
		{
			if (l == null) {
				Console.WriteLine ("null");
				return;
			}
			foreach (var m in l) {
				if (m == Movement.RIGHT)
					Console.Write ("R ");
				else
					Console.Write ("D ");
			}
			Console.WriteLine ();
		}

	}
}

