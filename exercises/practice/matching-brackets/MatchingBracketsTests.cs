public class MatchingBracketsTests
{
    [Fact]
    public void Paired_square_brackets()
    {
        Assert.True(MatchingBrackets.IsPaired("[]"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_string()
    {
        Assert.True(MatchingBrackets.IsPaired(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unpaired_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("[["));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wrong_ordered_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("}{"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wrong_closing_bracket()
    {
        Assert.False(MatchingBrackets.IsPaired("{]"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_with_whitespace()
    {
        Assert.True(MatchingBrackets.IsPaired("{ }"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Partially_paired_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("{[])"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Simple_nested_brackets()
    {
        Assert.True(MatchingBrackets.IsPaired("{[]}"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Several_paired_brackets()
    {
        Assert.True(MatchingBrackets.IsPaired("{}[]"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_nested_brackets()
    {
        Assert.True(MatchingBrackets.IsPaired("([{}({}[])])"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unopened_closing_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("{[)][]}"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unpaired_and_nested_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("([{])"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_wrong_nested_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("[({]})"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_wrong_nested_brackets_but_innermost_are_correct()
    {
        Assert.False(MatchingBrackets.IsPaired("[({}])"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Paired_and_incomplete_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("{}["));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Too_many_closing_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("[]]"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Early_unexpected_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired(")()"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Early_mismatched_brackets()
    {
        Assert.False(MatchingBrackets.IsPaired("{)()"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Math_expression()
    {
        Assert.True(MatchingBrackets.IsPaired("(((185 + 223.85) * 15) - 543)/2"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Complex_latex_expression()
    {
        Assert.True(MatchingBrackets.IsPaired("\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)"));
    }
}
