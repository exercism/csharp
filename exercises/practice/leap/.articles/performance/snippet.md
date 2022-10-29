|            Method | testYear |      Mean |     Error |    StdDev | Allocated |
|------------------ |--------- |----------:|----------:|----------:|----------:|
| IsLeapYearTernary |     1900 | 0.8741 ns | 0.0071 ns | 0.0063 ns |         - |
| IsLeapYearTernary |     2000 | 0.8842 ns | 0.0073 ns | 0.0065 ns |         - |
| IsLeapYearTernary |     2019 | 0.9048 ns | 0.0503 ns | 0.1215 ns |         - |
|   IsLeapYearChain |     2020 | 1.0490 ns | 0.0154 ns | 0.0137 ns |         - |
| IsLeapYearTernary |     2020 | 1.1003 ns | 0.0230 ns | 0.0216 ns |         - |
|  IsLeapYearSwitch |     2020 | 2.7031 ns | 0.0821 ns | 0.1229 ns |         - |
