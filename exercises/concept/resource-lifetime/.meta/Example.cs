using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using (database)
        {
            database.Write(data);
            database.EndTransaction();
        }
    }

    public bool WriteSafely(string data)
    {
        using var db = database;
        try
        {
            db.Write(data);
            db.EndTransaction();

            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}
