using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q8_4
	{
		public static List<List<int>> GetPowerset(List<int> a)
		{
			return GetPowerset (a, 0);
		}

		private static List<List<int>> GetPowerset(List<int> a, int index)
		{
			List<List<int>> subsets = null;
			if (index == a.Count) {
				subsets = new List<List<int>> ();
				subsets.Add (new List<int> ());
			} else {
				int item = a [index];
				subsets = GetPowerset (a, index + 1);
				List<List<int>> moresubsets = new List<List<int>> ();
				for (int i = 0; i < subsets.Count; ++i) {
					List<int> newSubset = new List<int> (subsets[i]);
					newSubset.Add (item);
					moresubsets.Add (newSubset);
				}
				subsets.AddRange (moresubsets);
			}
			return subsets;
		}

		public static void RunTests ()
		{
			Util.Print (GetPowerset (new List<int> () { 1 }));	
			Util.Print (GetPowerset (new List<int> () { 1, 2 }));
			Util.Print (GetPowerset (new List<int> () { 1, 2, 3 }));	
			Util.Print (GetPowerset (new List<int> () { 1, 2, 3, 4 }));	
		}
	}
}

