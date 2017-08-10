using Xunit;
using FsCheck.Xunit;
using FsCheck;
using System;
using System.Linq;

public class DiamondTest
{
    public static readonly char[] AllLetters = GetLetterRange('A', 'Z');
    private static string[] Rows(string x) => x.Split(new[] { '\n' }, StringSplitOptions.None);

    private static string LeadingSpaces(string x) => x.Substring(0, x.IndexOfAny(AllLetters));
    private static string TrailingSpaces(string x) => x.Substring(x.LastIndexOfAny(AllLetters) + 1);
    private static char[] GetLetterRange(char min, char max) => Enumerable.Range(min, max - min + 1).Select(i => (char)i).ToArray();

    [DiamondProperty]
    public void Diamond_is_not_empty(char letter)
    {
        var actual = Diamond.Make(letter);

        Assert.NotEmpty(actual);
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void First_row_contains_a(char letter)
    {
        var actual = Diamond.Make(letter);
        var rows = Rows(actual);
        var firstRowCharacters = rows.First().Trim();

        Assert.Equal("A", firstRowCharacters);
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void All_rows_must_have_symmetric_contour(char letter)
    {
        var actual = Diamond.Make(letter);
        var rows = Rows(actual);

        Assert.All(rows, row =>
        {
            Assert.Equal(LeadingSpaces(row), TrailingSpaces(row));
        });
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void Top_of_figure_has_letters_in_correct_order(char letter)
    {
        var actual = Diamond.Make(letter);
        var rows = Rows(actual);

        var expected = GetLetterRange('A', letter);
        var firstNonSpaceLetters = rows.Take(expected.Length).Select(row => row.Trim()[0]);

        Assert.Equal(firstNonSpaceLetters, expected);
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void Figure_is_symmetric_around_the_horizontal_axis(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual);
        var top = rows.TakeWhile(row => !row.Contains(letter));
        var bottom = rows.Reverse().TakeWhile(row => !row.Contains(letter));

        Assert.Equal(bottom, top);
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void Diamond_has_square_shape(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual);
        var expected = rows.Length;

        Assert.All(rows, row =>
        {
            Assert.Equal(expected, row.Length);
        });
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void All_rows_except_top_and_bottom_have_two_identical_letters(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual).Where(row => !row.Contains('A'));

        Assert.All(rows, row =>
        {
            var twoCharacters = row.Replace(" ", "").Length == 2;
            var identicalCharacters = row.Replace(" ", "").Distinct().Count() == 1;
            Assert.True(twoCharacters && identicalCharacters, "Does not have two identical letters");
        });
    }

    [DiamondProperty(Skip = "Remove to run test")]
    public void Bottom_left_corner_spaces_are_triangle(char letter)
    {
        var actual = Diamond.Make(letter);

        var rows = Rows(actual);

        var cornerSpaces = rows.Reverse().SkipWhile(row => !row.Contains(letter)).Select(LeadingSpaces);
        var spaceCounts = cornerSpaces.Select(row => row.Length).ToList();
        var expected = Enumerable.Range(0, spaceCounts.Count).Select(i => i).ToList();

        Assert.Equal(expected, spaceCounts);
    }
}

public class DiamondPropertyAttribute : PropertyAttribute
{
    public DiamondPropertyAttribute()
    {
        Arbitrary = new[] { typeof(LettersOnlyStringArbitrary) };
    }
}

public static class LettersOnlyStringArbitrary
{
    public static Arbitrary<char> Chars()
    {
        return Arb.Default.Char().Filter(x => x >= 'A' && x <= 'Z');
    }
}