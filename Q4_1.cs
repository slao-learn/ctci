using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q4_1
	{
		public static bool HasRouteDFS(GraphNode<int> a, GraphNode<int> b)
		{
			List<GraphNode<int>> visited = new List<GraphNode<int>> ();
			return HasRouteDFSHelper (a, b, visited);
		}

		private static bool HasRouteDFSHelper(GraphNode<int> s, GraphNode<int> d, List<GraphNode<int>> visited)
		{
			if (s == null)
				return false;
			if (s == d)
				return true;
			visited.Add (s);
			for (int i = 0; i < s.children.Count; ++i) {
				if (!visited.Contains (s.children [i]) &&
				    HasRouteDFSHelper (s.children [i], d, visited))
					return true;
			}
			return false;
		}

		public static bool HasRouteBFS(GraphNode<int> a, GraphNode<int> b)
		{
			List<GraphNode<int>> visited = new List<GraphNode<int>> ();
			Queue<GraphNode<int>> q = new Queue<GraphNode<int>> ();
			q.Enqueue (a);
			while (q.Count > 0) {
				GraphNode<int> n = q.Dequeue ();
				if (n == b)
					return true;
				visited.Add (n);
				for (int i = 0; i < n.children.Count; ++i) {
					GraphNode<int> c = n.children [i];
					if (c == b)
						return true;
					if (!visited.Contains (c))
						q.Enqueue (c);
				}
			}
			return false;
		}

		public static void RunTests()
		{
			List<GraphNode<int>> c = new List<GraphNode<int>> ();
			c.Add(GraphNode<int>.Create (8));
			GraphNode<int> seven = GraphNode<int>.Create (7);
			c.Add(seven);
			c = new List<GraphNode<int>> () {
				GraphNode<int>.Create (6, c)
			};
			c = new List<GraphNode<int>> () {
				GraphNode<int>.Create (3, c)
			};
			c.Add (GraphNode<int>.Create (2, GraphNode<int>.Create (5)));
			c.Add (GraphNode<int>.Create (4, GraphNode<int>.Create (9)));

			GraphNode<int> g = GraphNode<int>.Create (1, c);
			GraphNode<int> other = new GraphNode<int> (10);

			Console.WriteLine (HasRouteDFS (g, other));
			Console.WriteLine (HasRouteDFS (g, seven));
			Console.WriteLine (HasRouteBFS (g, other));
			Console.WriteLine (HasRouteBFS (g, seven));

		}
	}
}

