using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        try
        {
            database.BeginTransaction();
        }
        catch (Exception e)
        {
            database.Dispose();
        }
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (Exception e)
        {
            database.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (Exception e)
        {
            database.Dispose();
        }
    }

    public void Dispose()
    {
        if (database != null)
        {
            database.Dispose();
        }
    }
}
