|             Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------- |----------:|---------:|---------:|-------:|----------:|
|    ResponseIfChain | 124.07 ns | 1.306 ns | 1.158 ns | 0.0577 |     272 B |
| ResponseWithSwitch |  51.65 ns | 0.377 ns | 0.315 ns | 0.0153 |      72 B |
|  ResponseWithArray |  51.07 ns | 0.262 ns | 0.245 ns | 0.0153 |      72 B |
