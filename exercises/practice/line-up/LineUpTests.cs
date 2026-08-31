public class LineUpTests
{
    [Fact]
    public void Format_smallest_non_exceptional_ordinal_numeral_4()
    {
        string expected = "Gianna, you are the 4th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Gianna", 4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_greatest_single_digit_non_exceptional_ordinal_numeral_9()
    {
        string expected = "Maarten, you are the 9th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Maarten", 9));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_5()
    {
        string expected = "Petronila, you are the 5th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Petronila", 5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_6()
    {
        string expected = "Attakullakulla, you are the 6th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Attakullakulla", 6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_7()
    {
        string expected = "Kate, you are the 7th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Kate", 7));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_8()
    {
        string expected = "Maximiliano, you are the 8th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Maximiliano", 8));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_1()
    {
        string expected = "Mary, you are the 1st customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Mary", 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_2()
    {
        string expected = "Haruto, you are the 2nd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Haruto", 2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_3()
    {
        string expected = "Henriette, you are the 3rd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Henriette", 3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_smallest_two_digit_non_exceptional_ordinal_numeral_10()
    {
        string expected = "Alvarez, you are the 10th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Alvarez", 10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_11()
    {
        string expected = "Jacqueline, you are the 11th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Jacqueline", 11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_12()
    {
        string expected = "Juan, you are the 12th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Juan", 12));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_13()
    {
        string expected = "Patricia, you are the 13th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Patricia", 13));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_21()
    {
        string expected = "Washi, you are the 21st customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Washi", 21));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_22_ending_in_nd_even_though_it_is_a_multiple_of_11()
    {
        string expected = "Ingrid, you are the 22nd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Ingrid", 22));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_33_ending_in_rd_even_though_it_is_a_multiple_of_11()
    {
        string expected = "Mario, you are the 33rd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Mario", 33));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_52_ending_in_nd_even_though_it_is_a_multiple_of_13()
    {
        string expected = "Quentin, you are the 52nd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Quentin", 52));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_62()
    {
        string expected = "Nayra, you are the 62nd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Nayra", 62));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_72_ending_in_nd_even_though_it_is_a_multiple_of_12()
    {
        string expected = "Ugo, you are the 72nd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Ugo", 72));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_91_ending_in_st_even_though_it_is_a_multiple_of_13()
    {
        string expected = "Boris, you are the 91st customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Boris", 91));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_100()
    {
        string expected = "John, you are the 100th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("John", 100));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_101()
    {
        string expected = "Zeinab, you are the 101st customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Zeinab", 101));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_non_exceptional_ordinal_numeral_112()
    {
        string expected = "Knud, you are the 112th customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Knud", 112));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_exceptional_ordinal_numeral_123()
    {
        string expected = "Yma, you are the 123rd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Yma", 123));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Format_large_number_972_ending_in_nd_even_though_it_is_a_multiple_of_12()
    {
        string expected = "Elias, you are the 972nd customer we serve today. Thank you!";
        Assert.Equal(expected, LineUp.Format("Elias", 972));
    }
}
