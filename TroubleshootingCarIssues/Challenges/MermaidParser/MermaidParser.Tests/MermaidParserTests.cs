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
            Root[Yes or no?]-->|Yes|ChildA
            Root-->|No|ChildB
            ChildA[Yes indeed]
            ChildB[No way]
        ```";
        var parser = new MermaidParser(new MarkdownMermaidReader().GetFlowchartDefinition(mermaidDefinition));

        parser.Parse();

        Assert.True(false);
    }
}