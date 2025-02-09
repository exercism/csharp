using Xunit;

public class KillerSudokuHelperTests
{
    [Fact]
    public void Trivial_1_digit_cages_1()
    {
        int[][] expected = [[1]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(1, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_2()
    {
        int[][] expected = [[2]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(2, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_3()
    {
        int[][] expected = [[3]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(3, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_4()
    {
        int[][] expected = [[4]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(4, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_5()
    {
        int[][] expected = [[5]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(5, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_6()
    {
        int[][] expected = [[6]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(6, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_7()
    {
        int[][] expected = [[7]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(7, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_8()
    {
        int[][] expected = [[8]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(8, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Trivial_1_digit_cages_9()
    {
        int[][] expected = [[9]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(9, 1, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cage_with_sum_45_contains_all_digits_1_9()
    {
        int[][] expected = [[1, 2, 3, 4, 5, 6, 7, 8, 9]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(45, 9, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cage_with_only_1_possible_combination()
    {
        int[][] expected = [[1, 2, 4]];
        Assert.Equal(expected, KillerSudokuHelper.Combinations(7, 3, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cage_with_several_combinations()
    {
        int[][] expected = [
            [1, 9],
            [2, 8],
            [3, 7],
            [4, 6]
        ]; Assert.Equal(expected, KillerSudokuHelper.Combinations(10, 2, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cage_with_several_combinations_that_is_restricted()
    {
        int[][] expected = [
            [2, 8],
            [3, 7]
        ]; Assert.Equal(expected, KillerSudokuHelper.Combinations(10, 2, [1, 4]));
    }
}
