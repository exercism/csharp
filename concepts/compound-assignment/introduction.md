# Introduction

Many operators can also be used as compound assignments, which are a shorthand notation where `x = op y` can be written as `x op= y`:

```csharp
var features = PhoneFeatures.Call;
features |= PhoneFeatures.Text;
features &= ~PhoneFeatures.Call;
```
