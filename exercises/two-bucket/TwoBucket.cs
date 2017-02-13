using System;

public enum Bucket
{
    One,
    Two
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucketContents { get; set; }
}

public class TwoBuckets
{
    public TwoBuckets(int bucketOneSize, int bucketTwoSize, Bucket startBucket)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public TwoBucketResult Solve(int goal)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
