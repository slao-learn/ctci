using System;
using System.Collections.Generic;

namespace ctci
{
	public class Graph<T>
	{
		public List<GraphNode<T>> nodes;
	}

	public class GraphNode<T>
	{
		public T data;
		public bool visited = false;
		public List<GraphNode<T>> children;

		public GraphNode(T data, List<GraphNode<T>> children)
		{
			this.data = data;
			if (children != null)
				this.children = children;
			else
				this.children = new List<GraphNode<T>> ();
		}

		public GraphNode(T data) : this(data, null)
		{
		}

		public static GraphNode<T> Create(T data)
		{
			return new GraphNode<T> (data);
		}

		public static GraphNode<T> Create(T data, List<GraphNode<T>> children)
		{
			return new GraphNode<T> (data, children);
		}

		public static GraphNode<T> Create(T data, GraphNode<T> child)
		{
			return new GraphNode<T> (data, new List<GraphNode<T>>() { child });
		}

	}
}

