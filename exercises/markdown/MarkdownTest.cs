﻿using Xunit;

public class MarkdownTest
{
    [Fact]
    public void Parses_normal_text_as_a_paragraph()
    {
        var input = "This will be a paragraph";
        var expected = "<p>This will be a paragraph</p>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void Parsing_italics()
    {
        var input = "_This will be italic_";
        var expected = "<p><em>This will be italic</em></p>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void Parsing_bold_text()
    {
        var input = "__This will be bold__";
        var expected = "<p><strong>This will be bold</strong></p>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void Mixed_normal_italics_and_bold_text()
    {
        var input = "This will _be_ __mixed__";
        var expected = "<p>This will <em>be</em> <strong>mixed</strong></p>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void With_h1_header_level()
    {
        var input = "# This will be an h1";
        var expected = "<h1>This will be an h1</h1>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void With_h2_header_level()
    {
        var input = "## This will be an h2";
        var expected = "<h2>This will be an h2</h2>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void With_h6_header_level()
    {
        var input = "###### This will be an h6";
        var expected = "<h6>This will be an h6</h6>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void Unordered_lists()
    {
        var input = "* Item 1\n* Item 2";
        var expected = "<ul><li>Item 1</li><li>Item 2</li></ul>";
        Assert.Equal(expected, Markdown.Parse(input));
    }

    [Fact]
    public void With_a_little_bit_of_everything()
    {
        var input = "# Header!\n* __Bold Item__\n* _Italic Item_";
        var expected = "<h1>Header!</h1><ul><li><strong>Bold Item</strong></li><li><em>Italic Item</em></li></ul>";
        Assert.Equal(expected, Markdown.Parse(input));
    }
}