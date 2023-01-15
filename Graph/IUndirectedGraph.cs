namespace Graph;

/// <summary>
/// An undirected graph is a graph in which edges have no orientation.
/// </summary>
/// <typeparam name="TVertex">The vertices type.</typeparam>
/// <typeparam name="TEdge">The edges type.</typeparam>
public interface IUndirectedGraph<TVertex, TEdge> : IGraph<TVertex, TEdge>
{
}