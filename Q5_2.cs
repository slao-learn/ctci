using System;

namespace ctci
{
	public class Q5_2
	{
		public static string ConvertToBinary(double x)
		{
			if (x > 1.0 || x < 0)
				return "ERROR";
			else if (x == 1.0)
				return "1.0";
			else if (x == 0.0)
				return "0.0";
			string result = "0.";
			while (x != 0) {
				if (result.Length == 32)
					return "ERROR - " + result;
				x *= 2;
				if (x >= 1) {
					result += "1";
					x -= 1;
				} else {
					result += "0";
				}
			}
			return result;
		}

		public static void RunTests()
		{
			Console.WriteLine (ConvertToBinary (1.0));
			Console.WriteLine (ConvertToBinary (0.0));
			Console.WriteLine (ConvertToBinary(0.5));
			Console.WriteLine (ConvertToBinary(0.75));
			Console.WriteLine (ConvertToBinary(0.72));
			Console.WriteLine (ConvertToBinary(0.875));
			Console.WriteLine (ConvertToBinary(0.625));
			Console.WriteLine (ConvertToBinary(0.893));
			Console.WriteLine (ConvertToBinary(0.51));
			Console.WriteLine (ConvertToBinary(0.001));
			Console.WriteLine (ConvertToBinary(2));
		}


	}
}

