public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        throw new NotImplementedException($"Please implement the Orm.Begin() method");
    }

    public void Write(string data)
    {
        throw new NotImplementedException($"Please implement the Orm.Write() method");
    }

    public void Commit()
    {
        throw new NotImplementedException($"Please implement the Orm.Commit() method");
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
