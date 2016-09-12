using NUnit.Framework;

public class BracketPushTest
{
    [Test]
    public void Paired_square_brackets()
    {
        const string actual = "[]";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Empty_string()
    {
        const string actual = "";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unpaired_brackets()
    {
        const string actual = "[[";
        Assert.That(BracketPush.Matched(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Wrong_ordered_brackets()
    {
        const string actual = "}{";
        Assert.That(BracketPush.Matched(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Paired_with_whitespace()
    {
        const string actual = "{ }";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Simple_nested_brackets()
    {
        const string actual = "{[]}";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Several_paired_brackets()
    {
        const string actual = "{}[]";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Paired_and_nested_brackets()
    {
        const string actual = "([{}({}[])])";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unpaired_and_nested_brackets()
    {
        const string actual = "([{])";
        Assert.That(BracketPush.Matched(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Paired_and_wrong_nested_brackets()
    {
        const string actual = "[({]})";
        Assert.That(BracketPush.Matched(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Math_expression()
    {
        const string actual = "(((185 + 223.85) * 15) - 543)/2";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Complex_latex_expression()
    {
        const string actual = "\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)";
        Assert.That(BracketPush.Matched(actual), Is.True);
    }
}