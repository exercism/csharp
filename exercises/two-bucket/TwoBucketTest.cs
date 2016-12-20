﻿using NUnit.Framework;

public class TwoBucketTest
{
    [Test]
    public void First_example()
    {
        var bucketOneSize = 3;
        var bucketTwoSize = 5;
        var goal = 1;
        var startBucket = Bucket.One;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.That(actual.Moves, Is.EqualTo(4));
        Assert.That(actual.GoalBucket, Is.EqualTo(Bucket.One));
        Assert.That(actual.OtherBucketContents, Is.EqualTo(5));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Second_example()
    {
        var bucketOneSize = 3;
        var bucketTwoSize = 5;
        var goal = 1;
        var startBucket = Bucket.Two;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.That(actual.Moves, Is.EqualTo(8));
        Assert.That(actual.GoalBucket, Is.EqualTo(Bucket.Two));
        Assert.That(actual.OtherBucketContents, Is.EqualTo(3));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Third_example()
    {
        var bucketOneSize = 7;
        var bucketTwoSize = 11;
        var goal = 2;
        var startBucket = Bucket.One;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.That(actual.Moves, Is.EqualTo(14));
        Assert.That(actual.GoalBucket, Is.EqualTo(Bucket.One));
        Assert.That(actual.OtherBucketContents, Is.EqualTo(11));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Fourth_example()
    {
        var bucketOneSize = 7;
        var bucketTwoSize = 11;
        var goal = 2;
        var startBucket = Bucket.Two;
        var twoBuckets = new TwoBuckets(bucketOneSize, bucketTwoSize, startBucket);

        var actual = twoBuckets.Solve(goal);

        Assert.That(actual.Moves, Is.EqualTo(18));
        Assert.That(actual.GoalBucket, Is.EqualTo(Bucket.Two));
        Assert.That(actual.OtherBucketContents, Is.EqualTo(7));
    }
}