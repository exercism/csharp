# Instructions

Work continues on the remote control car project. Bandwidth in the telemetry system is at a premium and you have been asked to implement a message protocol for communicating telemetry data.

Data is transmitted in a buffer (byte array). When integers are sent, the size of the buffer is reduced by employing the protocol described below.

Each value should be represented in the smallest possible integral type (types of `byte` and `sbyte` are not included as the saving would be trivial):

| From                       | To                        | Type     |
| -------------------------- | ------------------------- | -------- |
| 4_294_967_296              | 9_223_372_036_854_775_807 | `long`   |
| 2_147_483_648              | 4_294_967_295             | `uint`   |
| 65_536                     | 2_147_483_647             | `int`    |
| 32_768                     | 65_535                    | `ushort` |
| -32_768                    | 32_767                    | `short`  |
| -2_147_483_648             | -32_769                   | `int`    |
| -9_223_372_036_854_775_808 | -2_147_483_649            | `long`   |

The value should be converted to the appropriate number of bytes for its assigned type. The complete buffer comprises a byte indicating the number of additional bytes in the buffer (_prefix byte_) followed by the bytes holding the integer (_payload bytes_).

Some of the types use an identical number of bytes (e.g. the `uint` and `int` types). Normally, they would have the same _prefix byte_, but that would make decoding problematic. To counter this, the protocol introduces a little trick: for signed types, their _prefix byte_ value is `256` minus the number of additional bytes in the buffer.

Only the prefix byte and the number of following bytes indicated by the prefix will be sent in the communication. Internally a 9 byte buffer is used (with trailing zeroes, as necessary) both by sending and receiving routines.

## 1. Encode an integral value ready to send

Please implement the static method `TelemetryBuffer.ToBuffer()` to encode a buffer taking the parameter passed to the method.

```csharp
// Type: ushort, bytes: 2, signed: no, prefix byte: 2
TelemetryBuffer.ToBuffer(5)
// => {0x2, 0x5, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

// Type: int, bytes: 4, signed: yes, prefix byte: 256 - 4
TelemetryBuffer.ToBuffer(Int32.MaxValue)
// => {0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0 };
```

## 2. Decode a received buffer

Please implement the static method `TelemetryBuffer.FromBuffer()` to decode the buffer received and return the value in the form of a `long`.

```csharp
TelemetryBuffer.FromBuffer(new byte[] {0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0 })
// => 2147483647
```

If the prefix byte is not one of `-8`, `-4`, `-2`, `2` or `4` then `0` should be returned.
