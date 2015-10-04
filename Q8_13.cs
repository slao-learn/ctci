using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_13
	{
		public class Box
		{
			public int width;
			public int height;
			public int depth;
			public Box(int w, int h, int d)
			{
				width = w;
				height = h;
				depth = d;
			}
		}

		public static int TallestStack(List<Box> boxes)
		{
			return GetTallestStack (boxes, new Stack<Box> (), 0);
		}

		private static int GetTallestStack(List<Box> boxes, Stack<Box> stack, int currentHeight)
		{
			Box topBox = stack.IsEmpty() ? null : stack.Peek ();
			int tallestHeight = currentHeight;
			for (int i = 0; i < boxes.Count; ++i) {
				Box selected = boxes [i];
				if (topBox == null ||
					(selected.width < topBox.width && selected.height < topBox.height && selected.depth < topBox.depth))
				{
					stack.Push (selected);
					int height = GetTallestStack(boxes, stack, currentHeight + selected.height);
					stack.Pop ();
					tallestHeight = Math.Max (height, tallestHeight);
				}
			}
			return tallestHeight;
		}

		private static int ComputeHeight(List<Box> stack)
		{
			int total = 0;
			for (int i = 0; i < stack.Count; ++i) {
				total += stack [i].height;
			}
			return total;
		}
			
		public static void RunTests ()
		{
			List<Box> boxes = new List<Box> () {
				new Box (1, 1, 1),
				new Box (2, 2, 2),
				new Box (2, 3, 3),
				new Box (5, 3, 4)
			};
			Console.WriteLine (TallestStack(boxes));

			boxes = new List<Box> () {
				new Box (10, 3, 7)
			};
			Console.WriteLine (TallestStack(boxes));

			boxes = new List<Box> () {
				new Box (10, 3, 7),
				new Box (1, 4, 3)
			};
			Console.WriteLine (TallestStack(boxes));
		}
	}
}

