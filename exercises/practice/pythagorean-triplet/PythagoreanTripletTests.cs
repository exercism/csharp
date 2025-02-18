public class PythagoreanTripletTests
{
    [Fact]
    public void Triplets_whose_sum_is_12()
    {
        (int, int, int)[] expected = [
            (3, 4, 5)
        ];
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(12));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Triplets_whose_sum_is_108()
    {
        (int, int, int)[] expected = [
            (27, 36, 45)
        ];
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(108));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Triplets_whose_sum_is_1000()
    {
        (int, int, int)[] expected = [
            (200, 375, 425)
        ];
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(1000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_matching_triplets_for_1001()
    {
        Assert.Empty(PythagoreanTriplet.TripletsWithSum(1001));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Returns_all_matching_triplets()
    {
        (int, int, int)[] expected = [
            (9, 40, 41),
            (15, 36, 39)
        ];
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(90));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Several_matching_triplets()
    {
        (int, int, int)[] expected = [
            (40, 399, 401),
            (56, 390, 394),
            (105, 360, 375),
            (120, 350, 370),
            (140, 336, 364),
            (168, 315, 357),
            (210, 280, 350),
            (240, 252, 348)
        ];
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(840));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Triplets_for_large_number()
    {
        (int, int, int)[] expected = [
            (1200, 14375, 14425),
            (1875, 14000, 14125),
            (5000, 12000, 13000),
            (6000, 11250, 12750),
            (7500, 10000, 12500)
        ];
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(30000));
    }
}
