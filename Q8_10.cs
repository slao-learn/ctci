using System;

namespace ctci
{
	public class Q8_10
	{
		public enum Color
		{
			Black = 0,
			White = 1,
			Red = 2,
			Yellow = 3,
			Green = 4
		}

		public static bool PaintFill(Color[,] colors, int r, int c, Color ncolor)
		{
			if (r < 0 || r >= colors.GetLength (0) || c < 0 || c >= colors.GetLength (1))
				return false;
			if (ncolor == colors [r, c])
				return false;
			return PaintFill (colors, r, c, colors [r, c], ncolor);
		}

		private static bool PaintFill(Color[,] colors, int r, int c, Color ocolor, Color ncolor)
		{
			if (r < 0 || r >= colors.GetLength (0) || c < 0 || c >= colors.GetLength (1))
				return false;

			bool result = false;
		
			if (colors [r, c] == ocolor)
			{
				colors [r, c] = ncolor;
				result = true;
				result |= PaintFill(colors, r - 1, c, ocolor, ncolor);
				result |= PaintFill(colors, r + 1, c, ocolor, ncolor);
				result |= PaintFill(colors, r, c - 1, ocolor, ncolor);
				result |= PaintFill(colors, r, c + 1, ocolor, ncolor);
			}

			return result;
		}

		// update project to use interactive console
		public static void RunTests ()
		{
			Color[,] colors = GenerateColors (5, 5);
			Print (colors);
			while (true) {
				string command = Console.ReadLine ();
				if (command != null) {
					string[] parts = command.Split (' ');
					int r = Convert.ToInt32 (parts [0]);
					int c = Convert.ToInt32 (parts [1]);
					Color ncolor = (Color)(Convert.ToInt32 (parts [2]));
					bool result = PaintFill (colors, r, c, ncolor);
					Console.WriteLine (result);
					Console.WriteLine ();
					Print (colors);
				}
			}
		}

		private static Color[,] GenerateColors(int r, int c)
		{
			Color[,] colors = new Color[r, c];
			Random rand = new Random();
			for (int i = 0; i < r; ++i)
				for (int j = 0; j < c; ++j)
					colors [i, j] = (Color)rand.Next(5);
			return colors;
		}

		private static void Print(Color[,] colors)
		{
			for (int r = 0; r < colors.GetLength (0); ++r) {
				for (int c = 0; c < colors.GetLength (1); ++c) {
					Console.Write (colors [r, c].ToString()[0] + " ");
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}
	}
}

