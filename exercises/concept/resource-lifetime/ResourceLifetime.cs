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
        throw new NotImplementedException($"Please implement the Orm.Write() method");
    }

    public bool WriteSafely(string data)
    {
        throw new NotImplementedException($"Please implement the Orm.WriteSafely() method");
    }
}
