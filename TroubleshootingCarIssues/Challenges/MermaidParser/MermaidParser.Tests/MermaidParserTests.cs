using Xunit;

namespace MermaidParser.Tests;
public class MermaidParserTests
{
    [Fact]
    public void Parse_WithSimple3NodeBinaryTree_ShouldReturnCorrectModel()
    {
        var mermaidDefinition = @"
        ```mermaid
        flowchart TD;
            Root-->ChildA
            Root-->ChildB
        ```";
        var parser = new MermaidParser(new MarkdownMermaidReader().GetFlowchartDefinition(mermaidDefinition));

        var graph = parser.Parse();

        Assert.Equal("Root", graph.Root.Name);
        Assert.Equal(2, graph.Root.Nodes.Count);
        Assert.Equal("ChildA", graph.Root.Nodes[0].Name);
        Assert.Equal("ChildB", graph.Root.Nodes[1].Name);
    }
}