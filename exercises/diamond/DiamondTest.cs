using System;
using System.Linq;
using NUnit.Framework;

public class DiamondTest
{
    private static readonly char[] Letters = GetLetterRange('A', 'Z');
    private static char[] GetLetterRange(char min, char max) => Enumerable.Range(min, max - min + 1).Select(i => (char) i).ToArray();
    private static string[] Rows(string x) => x.Split(new[] { '\n' }, StringSplitOptions.None);

    private static string LeadingSpaces(string x) => x.Substring(0, x.IndexOfAny(Letters));
    private static string TrailingSpaces(string x) => x.Substring(x.LastIndexOfAny(Letters) + 1);

    [TestCaseSource(nameof(Letters))]
    public void First_row_contains_A(char letter)
    {
        var actual = Diamond.Make(letter);
        var rows = Rows(actual);
        var firstRowCharacters = rows.First().Trim();

        Assert.That(firstRowCharacters, Is.EqualTo("A"));
    }

    [Ignore("Remove to run test")]
    [TestCaseSource(nameof(Letters))]
    public void All_rows_must_have_symmetric_contour(char letter)
    {
        var actual = Diamond.Make(letter);
        var rows = Rows(actual);

        Assert.That(rows, Is.All.Matches<string>(row => LeadingSpaces(row) == TrailingSpaces(row)));
    }

    [Ignore("Remove to run test")]
    [TestCaseSource(nameof(Letters))]
    public void Top_of_figure_has_letters_in_correct_order(char letter)
    {
        var actual = Diamond.Make(letter);
        var rows = Rows(actual);

        var expected = GetLetterRange('A', letter);
        var firstNonSpaceLetters = rows.Take(expected.Length).Select(row => row.Trim()[0]);
        Assert.That(expected, Is.EqualTo(firstNonSpaceLetters));
    }

    [Ignore("Remove to run test")]
    [TestCaseSource(nameof(Letters))]
    public void Figure_is_symmetric_around_the_horizontal_axis(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual);
        var top = rows.TakeWhile(row => !row.Contains(letter));
        var bottom = rows.Reverse().TakeWhile(row => !row.Contains(letter));

        Assert.That(top, Is.EqualTo(bottom));
    }

    [Ignore("Remove to run test")]
    [TestCaseSource(nameof(Letters))]
    public void Diamond_has_square_shape(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual);
        var expected = rows.Length;

        Assert.That(rows, Is.All.Matches<string>(row => row.Length == expected));
    }

    [Ignore("Remove to run test")]
    [TestCaseSource(nameof(Letters))]
    public void All_rows_except_top_and_bottom_have_two_identical_letters(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual).Where(row => !row.Contains('A'));

        Assert.That(rows, Is.All.Matches<string>(row =>
        {
            var twoCharacters = row.Replace(" ", "").Length == 2;
            var identicalCharacters = row.Replace(" ", "").Distinct().Count() == 1;
            return twoCharacters && identicalCharacters;
        }));
    }

    [Ignore("Remove to run test")]
    [TestCaseSource(nameof(Letters))]
    public void Bottom_left_corner_spaces_are_triangle(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual);

        var cornerSpaces = rows.Reverse().SkipWhile(row => !row.Contains(letter)).Select(LeadingSpaces);
        var spaceCounts = cornerSpaces.Select(row => row.Length).ToList();
        var expected = Enumerable.Range(0, spaceCounts.Count).Select(i => i).ToList();

        Assert.That(spaceCounts, Is.EqualTo(expected));
    }
}