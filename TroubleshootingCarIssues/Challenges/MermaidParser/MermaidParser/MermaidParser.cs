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
            // Whitespace/newlines added to make Regex expression easier to read - it can be removed with no effect
            var sourceToDestinationRegex = new Regex(@"
            (?<source>     \w+) (\[(?<sourceText>     .+)\])?
            \s*-->\s*(\|(?<edgeText>.+)\|)?
            (?<destination>\w+) (\[(?<destinationText>.+)\])?",
                RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);
            var match = sourceToDestinationRegex.Match(line);
            if(match.Success)
            {
                var destination = new Node(
                    Id: match.Groups["destination"].Value,
                    Text: match.Groups["destinationText"].Value,
                    ParentEdgeText: match.Groups["edgeText"].Value,
                    Nodes: new List<Node>());
                nodes.Add(destination);
                var existingNode = nodes.FirstOrDefault(node => node.Id == match.Groups["source"].Value);
                if (existingNode != default)
                    existingNode.Nodes.Add(destination);
                else
                    nodes.Add(new Node(
                        Id: match.Groups["source"].Value,
                        Text: match.Groups["sourceText"].Value,
                        ParentEdgeText: match.Groups["edgeText"].Value,
                        Nodes: new List<Node> { destination }));
            }
            else
            {
                var singleNodeRegex = new Regex(@"(?<node>\w+)(\[(?<nodeText>.+)\])",
                    RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);
                var nodeMatch = singleNodeRegex.Match(line);
                if (!nodeMatch.Success) continue;

                var existingNode = nodes.FirstOrDefault(node => node.Id == nodeMatch.Groups["node"].Value);
                if (existingNode != default)
                    existingNode.Text = nodeMatch.Groups["nodeText"].Value;
                else
                    nodes.Add(new Node(
                        Id: nodeMatch.Groups["node"].Value,
                        Text: nodeMatch.Groups["nodeText"].Value,
                        ParentEdgeText: string.Empty,
                        Nodes: new List<Node>()));
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