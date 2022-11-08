``` ini

BenchmarkDotNet=v0.13.2, OS=macOS 13.0 (22A380) [Darwin 22.1.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.109
  [Host]     : .NET 6.0.9 (6.0.922.47701), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 6.0.9 (6.0.922.47701), Arm64 RyuJIT AdvSIMD


```
|             Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------- |----------:|---------:|---------:|-------:|----------:|
|    ResponseIfChain | 115.01 ns | 1.060 ns | 0.940 ns | 0.1301 |     272 B |
| ResponseWithSwitch |  58.42 ns | 0.240 ns | 0.188 ns | 0.0343 |      72 B |
|  ResponseWithArray |  55.94 ns | 0.306 ns | 0.286 ns | 0.0344 |      72 B |
|      ResponseRegex | 313.08 ns | 4.214 ns | 3.942 ns |      - |         - |
