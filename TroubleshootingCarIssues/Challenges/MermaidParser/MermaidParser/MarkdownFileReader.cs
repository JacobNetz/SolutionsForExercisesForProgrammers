namespace MermaidParser;

public class MarkdownFileReader
{
    public IList<string> GetFlowchartDefinitionFromFile(string filePath)
    {
        using var reader = new StreamReader(filePath);
        return GetFlowchartDefinition(reader);
    }

    public IList<string> GetFlowchartDefinition(string mermaidChartDefinition)
    {
        using var reader = new StringReader(mermaidChartDefinition);
        return GetFlowchartDefinition(reader);
    }

    private IList<string> GetFlowchartDefinition(TextReader reader)
    {
        // Consume lines until it finds the start of the mermaid chart
        while (!reader.ReadLine()?.Contains("```mermaid", StringComparison.InvariantCultureIgnoreCase) ?? true) { }
        var nextLine = reader.ReadLine()?.Trim();
        if (nextLine == null || !nextLine.Contains("flowchart", StringComparison.InvariantCultureIgnoreCase))
            throw new Exception("Could not find 'flowchart' declaration");

        // Consume and save chart definition lines until it reaches the end of the chart 
        var lines = new List<string>();
        while (reader.Peek() != -1)
        {
            var currentLine = reader.ReadLine()?.Trim();
            if (currentLine?.StartsWith("```") ?? false)
                break;
            if (currentLine != null && !string.IsNullOrWhiteSpace(currentLine))
                lines.Add(currentLine);
        }

        return lines;
    }
}
