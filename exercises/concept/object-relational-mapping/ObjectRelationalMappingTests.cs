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

