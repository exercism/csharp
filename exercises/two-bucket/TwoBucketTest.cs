using Xunit;

public class TwoBucketTest
{
    [Fact]
    public void First_example()
    {
        var bucketOneSize = 3;
        var bucketTwoSize = 5;
        var goal = 1;
        var startBucket = Bucket.One;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.Equal(4, actual.Moves);
        Assert.Equal(Bucket.One, actual.GoalBucket);
        Assert.Equal(5, actual.OtherBucketContents);
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_example()
    {
        var bucketOneSize = 3;
        var bucketTwoSize = 5;
        var goal = 1;
        var startBucket = Bucket.Two;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.Equal(8, actual.Moves);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
        Assert.Equal(3, actual.OtherBucketContents);
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_example()
    {
        var bucketOneSize = 7;
        var bucketTwoSize = 11;
        var goal = 2;
        var startBucket = Bucket.One;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.Equal(14, actual.Moves);
        Assert.Equal(Bucket.One, actual.GoalBucket);
        Assert.Equal(11, actual.OtherBucketContents);
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_example()
    {
        var bucketOneSize = 7;
        var bucketTwoSize = 11;
        var goal = 2;
        var startBucket = Bucket.Two;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.Equal(18, actual.Moves);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
        Assert.Equal(7, actual.OtherBucketContents);
    }
}