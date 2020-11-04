## 1. Get default permissions for an account type

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
