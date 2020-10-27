You are implementing an ORM (Object Relational Mapping) system over a database which has been provided by another team.

The database is capable of handling a single transaction at one time.

No logging or other error handling is required at this stage.

Note that, internally, the database transitions through a number of state: Closed, TransactionStarted, DataWritten, Invalid, Closed. You can rely on the fact that the database is in a `Closed` state at the start of each exercise.

The database has the following instance methods:

- `Database.BeginTransaction()` starts a transaction on the database. If this is called when the database is not in a `Closed` state then an exception is thrown. If successful the internal state of the database will change to `TransactionStarted`.
- `Database.Write(string data)` writes data to the database within the transaction. If it receives bad data an exception will be thrown. An attempt to call this method without `BeginTransaction()` having been called will cause an exception to be thrown. If successful the internal state of the database will change to `DataWritten`.
- `Database.Commit()` commits the transaction to the database. It may throw an exception if it can't close the transaction of if `Database.BeginTransaction()` had not been called.
- A call to`Database.Dispose()` will clean up the database if an exception is thrown during a transaction. This will change the state of the database to `Closed`.

## 1. Begin a transaction

Implement `Orm.Begin()` to start a transaction on the database. If the database does not start with an internal state of `State.Closed` then it throws an `InvalidOperationException`.

```csharp
var orm = new Orm(new Database());
orm.Begin();
// => database has an internal state of State.TransactionStarted
```

## 2. Write some data to the database

Implement `Orm.Write()` to write some data to the database. If the database does not start with an internal state of `State.TransactionStarted` or bad data is written then an `InvalidOperationException` is thrown. If the write fails then the `Orm` must clean up the database.

```csharp
var orm = new Orm(new Database());
orm.Begin();
orm.Write("some data");
// => database has an internal state of State.DataWritten
orm.Write("bad write");
// => database has an internal state of State.Closed
```

## 3. Commit previously written data to the database

Implement `Orm.Commit()` to commit the data. If the commit fails then clean up the database. If the database does not start with an internal state of `State.DataWritten` then an `InvalidOperationException` is thrown.

```csharp
var orm = new Orm(new Database());
orm.Begin();
orm.Write("some data");
orm.Commit();
// => database has an internal state of State.Closed
orm.Begin();
orm.Write("bad commit");
orm.Commit();
// => database has an internal state of State.Closed
```

## 4. Ensure that the database is cleaned up correctly if the ORM has to close part way through a transaction.

Implement the `IDisposable` interface on the `Orm` class. The call is guaranteed to succeed.

```csharp
var db = new Database();
var orm = new Orm(db);
orm.Begin();
orm.Write("some data");
orm.Dispose();
// => database has an internal state of State.Closed
```
