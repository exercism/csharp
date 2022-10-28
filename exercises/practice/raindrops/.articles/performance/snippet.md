|               Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|--------------------- |----------:|---------:|---------:|-------:|----------:|
|  ConvertWithIfConcat |  24.78 ns | 0.154 ns | 0.144 ns | 0.0221 |     104 B |
| ConvertWithIfBuilder |  36.93 ns | 0.292 ns | 0.244 ns | 0.0340 |     160 B |
|     ConvertAggConcat | 129.85 ns | 1.430 ns | 1.194 ns | 0.0713 |     336 B | 
|    ConvertAggBuilder | 130.75 ns | 1.209 ns | 1.072 ns | 0.0832 |     392 B | 
|      ConvertAggArray |  85.58 ns | 0.467 ns | 0.414 ns | 0.0577 |     272 B |
|     ConvertAggSepAry |  76.42 ns | 0.200 ns | 0.167 ns | 0.0424 |     200 B |
