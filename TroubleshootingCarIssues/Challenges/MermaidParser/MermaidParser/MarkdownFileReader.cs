namespace MermaidParser;

public class MarkdownFileReader
{
    public IList<string> GetFlowchartDefinition(string filePath)
    {
        // Consume lines until it finds the start of the mermaid chart
        using var reader = new StreamReader(filePath);
        while (!reader.ReadLine()?.Contains("```mermaid", StringComparison.InvariantCultureIgnoreCase) ?? true) { }
        var nextLine = reader.ReadLine()?.Trim();
        if (nextLine == null || !nextLine.Contains("flowchart", StringComparison.InvariantCultureIgnoreCase))
            throw new Exception($"Could not find 'flowchart' declaration in file '{filePath}'");
        
        // Consume and save chart definition lines until it reaches the end of the chart 
        var lines = new List<string>();
        while (!reader.EndOfStream)
        {
            var currentLine = reader.ReadLine()?.Trim();
            if(currentLine?.StartsWith("```") ?? false)
                break;
            if(currentLine != null && !string.IsNullOrWhiteSpace(currentLine))
                lines.Add(currentLine);
        }

        return lines;
    }
}
