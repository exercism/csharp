using System;
using Xunit;
using Exercism.Tests;

public class OrmInOneGoTests
{
    enum Exception
    {
        InvalidOperationExceptionThrown,
        NoInvalidOperationExceptionThrown
    }
    [Fact]
    [Task(1)]
    public void Write_good()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Write("good write");
        Assert.Equal((Database.State.Closed, "good write"),
            (Database.DbState, Database.lastData));
    }

    [Fact]
    [Task(1)]
    public void Write_bad()
    {
        Exception result = Exception.NoInvalidOperationExceptionThrown;
        try
        {
            var db = new Database();
            var orm = new Orm(db);
            orm.Write("bad write");
        }
        catch (InvalidOperationException)
        {
            result = Exception.InvalidOperationExceptionThrown;
        }
        Assert.Equal((Exception.InvalidOperationExceptionThrown, Database.State.Closed, "bad write"),
            (result, Database.DbState, Database.lastData));
    }

    [Fact]
    [Task(1)]
    public void Commit_bad()
    {
        Exception result = Exception.NoInvalidOperationExceptionThrown;
        try
        {
            var db = new Database();
            var orm = new Orm(db);
            orm.Write("bad commit");
        }
        catch (InvalidOperationException)
        {
            result = Exception.InvalidOperationExceptionThrown;
        }
        Assert.Equal((Exception.InvalidOperationExceptionThrown, Database.State.Closed, "bad commit"),
            (result, Database.DbState, Database.lastData));
    }

    [Fact]
    [Task(2)]
    public void CommitSafely_good()
    {
        var db = new Database();
        var orm = new Orm(db);
        Assert.True(orm.WriteSafely("good write"));
    }

    [Fact]
    [Task(2)]
    public void CommitSafely_bad_write()
    {
        var db = new Database();
        var orm = new Orm(db);
        Assert.False(orm.WriteSafely("bad write"));
    }

    [Fact]
    [Task(2)]
    public void CommitSafely_bad_commit()
    {
        var db = new Database();
        var orm = new Orm(db);
        Assert.False(orm.WriteSafely("bad commit"));
    }
}

// **** please do not modify the Database class ****
public class Database : IDisposable
{
    public enum State { TransactionStarted, DataWritten, Invalid, Closed }

    public static State DbState { get; private set; } = State.Closed;
    public static string lastData = string.Empty;

    public void BeginTransaction()
    {
        if (DbState != State.Closed)
        {
            throw new InvalidOperationException();
        }
        DbState = State.TransactionStarted;
    }

    public void Write(string data)
    {
        if (DbState != State.TransactionStarted)
        {
            throw new InvalidOperationException();
        }
        // this does something significant with the db transaction object
        lastData = data;
        if (data == "bad write")
        {
            DbState = State.Invalid;
            throw new InvalidOperationException();
        }

        DbState = State.DataWritten;
    }

    public void EndTransaction()
    {
        if (DbState != State.DataWritten && DbState != State.TransactionStarted)
        {
            throw new InvalidOperationException();
        }
        // this does something significant to end the db transaction object
        if (lastData == "bad commit")
        {
            DbState = State.Invalid;
            throw new InvalidOperationException();
        }

        DbState = State.Closed;
    }

    public void Dispose()
    {
        DbState = State.Closed;
    }
}

