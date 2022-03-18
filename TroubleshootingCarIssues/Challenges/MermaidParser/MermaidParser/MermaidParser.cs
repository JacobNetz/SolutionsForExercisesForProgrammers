using System.Text.RegularExpressions;

namespace MermaidParser;

/// <summary>
/// Parses simple Mermaid formatted flow charts
/// </summary>
/// <remarks>
/// NOTE: This version of the Mermaid parser only works for simple binary trees with a single root node
/// and uses regular expressions (Regex) to do the actual parsing.
/// 
/// See https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
/// </remarks>
public class MermaidParser
{
    private readonly IList<string> _lines;

    public MermaidParser(IList<string> lines) => _lines = lines;

    public Graph Parse()
    {
        var nodes = new List<Node>();
        foreach (var line in _lines)
        {
            var regex = new Regex(@"(?<source>\w+)\[?(?<sourceText>[\w\s]+)*\]?\s*-->\s*(?<destination>\w+)", 
                RegexOptions.Singleline | RegexOptions.ExplicitCapture);
            var match = regex.Match(line);
            if(match.Success)
            {
                var destination = new Node(
                    Id: match.Groups["destination"].Value,
                    Text: string.Empty,
                    ParentEdgeText: string.Empty,
                    Nodes: new List<Node>());
                nodes.Add(destination);
                var existingNode = nodes.FirstOrDefault(node => node.Id == match.Groups["source"].Value);
                if (existingNode != default)
                    existingNode.Nodes.Add(destination);
                else
                    nodes.Add(new Node(
                        Id: match.Groups["source"].Value,
                        Text: match.Groups["sourceText"].Value,
                        ParentEdgeText: string.Empty,
                        Nodes: new List<Node> { destination }));
            }
        }
        
        var rootNode = nodes.FirstOrDefault(outerNode => 
            !nodes.Any(innerNode => 
                innerNode.Nodes.Any(innerChildNode => 
                    innerChildNode.Id == outerNode.Id)));
        var graph = new Graph(rootNode);
        return graph;
    }
}