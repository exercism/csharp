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

public class BucketContainer
{
    public BucketContainer(int contents, int capacity)
    {
        Contents = contents;
        Capacity = capacity;
    }

    public int Contents { get; set; }

    public int Capacity { get; }

    public bool IsEmpty => Contents == 0;

    public bool IsFull => Contents == Capacity;

    public void Fill()
    {
        Contents = Capacity;
    }

    public void Empty()
    {
        Contents = 0;
    }

    public void PourTo(BucketContainer other)
    {
        var amount = Math.Min(other.Capacity - other.Contents, Contents);
        Contents -= amount;
        other.Contents += amount;
    }

    public bool CanPourTo(BucketContainer other) => !IsEmpty && !other.IsFull;
}

public class TwoBucket
{
    private readonly BucketContainer bucketOne;
    private readonly BucketContainer bucketTwo;
    private readonly Action strategy;

    public TwoBucket(int bucketOneSize, int bucketTwoSize, Bucket startBucket)
    {
        bucketOne = new BucketContainer(startBucket == Bucket.One ? bucketOneSize : 0, bucketOneSize);
        bucketTwo = new BucketContainer(startBucket == Bucket.Two ? bucketTwoSize : 0, bucketTwoSize);
        strategy = startBucket == Bucket.One ? (Action)StartFromFirstBucket : StartFromSecondBucket;

    }

    public TwoBucketResult Measure(int goal)
    {
        var moves = 0;

        while (true)
        {
            moves++;

            if (bucketOne.Contents == goal)
                return new TwoBucketResult { Moves = moves, GoalBucket = Bucket.One, OtherBucketContents = bucketTwo.Contents };

            if (bucketTwo.Contents == goal)
                return new TwoBucketResult { Moves = moves, GoalBucket = Bucket.Two, OtherBucketContents = bucketOne.Contents };

            strategy();
        }

        throw new NotImplementedException();
    }

    public void StartFromFirstBucket()
    {
        if (bucketOne.IsEmpty)
            bucketOne.Fill();
        else if (bucketTwo.IsFull)
            bucketTwo.Empty();
        else if (bucketOne.CanPourTo(bucketTwo))
            bucketOne.PourTo(bucketTwo);
        else
            throw new InvalidOperationException("Cannot transition from current state.");
    }

    public void StartFromSecondBucket()
    {
        if (bucketOne.IsFull)
            bucketOne.Empty();
        else if (bucketTwo.IsEmpty)
            bucketTwo.Fill();
        else if (bucketTwo.CanPourTo(bucketOne))
            bucketTwo.PourTo(bucketOne);
        else
            throw new InvalidOperationException("Cannot transition from current state.");
    }
}
