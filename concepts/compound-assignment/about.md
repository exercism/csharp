TODO: I think we need a different exercise to introduce compound assignments (one that shows it being used in a more conventional numeric or string context. flag-enums could then take that as a dependency and show how it is used in this more unusual context.
The bitwise operators can also be used as [compound assignments][compound-assignment], which are a shorthand notation where `x = op y` can be written as `x op= y`:

```csharp
var features = PhoneFeatures.Call;
features |= PhoneFeatures.Text;
features &= ~PhoneFeatures.Call;
```

[compound-assignment]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#compound-assignment
