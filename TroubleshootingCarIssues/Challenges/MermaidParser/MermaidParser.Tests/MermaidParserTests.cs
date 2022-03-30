﻿using Xunit;

namespace MermaidParser.Tests;
public class MermaidParserTests
{
    /// <summary>
    /// Creates markdown reader, gets flowchart definition, then calls Parse
    /// </summary>
    /// <param name="mermaidDefinition"></param>
    /// <returns>Graph representation of mermaid definition</returns>
    private Graph ParseTestHelper(string mermaidDefinition)
    {
        var completeDefinition = $"```mermaid\nflowchart TD;\n{mermaidDefinition}\n```";
        var parser = new MermaidParser(new MarkdownMermaidReader().GetFlowchartDefinition(completeDefinition));
        return parser.Parse();
    }

    [Fact]
    public void Parse_WithSpaceBetweenNodeAndEdge_ShouldIgnoreThatWhitespace()
    {
        var graph = ParseTestHelper("Root --> ChildA\nRoot   -->  ChildB");

        Assert.Equal("Root", graph.Root.Id);
        Assert.Equal(2, graph.Root.Nodes.Count);
        Assert.Equal("ChildA", graph.Root.Nodes[0].Id);
        Assert.Equal("ChildB", graph.Root.Nodes[1].Id);
    }

    [Fact]
    public void Parse_WithSimple3NodeBinaryTree_ShouldReturnCorrectGraph()
    {
        var graph = ParseTestHelper("Root-->ChildA\nRoot-->ChildB");

        Assert.Equal("Root", graph.Root.Id);
        Assert.Equal(2, graph.Root.Nodes.Count);
        Assert.Equal("ChildA", graph.Root.Nodes[0].Id);
        Assert.Equal("ChildB", graph.Root.Nodes[1].Id);
    }

    [Theory]
    [InlineData("text with four words")]
    [InlineData("single")]
    [InlineData("two words")]
    [InlineData("RaNDom cap TEST")]
    public void Parse_WithOneNodeWithText_ShouldCaptureNodeTextAndId(string nodeText)
    {
        var graph = ParseTestHelper($"Root[{nodeText}]-->ChildA");

        Assert.Equal(nodeText, graph.Root.Text);
        Assert.Equal("Root", graph.Root.Id);
    }

    [Theory]
    [InlineData("SingleA", "SingleB")]
    [InlineData("two wordsA", "two wordsB")]
    [InlineData("RaNDom cap TEST A", "RaNDom cap TEST B")]
    public void Parse_WithTwoNodesWithText_ShouldCaptureNodeTextAndIdForBothNodes(string childAText, string childBText)
    {
        var graph = ParseTestHelper($"Root-->ChildA[{childAText}]\nRoot-->ChildB[{childBText}]");

        Assert.Equal(2, graph.Root.Nodes.Count);
        Assert.Equal("ChildA", graph.Root.Nodes[0].Id);
        Assert.Equal(childAText, graph.Root.Nodes[0].Text);
        Assert.Equal("ChildB", graph.Root.Nodes[1].Id);
        Assert.Equal(childBText, graph.Root.Nodes[1].Text);
    }

    [Theory]
    [InlineData("SrcText", "DestText")]
    [InlineData("Src Text", "Dest Text")]
    [InlineData("RaNDom cap TEST A", "RaNDom cap TEST B")]
    public void Parse_WithTextOnSourceAndDestination_ShouldCaptureBothTexts(string sourceText, string destinationText)
    {
        var graph = ParseTestHelper($"Source[{sourceText}]-->Destination[{destinationText}]");

        Assert.Equal(sourceText, graph.Root.Text);
        Assert.Equal(destinationText, graph.Root.Nodes[0].Text);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("Yes")]
    [InlineData("Two Words")]
    [InlineData("Lots of Words as the Edge Text")]
    [InlineData("Num8ers With 34345 Letters 45.5")]
    [InlineData("873")]
    [InlineData("873 54 234 56")]
    public void Parse_WithLeftEdgeText_ShouldCaptureEdgeText(string edgeText)
    {
        var graph = ParseTestHelper($"Source-->|{edgeText}|Destination");

        Assert.Equal(edgeText, graph.Root.Nodes[0].ParentEdgeText);
    }

    [Theory]
    [InlineData("A", "B")]
    [InlineData("Two words", "Other Words")]
    [InlineData("3.14", "123.45")]
    [InlineData("One", "Two Words")]
    public void Parse_WithTwoEdgesWithText_ShouldCaptureEdgeTexts(string leftEdgeText, string rightEdgeText)
    {
        var graph = ParseTestHelper($"Root-->|{leftEdgeText}|ChildA\nRoot-->|{rightEdgeText}|ChildB");

        Assert.Equal(leftEdgeText, graph.Root.Nodes[0].ParentEdgeText);
        Assert.Equal(rightEdgeText, graph.Root.Nodes[1].ParentEdgeText);
    }
}