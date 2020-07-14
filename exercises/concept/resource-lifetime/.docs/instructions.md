You are back working on the ORM (Object Relationship Mapping) system introduced in (TODO cross-reference-tba).

Our ORM usage analysis shows that 95% of transactions are executed from within one calling method, and it has been decided that it would be more appropriate to have a single ORM method that opened, wrote and committed a transaction.

The database has the following instance methods:

- `Database.BeginTransaction()` starts a transaction on the database.
- `Database.Write(string data)` writes data to the database within the transaction. If it receives bad data an exception will be thrown. An attempt to call this method without `BeginTransction()` having been called will cause an exception to be thrown. If successful the internal state of the database will change to `DataWritten`.
- `Database.Commit()` commits the transaction to the database. It may throw an exception if it can't close the transaction or if `Database.BeginTransaction()` had not been called.
- A call to`Databse.Dispose()` will clean up the database if an exception is thrown during a transaction. This will change the state of the database to `Closed`.

## 1. Write to the database

Implement the `Orm.Write()` method to begin a database transaction, write the data passed in and commit the transaction. All exceptions including `InvalidOperationException` should be allowed to pass to the caller without logging or any other intervention.

```csharp
Database db = new Database();
Orm orm = new Orm(db);
orm.Write("good write");
// => database has an internal state of State.Closed
orm.Write("bad write");
// => an exception is thrown but database is left with an internal state of State.Closed
orm.Write("bad commit");
// => an exception is thrown but database is left with an internal state of State.Closed
```

## 2. Write to the database and return an indication of whether the write was successful to the caller

It has been a few months since `Orm.Write()` was introduced and there is division in the team. Many developers would like the _ORM_ to handle errors when exceptions are thrown and simply return an indication of success to the caller.

Please implement the `Orm.WriteSafely()` method to begin a database transaction, write the data passed in and commit the transaction (as above). It should return `true` if the _write_ was successful, otherwise `false`. Do not attempt to log the exception.

```csharp
Database db = new Database();
Orm orm = new Orm(db);
orm.WriteSafely("good write");
// => true
orm.WriteSafely("bad write");
// => false
orm.WriteSafely("bad commit");
// => false
```
