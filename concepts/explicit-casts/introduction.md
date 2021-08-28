# Introduction

Where types cannot be cast implicitly, you must use an explicit cast operator.
The cast operator is nothing more than the target type in parentheses before the value you want to cast:

```csharp

int i = 7;
byte b = (byte)i; // Explicit cast from int to byte
```
