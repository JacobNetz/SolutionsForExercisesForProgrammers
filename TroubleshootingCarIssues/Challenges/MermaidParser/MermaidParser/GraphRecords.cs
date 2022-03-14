namespace MermaidParser;

public readonly record struct Graph(Node Root);

public readonly record struct Node(
    string Name,
    string Text,
    string ParentEdgeText,
    IList<Node> Nodes);