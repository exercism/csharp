# About

Many operators can also be used as [compound assignments][compound-assignment], which are a shorthand notation where `x = op y` can be written as `x op= y`:

```csharp
var features = PhoneFeatures.Call;
features |= PhoneFeatures.Text;
features &= ~PhoneFeatures.Call;
```

[compound-assignment]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#compound-assignment
[compound-assignment-alt]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#compound-assignment
