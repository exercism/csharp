using System;
using System.Collections.Generic;
using System.Linq;

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
    private int[] sizes;
    private int startBucket;
    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        this.sizes = new[] {bucketOne, bucketTwo};
        this.startBucket = (int)startBucket;
    }

    private int[] Empty(int[] _buckets, int i) =>
            i == 0 ? new[] {0, _buckets[1]} : new[] {_buckets[0], 0};

    private int[] Fill(int[] _buckets, int i) =>
            i == 0 ? new[] {sizes[0], _buckets[1]} : new[] {_buckets[0], sizes[1]};

    private int[] Consolidate(int[] _buckets, int i)
    {
        var amount = new[]{_buckets[1 - i], sizes[i] - _buckets[i]}.Min();
        var target = _buckets[i] + amount;
        var src = _buckets[1 - i] - amount;
        return i == 0 ? new[] {target, src} : new[] {src, target};
    }

    public TwoBucketResult Measure(int goal)
    {
        var invalid = new[]{0,0};
        invalid[1 - startBucket] = sizes[1 - startBucket];
        var invalidStr = string.Join(",",invalid);
        var buckets = new[]{0,0};
        buckets[startBucket] = sizes[startBucket];
        var toVisit = new Queue<(int[], int)>();
        var visited = new HashSet<string>();
        var count = 1;
        var goalBucket = Array.IndexOf(buckets, goal);
        while (goalBucket < 0)
        {
            var key = string.Join(",",buckets);
            if (!visited.Contains(key) && !key.Equals(invalidStr))
            {
                visited.Add(key);
                var nc = count + 1;
                for (int i=0;i<2;i++)
                {
                    if (buckets[i] != 0)
                        toVisit.Enqueue((Empty(buckets, i), nc));
                    if (buckets[i] != sizes[i])
                    {
                        toVisit.Enqueue((Fill(buckets, i), nc));
                        toVisit.Enqueue((Consolidate(buckets, i), nc));
                    }
                }
            }
            if (!toVisit.Any())
                throw new ArgumentException("no more moves!");
            (buckets, count) = toVisit.Dequeue();
            goalBucket = Array.IndexOf(buckets, goal);
        }
        return new TwoBucketResult
        {
            Moves = count,
            GoalBucket = (Bucket)goalBucket,
            OtherBucket = buckets[1 - goalBucket]
        };
    }
}
