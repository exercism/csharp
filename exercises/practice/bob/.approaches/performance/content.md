|             Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------- |----------:|---------:|---------:|-------:|----------:|
|    ResponseIfChain | 124.07 ns | 1.306 ns | 1.158 ns | 0.0577 |     272 B |
| ResponseWithSwitch |  51.65 ns | 0.377 ns | 0.315 ns | 0.0153 |      72 B |
|  ResponseWithArray |  51.07 ns | 0.262 ns | 0.245 ns | 0.0153 |      72 B |

For the purpose of benchmarking the `string` extension methods for the [`if` statements approach][approach-if] were refactored to regular methods that take a `string`.
For all approaches, all other `static` functions were refactored to instance functions.
The `if statements` approach was over two times slower than the other two approaches.
Given that the [`switch` approach][approach-switch] and [answer array approach][approach-answer-array] were equivalent for performance,
the `switch` approach might be prefered for performance as considered the more idiomatic approach for C#.

[approach-if]: https://exercism.org/tracks/csharp/exercises/bob/approaches/if
[approach-switch]: https://exercism.org/tracks/csharp/exercises/bob/approaches/switch-on-tuple
[approach-answer-array]: https://exercism.org/tracks/csharp/exercises/bob/approaches/answer-array
