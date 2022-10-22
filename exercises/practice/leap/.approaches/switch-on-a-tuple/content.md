```csharp
    public static bool IsLeapYear(int year) {
        switch ((year % 4, year % 100, year % 400))
        {
            case (_, 0, 0):
                return true;
            case (_, 0, _):
                return false;
            case (0, _, _):
                return true;
            default:
                return false;
        }
    }
```
