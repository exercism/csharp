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
    public int OtherBucket { get; set; }
}

public class TwoBucket
{
    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public TwoBucketResult Measure(int goal)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
