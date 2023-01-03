|                  Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------------ |----------:|---------:|---------:|-------:|----------:|
|   ProteinsSubstringDict | 128.69 ns | 0.517 ns | 0.432 ns | 0.0560 |     264 B |
| ProteinsSubstringSwitch |  91.59 ns | 1.426 ns | 1.264 ns | 0.0560 |     264 B |
|        ProteinsLinqDict | 453.59 ns | 1.114 ns | 1.042 ns | 0.1254 |     592 B |
|       ProteinsYieldDict | 313.60 ns | 1.537 ns | 1.284 ns | 0.0901 |     424 B |
|     ProteinsYieldSwitch | 270.33 ns | 2.731 ns | 2.554 ns | 0.0901 |     424 B |
