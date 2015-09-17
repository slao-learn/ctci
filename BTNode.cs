using System;
using System.Collections.Generic;

namespace ctci
{
	public class BTNode
	{
		public int data;
		public BTNode left;
		public BTNode right;

		public BTNode(int data)
		{
			this.data = data;
		}

		public override string ToString ()
		{
			string result = "";
			int height = GetHeight (this);
			Console.WriteLine ("height = " + height);
			BTNode dummy = new BTNode (-1);
			List<BTNode> curLevel = new List<BTNode>();
			curLevel.Add (this);
			for (int i = 0; i < height; ++i) {
				string indent = new string ('\t', (int)Math.Pow (2, height - i - 1));
				string sep = new string ('\t', (int)Math.Pow (2, height - i));
				result += indent;
				List<BTNode> nextLevel = new List<BTNode> ();
				foreach (BTNode n in curLevel) {
					if (n == dummy)
						result += sep;
					else
						result += n.data.ToString() + sep;
					nextLevel.Add (n.left ?? dummy);
					nextLevel.Add (n.right ?? dummy);
				}
				result += '\n';
				curLevel = nextLevel;
			}
			return result;
		}

		private int GetHeight(BTNode node)
		{
			if (node == null)
				return 0;
			int leftHeight = GetHeight (node.left);
			int rightHeight = GetHeight (node.right);
			return 1 + Math.Max (leftHeight, rightHeight);
		}
	}
}

