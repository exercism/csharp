In this exercise you'll be working with savings accounts. Each year, the balance of each savings account is updated based on the [annual percentage yield][wikipedia-annual_percentage_yield] (APY). The APY value depends on the amount of money in the account (its balance):

- -3.213% for a negative balance.
- 0.5% for a positive balance less than `1000`.
- 1.621% for a positive balance greater or equal than `1000` and less than `5000`.
- 2.475% for a positive balance greater or equal than `5000`.

You have three tasks, each of which will deal with balances and their APYs.

### 1. Calculate the annual percentage yield

Implement a method to calculate the APY based on the specified balance:

```csharp
FloatingPointNumbers.AnnualPercentageYield(balance: 200.75m)
// 0.5f
```

Note that the value returned is a `float`.

### 2. Calculate the annual balance update

Implement a method to calculate the annual balance update, taking into account the APY:

```csharp
FloatingPointNumbers.AnnualBalanceUpdate(balance: 200.75m)
// 201.75375m
```

Note that the value returned is a `decimal`.

### 3. Calculate the years before reaching the desired balance

Implement a method to calculate the minimum number of years required to reach the desired balance:

```csharp
FloatingPointNumbers.YearsBeforeDesiredBalance(balance: 200.75m, targetBalance: 214.88m)
// 14
```

Note that the value returned is an `int`.

[wikipedia-annual_percentage_yield]: https://en.wikipedia.org/wiki/Annual_percentage_yield
