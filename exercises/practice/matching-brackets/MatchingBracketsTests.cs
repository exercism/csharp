using Xunit;

public class MatchingBracketsTests
{
    [Fact]
    public void Paired_square_brackets()
    {
        var value = "[]";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_string()
    {
        var value = "";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unpaired_brackets()
    {
        var value = "[[";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wrong_ordered_brackets()
    {
        var value = "}{";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wrong_closing_bracket()
    {
        var value = "{]";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_with_whitespace()
    {
        var value = "{ }";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Partially_paired_brackets()
    {
        var value = "{[])";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Simple_nested_brackets()
    {
        var value = "{[]}";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Several_paired_brackets()
    {
        var value = "{}[]";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_nested_brackets()
    {
        var value = "([{}({}[])])";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unopened_closing_brackets()
    {
        var value = "{[)][]}";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unpaired_and_nested_brackets()
    {
        var value = "([{])";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_wrong_nested_brackets()
    {
        var value = "[({]})";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_wrong_nested_brackets_but_innermost_are_correct()
    {
        var value = "[({}])";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_incomplete_brackets()
    {
        var value = "{}[";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Too_many_closing_brackets()
    {
        var value = "[]]";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Early_unexpected_brackets()
    {
        var value = ")()";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Early_mismatched_brackets()
    {
        var value = "{)()";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Math_expression()
    {
        var value = "(((185 + 223.85) * 15) - 543)/2";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Complex_latex_expression()
    {
        var value = "\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)";
        Assert.True(MatchingBrackets.IsPaired(value));
    }
}