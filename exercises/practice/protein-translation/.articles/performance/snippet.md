|                  Method |     Mean |   Error |  StdDev |   Gen0 | Allocated |
|------------------------ |---------:|--------:|--------:|-------:|----------:|
|    ProteinsSubstringMap | 133.5 ns | 0.53 ns | 0.44 ns | 0.0560 |     264 B |
| ProteinsSubstringSwitch | 109.6 ns | 0.25 ns | 0.21 ns | 0.0560 |     264 B |
|         ProteinsLinqMap | 528.8 ns | 1.62 ns | 1.27 ns | 0.1373 |     648 B |
|        ProteinsYieldMap | 316.2 ns | 1.14 ns | 0.89 ns | 0.0896 |     424 B |
|     ProteinsYieldSwitch | 283.0 ns | 1.37 ns | 1.22 ns | 0.1035 |     488 B |
