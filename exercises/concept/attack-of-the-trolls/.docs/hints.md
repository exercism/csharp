# Hints

## 1. Get default permissions for an account type

- Define the `Permission` enum with values for the following permission types: `None`, `Read`, `Write` and `Delete`.
- Using the enum flags would allow to use bitwise operations out of the box for the `Permission` enum, [see `enum` `Flags`][docs-enum-flags].
- The `All` enum member can be defined as a combination of the `Read`, `Write` and `Delete` enum members.
- Define the `AccountType` enum with values for the following account types: `Guest`, `User` and `Moderator`.
- To handle each account type, one could use an `if` statement, but the [`switch` statement][docs.microsoft.com-switch-keyword] is a great alternative.
- Combining flags means setting a specific bit to `1` using one of the [bitwise operators][docs.microsoft.com-bitwise-and-shift-operators].

## 2. Grant a permission

- Combining flags means setting a specific bit to `1` using one of the [bitwise operators][docs.microsoft.com-bitwise-and-shift-operators].

## 3. Revoke a permission

- Removing a flag means setting a specific bit to `0` using a combination of two [bitwise operators][docs.microsoft.com-bitwise-and-shift-operators].

## 4. Check for a permission

- Checking a permission can be done by checking the result of applying one of the [bitwise operators][docs.microsoft.com-bitwise-and-shift-operators].

[docs.microsoft.com-bitwise-and-shift-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators
[docs.microsoft.com-switch-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
[docs-enum-flags]: https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-6.0
