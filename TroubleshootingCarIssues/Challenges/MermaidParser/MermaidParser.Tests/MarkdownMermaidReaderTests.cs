using System;
using Xunit;
// ReSharper disable ConvertToLocalFunction

namespace MermaidParser.Tests;

public class MarkdownMermaidReaderTests
{
    [Fact]
    public void GetFlowchartDefinition_BlankDefinition_ShouldThrowException()
    {
        var mdFileReader = new MarkdownMermaidReader();
        var mermaidDefinition = @"
        ";

        var parseStringAction = () => mdFileReader.GetFlowchartDefinition(mermaidDefinition);

        Assert.ThrowsAny<Exception>(parseStringAction);
    }

    [Fact]
    public void GetFlowchartDefinition_WithValidDefinition_ShouldReturnCorrectNumberOfLines()
    {
        var mdFileReader = new MarkdownMermaidReader();
        var mermaidDefinition = @"
        # Troubleshooting flow chart
        ```mermaid
        flowchart TD;
            Root[Yes or no?]-->|Yes|ChildA
            Root-->|No|ChildB
            ChildA[Yes indeed]
            ChildB[No way]
        ```
        ";

        var lines = mdFileReader.GetFlowchartDefinition(mermaidDefinition);

        Assert.Equal(4, lines.Count);
    }
}