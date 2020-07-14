The country of Hyperia has its problems. In particular, inflation is out of control. You have been flown in to take up a contract at the central bank.

## 1. Print bank note denominations

To simplify administration internally the central bank has split each denomination into parts, a _base_ that remains relatively unchanged, and a _multiplier_ (the same for all denominations) which can be changed yearly or weekly or even daily.

When printed the denominations on bank notes are the product of _base_ and _multiplier_.

By the time this system was introduced the minimum bank note already had a denomination of 10,000,000. The table below shows the position (for the first 3 denominations) when the system was first introduced. Things have got much worse since then and not only does the multiplier change so does the base.

| Base    | Multiplier | Denomination |
| ------- | ---------- | ------------ |
| 10,000  | 1,000      | 10,000,000   |
| 50,000  | 1,000      | 50,000,000   |
| 100,000 | 1,000      | 100,000,000  |
| ...     | 1,000      | ...          |

In summary, this means that _denomination_ = _base_ \* _multiplier_.

Please implement the method `CentralBank.DisplayDenomination()` which takes the base and multiplier and returns a string of their product (base \* multiplier). The numeric string returned should not be formatted.

If the multiplication operation causes an overflow then the string, `"*** Too Big ***"`, should be returned.

```csharp
CentralBank.DisplayDenomination(10000L, 1000L);
// => "10000000"
CentralBank.DisplayDenomination(long.MaxValue / 2, 10000L);
// => "*** Too Big ***"
```

## 2. Display GDP for Hyperia

The central bank uses the same multiplier approach to recording GDP internally. Statistics are recorded in a base denomination and then scaled up using the multiplier.

Please implement the method `CentralBank.DisplayGDP()` which takes the base GDP and the current multiplier and returns the GDP as a string.

If the GDP cannot be calculated then `"*** Too Big ***"` is returned.

```csharp
CentralBank.DisplayGDP(555f, 10000f);
// => "555000000"
CentralBank.DisplayGDP(float.MaxValue / 2, 10000f);
// => "*** Too Big ***"
```

## 3. Display Chief Economist's salary

Your boss at the bank wants to make sure there will be no problems at payroll time.

Implement the `CentralBank.DisplayChiefEconomistSalary()` method that takes a salary expressed in base units (as above) and a multiplier and returns a string containing the product.

If the salary cannot be calculated then `"*** Much Too Big ***"` is returned.

```csharp
CentralBank.DisplayChiefEconomistSalary(555000m, 10000m);
// => "5550000000"
CentralBank.DisplayChiefEconomistSalary(555000m, decimal.MaxValue / 2L);
// => "*** Much Too Big ***"
```
