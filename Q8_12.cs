using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_12
	{
		public static List<int[]> GetQueenPlacements()
		{
			List<int[]> results = new List<int[]> ();
			PlaceQueens(0, new int[8], results);
			return results;
		}

		private static void PlaceQueens(int row, int[] cols, List<int[]> list)
		{
			if (row == cols.Length) {
				list.Add ((int[])cols.Clone());
				return;
			}
			for (int i = 0; i < cols.Length; ++i) {
				if (CheckValid (row, i, cols)) {
					cols [row] = i;
					PlaceQueens (row + 1, cols, list);
				}
			}
		}

		private static bool CheckValid(int row1, int col1, int[] cols)
		{
			for (int row2 = 0; row2 < row1; ++row2) {
				if (col1 == cols [row2] ||
				    row1 - row2 == Math.Abs (col1 - cols [row2])) {
					return false;
				}
			}
			return true;
		}

		public static void RunTests ()
		{
			List<int[]> list = GetQueenPlacements ();
			Util.Print (list);
		}
	}
}

