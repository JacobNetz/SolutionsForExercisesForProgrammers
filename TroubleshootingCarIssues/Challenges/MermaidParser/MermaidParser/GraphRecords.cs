namespace MermaidParser;

public record Graph(Node Root);

public record Node(
    string Id,
    string Text,
    string ParentEdgeText,
    IList<Node> Nodes)
{
    // Text needs to be mutable so that an already defined node can have its Text updated
    // if there are future lines that change it's configuration
    public string Text { get; set; } = Text;
    public bool IsTerminalNode => !Nodes.Any();
}