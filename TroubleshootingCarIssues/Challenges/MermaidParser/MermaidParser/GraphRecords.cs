namespace MermaidParser;

public readonly record struct Graph(Node Root);

public readonly record struct Node(
    string Id,
    string Text,
    string ParentEdgeText,
    IList<Node> Nodes)
{
    public bool IsTerminalNode => !Nodes.Any();
}