using System;
using System.Collections.Generic;

namespace ctci
{
	public class Q4_7
	{
		public static List<char> GetBuildOrder(List<char> projs, List<KeyValuePair<char, char>> deps)
		{
			if (deps == null)
				return projs;
			
			Graph<char> g = CreateGraph (projs, deps);
			List<GraphNode<char>> buildList = new List<GraphNode<char>> ();
			for (int i = 0; i < g.nodes.Count; ++i) {
				if (!g.nodes [i].visited && !CanBuild (g.nodes [i], buildList))
					return null;
			}
			List<char> finalList = new List<char> ();
			for (int i = 0; i < buildList.Count; ++i) {
				finalList.Add (buildList [i].data);
			}
			return finalList;
		}

		private static bool CanBuild(GraphNode<char> n, List<GraphNode<char>> buildList)
		{
			if (n.visited)
				return false;
			n.visited = true;
			for (int i = 0; i < n.children.Count; ++i) {
				GraphNode<char> c = n.children [i];
				if (!buildList.Contains (c) && !CanBuild (c, buildList))
					return false;
			}
			buildList.Add (n);
			return true;
		}

		private static Graph<char> CreateGraph(List<char> projs, List<KeyValuePair<char, char>> deps)
		{
			Graph<char> g = new Graph<char> ();
			g.nodes = new List<GraphNode<char>> ();
			Dictionary<char, GraphNode<char>> map = new Dictionary<char, GraphNode<char>>();
			for (int i = 0; i < projs.Count; ++i) {
				GraphNode<char> n = new GraphNode<char> (projs [i]);
				map [projs [i]] = n;
				g.nodes.Add (n);
			}
			for (int i = 0; i < deps.Count; ++i) {
				map [deps [i].Key].children.Add (map [deps [i].Value]);
			}
			return g;
		}

		public static void RunTests()
		{
			List<char> projects = new List<char> () { 'a', 'b', 'c', 'd', 'e', 'f' };
			List<KeyValuePair<char, char>> deps = new List<KeyValuePair<char, char>> ();
			AddDep(deps, 'd', 'a');
			AddDep(deps, 'b', 'f');
			AddDep(deps, 'd', 'b');
			AddDep(deps, 'a', 'f');
			AddDep(deps, 'c', 'd');
			Print (GetBuildOrder (projects, deps));

			deps = new List<KeyValuePair<char, char>> ();
			AddDep(deps, 'd', 'a');
			AddDep(deps, 'a', 'f');
			AddDep(deps, 'f', 'd');
			Print (GetBuildOrder (projects, deps));

			Print (GetBuildOrder (projects, null));
			Print (GetBuildOrder (projects, new List<KeyValuePair<char, char>>()));
		}

		private static void AddDep(List<KeyValuePair<char, char>> deps, char a, char b)
		{
			deps.Add (new KeyValuePair<char, char> (a, b));
		}

		private static void Print(List<char> l)
		{
			if (l == null) {
				Console.WriteLine ("null");
				return;
			}
			foreach (var c in l) {
				Console.Write(c + " ");
			}
			Console.WriteLine ();
		}
	}
}

