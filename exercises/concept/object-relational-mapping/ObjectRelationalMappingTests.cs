using System;

using Xunit;
using Exercism.Tests;

public class ObjectRelationalMappingTests
{
    [Fact]
    [Task(2)]
    public void Write_good()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Begin();
        orm.Write("good write");
        object[] actual = { db.DbState, db.lastData };
        Assert.Equal(new object[] { Database.State.DataWritten, "good write" }, actual);
    }

    [Fact]
    [Task(2)]
    public void Write_bad()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Begin();
        orm.Write("bad write");
        object[] actual = { db.DbState, db.lastData };
        Assert.Equal(new object[] { Database.State.Closed, "bad write" }, actual);
    }

    [Fact]
    [Task(3)]
    public void Commit_good()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Begin();
        orm.Write("good commit");
        orm.Commit();
        object[] actual = { db.DbState, db.lastData };
        Assert.Equal(new object[] { Database.State.Closed, "good commit" }, actual);
    }

    [Fact]
    [Task(3)]
    public void Commit_bad()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Begin();
        orm.Write("bad commit");
        orm.Commit();
        object[] actual = { db.DbState, db.lastData };
        Assert.Equal(new object[] { Database.State.Closed, "bad commit" }, actual);
    }

    [Fact]
    [Task(3)]
    public void Out_of_order()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Write("bad commit");
        orm.Commit();
        object[] actual = { db.DbState, db.lastData };
        Assert.Equal(new object[] { Database.State.Closed, string.Empty }, actual);
    }

    [Fact]
    [Task(4)]
    public void Disposable()
    {
        var db = new Database();
        var orm = new Orm(db);
        orm.Begin();
        orm.Write("good data");
        var disposable = Assert.IsAssignableFrom<IDisposable>(orm);
        disposable.Dispose();
        object[] actual = { db.DbState, db.lastData };
        Assert.Equal(new object[] { Database.State.Closed, "good data" }, actual);
    }
}

// **** please do not modify the Database class ****
public class Database : IDisposable
{
    public enum State { TransactionStarted, DataWritten, Invalid, Closed }

    public State DbState { get; private set; } = State.Closed;
    public string lastData = string.Empty;

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
