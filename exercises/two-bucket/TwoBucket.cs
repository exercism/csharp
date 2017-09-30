using System;

public enum Bucket
{
    One,
    Two
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket Goal_bucket { get; set; }
    public int Other_bucket { get; set; }
}

public class TwoBucket
{
    public TwoBucket(int bucket_one, int bucket_two, Bucket start_bucket)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public TwoBucketResult Measure(int goal)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
