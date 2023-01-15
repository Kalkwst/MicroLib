namespace Graph;

/// <summary>
/// Indicates a vertex pair.
/// </summary>
/// <typeparam name="TVertex">The Graph vertices type</typeparam>
public class VertexPair<TVertex>
{
    /// <summary>
    /// The head vertex.
    /// </summary>
    public TVertex Head { get; }

    /// <summary>
    /// The tail vertex.
    /// </summary>
    public TVertex Tail { get; }

    public VertexPair(TVertex head, TVertex tail)
    {
        Head = head ?? throw new ArgumentNullException(nameof(head), "Cannot create a Vertex with null head");
        Tail = tail ?? throw new ArgumentNullException(nameof(tail), "Cannot create a Vertex with null tail");
    }

    public override bool Equals(object? obj)
    {
        if (this == obj)
            return true;
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (VertexPair<TVertex>)obj;
        return (Head!.Equals(other.Head) && Tail!.Equals(other.Tail));
    }

    public override int GetHashCode()
    {
        return 31 + (Head!.GetHashCode() + Tail!.GetHashCode());
    }

    public override string ToString()
    {
        return $"[head={Head}, tail={Tail}]";
    }
}