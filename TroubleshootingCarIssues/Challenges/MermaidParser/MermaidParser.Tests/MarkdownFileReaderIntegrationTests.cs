using System;
using System.IO;
using System.Linq;
using Xunit;
// ReSharper disable ConvertToLocalFunction

namespace MermaidParser.Tests;

public class MarkdownFileReaderIntegrationTests
{
    [Theory]
    [InlineData("Simple.md", 4)]
    [InlineData("OriginalExerciseFlowchart.md", 17)]
    public void GetFlowchartDefinition_WithValidFileAndFilePath_ShouldReturnCorrectNumberOfLines(string filename, int numLines)
    {
        var mdFileReader = new MarkdownFileReader();

        var lines = mdFileReader.GetFlowchartDefinitionFromFile(Path.Combine("Charts", filename));

        Assert.Equal(numLines, lines.Count());
    }

    [Fact]
    public void GetFlowchartDefinition_WithInvalidFilePath_ShouldThrowFileNotFoundException()
    {
        var mdFileReader = new MarkdownFileReader();

        var parseFileAction = () => mdFileReader.GetFlowchartDefinitionFromFile("NOT A VALID FILE NAME.txt");
        
        Assert.Throws<FileNotFoundException>(parseFileAction);
    }

    [Fact]
    public void GetFlowchartDefinition_WithInvalidChartType_ShouldThrowException()
    {
        var mdFileReader = new MarkdownFileReader();

        var parseFileAction = () => mdFileReader.GetFlowchartDefinitionFromFile("IncorrectChartType.md");

        Assert.ThrowsAny<Exception>(parseFileAction);
    }

    [Fact]
    public void GetFlowchartDefinition_WithEmptyAndWhitespaceOnlyLines_ShouldNotReturnThoseLines()
    {
        var mdFileReader = new MarkdownFileReader();

        var lines = mdFileReader.GetFlowchartDefinitionFromFile(Path.Combine("Charts", "EmptyAndWhitespaceLines.md"));

        Assert.Equal(4, lines.Count());
    }

    [Fact]
    public void GetFlowchartDefinition_WithEmptyAndWhitespaceLines_ShouldTrimWhitespaceFromLines()
    {
        var mdFileReader = new MarkdownFileReader();

        var lines = mdFileReader.GetFlowchartDefinitionFromFile(Path.Combine("Charts", "EmptyAndWhitespaceLines.md"));

        Assert.StartsWith("Root", lines[0], StringComparison.InvariantCulture);
        Assert.EndsWith("ChildA", lines[0], StringComparison.InvariantCulture);
        Assert.StartsWith("ChildA", lines[2], StringComparison.InvariantCulture);
        Assert.EndsWith("indeed]", lines[2], StringComparison.InvariantCulture);
        Assert.EndsWith("way]", lines[3], StringComparison.InvariantCulture);
    }
}