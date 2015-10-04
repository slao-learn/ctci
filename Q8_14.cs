using System;

namespace ctci
{
	public class Q8_14
	{
		public static int NumWays(string expr, bool result)
		{
			int numTrues, numFalses;
			Eval (expr, 0, expr.Length - 1, out numTrues, out numFalses);
			return result ? numTrues : numFalses;
		}

		public static void Eval(string expr, int b, int e, out int trues, out int falses)
		{
			if (b == e) {
				trues = (expr [b] == '1') ? 1 : 0;
				falses = (expr [b] == '0') ? 1 : 0;
				return;
			}

			trues = 0;
			falses = 0;
			for (int i = b + 1; i < e; i += 2)
			{
				char c = expr [i];

				int leftTrues, leftFalses;
				Eval (expr, b, i - 1, out leftTrues, out leftFalses);
				int rightTrues, rightFalses;
				Eval (expr, i + 1, e, out rightTrues, out rightFalses);

				int trueWays = 0;
				int totalWays = (leftTrues + leftFalses) * (rightTrues + rightFalses);
				if (c == '&') {
					trueWays = leftTrues * rightTrues;
				} else if (c == '|') {
					trueWays = totalWays - (leftFalses * rightFalses);
				} else if (c == '^') {
					trueWays = leftTrues * rightFalses + leftFalses * rightTrues;
				}

				trues += trueWays;
				falses += (totalWays - trueWays);
			}
		}

		public static void RunTests ()
		{
			Console.WriteLine (NumWays("1^0|0|1", false));
			Console.WriteLine (NumWays("0&0&0&1^1|0", true));
			Console.WriteLine (NumWays("1", true));
			Console.WriteLine (NumWays("1", false));
		}
	}
}

