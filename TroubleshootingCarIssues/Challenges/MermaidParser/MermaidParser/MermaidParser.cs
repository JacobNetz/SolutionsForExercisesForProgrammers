namespace MermaidParser;

/// <summary>
/// Parses simple Mermaid formatted flow charts
/// 
/// NOTE: This version of the Mermaid parser only works for simple binary trees with a single root node
/// </summary>
public class MermaidParser
{
    private readonly IList<string> _lines;

    public MermaidParser(IList<string> lines) => _lines = lines;

    public void Parse()
    {
        foreach (var line in _lines)
        {
            
        }
    }
}