C#, like many statically typed languages, provides a number of types that represent integers, each with its own range of values. At the low end, the `sbyte` type has a minimum value of -128 and a maximum value of 127. Like all the integer types these values are available as `<type>.MinValue` and `<type>.MaxValue`. At the high end, the `long` type has a minimum value of -9,223,372,036,854,775,808 and a maximum value of 9,223,372,036,854,775,807. In between lie the `short` and `int` types.

The ranges are determined by the storage width of the type as allocated by the system. For example, a `byte` uses 8 bits and a `long` uses 64 bits.

Each of the above types is paired with an unsigned equivalent: `sbyte`/`byte`, `short`/`ushort`, `int`/`uint` and `long`/`ulong`. In all cases the range of the values is from 0 to the negative signed maximum times 2 plus 1.

| Type   | Width  | Minimum                    | Maximum                     |
| ------ | ------ | -------------------------- | --------------------------- |
| sbyte  | 8 bit  | -128                       | +127                        |
| short  | 16 bit | -32_768                    | +32_767                     |
| int    | 32 bit | -2_147_483_648             | +2_147_483_647              |
| long   | 64 bit | -9_223_372_036_854_775_808 | +9_223_372_036_854_775_807  |
| byte   | 8 bit  | 0                          | +255                        |
| ushort | 16 bit | 0                          | +65_535                     |
| uint   | 32 bit | 0                          | +4_294_967_295              |
| ulong  | 64 bit | 0                          | +18_446_744_073_709_551_615 |

A variable (or expression) of one type can easily be converted to another. For instance, in an assignment operation, if the type of the value being assigned (lhs) ensures that the value will lie within the range of the type being assigned to (rhs) then there is a simple assignment:

```csharp
uint ui = uint.MaxValue;
ulong ul = ui;    // no problem
```

On the other hand if the range of type being assigned from is not a subset of the assignee's range of values then a cast, `()` operation is required even if the particular value is within the assignee's range:

```csharp
short s = 42;
uint ui = (uint)s;
```

#### Bit conversion

The `BitConverter` class provides a convenient way of converting integer types to and from arrays of bytes.
