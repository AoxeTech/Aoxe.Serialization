# Benchmark

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.100
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Job-RTTPLA : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

IterationCount=100  RunStrategy=Monitoring

## To Text

|               Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|--------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractToText |  1,294.1 ns |  10.84 ns |   9.05 ns |  1,275.3 ns |  1,304.7 ns |  1,295.5 ns | 0.5779 | 0.0019 |    4848 B |
|            JilToText |    256.2 ns |   5.00 ns |  10.98 ns |    237.2 ns |    282.2 ns |    253.6 ns | 0.1099 |      - |     920 B |
| NewtonsoftJsonToText |    696.3 ns |  13.76 ns |  26.84 ns |    663.8 ns |    762.3 ns |    690.3 ns | 0.2079 |      - |    1744 B |
|      SharpYamlToText | 45,860.2 ns | 196.38 ns | 153.32 ns | 45,503.5 ns | 46,082.3 ns | 45,897.0 ns | 3.1738 | 0.1221 |   26798 B |
| SystemTextJsonToText |    343.5 ns |   6.48 ns |   7.21 ns |    334.9 ns |    356.2 ns |    341.2 ns | 0.0305 |      - |     256 B |
|       Utf8JsonToText |    240.4 ns |   4.65 ns |   4.78 ns |    228.9 ns |    247.8 ns |    240.9 ns | 0.0324 |      - |     272 B |
|            XmlToText |  5,790.4 ns |  89.33 ns |  79.19 ns |  5,543.2 ns |  5,859.8 ns |  5,801.3 ns | 1.3962 | 0.0381 |   11729 B |
|     YamlDotNetToText | 16,213.5 ns | 183.90 ns | 163.02 ns | 15,889.5 ns | 16,453.5 ns | 16,245.4 ns | 1.5564 |      - |   13049 B |

## From Text

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractFromText |  3,472.0 ns |  69.25 ns |  76.97 ns |  3,224.9 ns |  3,589.7 ns |  3,470.5 ns | 1.5984 | 0.0496 |   13376 B |
|            JilFromText |    298.6 ns |   5.13 ns |   4.80 ns |    292.5 ns |    306.4 ns |    299.1 ns | 0.0219 |      - |     184 B |
| NewtonsoftJsonFromText |  1,501.3 ns |  29.74 ns |  26.37 ns |  1,473.0 ns |  1,557.3 ns |  1,495.5 ns | 0.3471 | 0.0019 |    2920 B |
|      SharpYamlFromText | 49,583.3 ns | 330.01 ns | 292.55 ns | 49,164.1 ns | 50,168.6 ns | 49,574.0 ns | 3.2349 | 0.1221 |   27396 B |
| SystemTextJsonFromText |    484.6 ns |   9.60 ns |  11.79 ns |    473.1 ns |    507.0 ns |    478.3 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromText |    410.9 ns |   7.58 ns |   7.09 ns |    404.2 ns |    422.0 ns |    406.9 ns | 0.0286 |      - |     240 B |
|            XmlFromText |  8,124.0 ns | 115.14 ns | 107.70 ns |  7,917.1 ns |  8,273.3 ns |  8,150.6 ns | 1.1139 | 0.0153 |    9433 B |
|     YamlDotNetFromText | 12,408.2 ns | 157.94 ns | 147.74 ns | 12,128.3 ns | 12,641.7 ns | 12,410.6 ns | 1.6937 | 0.0458 |   14176 B |

## To Bytes

|                Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|---------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryToBytes |  4,662.20 ns |  67.730 ns |  60.041 ns |  4,594.02 ns |  4,766.89 ns |  4,649.97 ns | 0.8316 | 0.0153 |    6992 B |
|   DataContractToBytes |  1,173.44 ns |  12.950 ns |  10.814 ns |  1,157.40 ns |  1,192.71 ns |  1,173.46 ns | 0.4406 | 0.0019 |    3688 B |
|            JilToBytes |    283.79 ns |   5.468 ns |   8.184 ns |    255.83 ns |    296.03 ns |    285.69 ns | 0.1278 |      - |    1072 B |
|     MemoryPackToBytes |     77.91 ns |   1.590 ns |   1.893 ns |     75.45 ns |     81.72 ns |     77.45 ns | 0.0086 |      - |      72 B |
|    MessagePackToBytes |    133.55 ns |   1.789 ns |   1.673 ns |    130.28 ns |    135.77 ns |    133.89 ns | 0.0095 |      - |      80 B |
|        MsgPackToBytes |    430.75 ns |   6.244 ns |   5.535 ns |    421.01 ns |    438.21 ns |    431.39 ns | 0.0935 |      - |     784 B |
| NewtonsoftJsonToBytes |    747.46 ns |  14.850 ns |  18.781 ns |    704.54 ns |    776.91 ns |    753.44 ns | 0.2251 |      - |    1888 B |
|       ProtobufToBytes |    329.25 ns |   6.563 ns |   7.294 ns |    317.99 ns |    341.13 ns |    327.77 ns | 0.0486 |      - |     408 B |
|      SharpYamlToBytes | 49,993.86 ns | 929.181 ns | 823.694 ns | 48,696.35 ns | 51,138.29 ns | 50,138.58 ns | 3.4180 | 0.1221 |   28888 B |
| SystemTextJsonToBytes |    300.63 ns |   4.140 ns |   3.670 ns |    295.41 ns |    305.87 ns |    300.37 ns | 0.0172 |      - |     144 B |
|       Utf8JsonToBytes |    206.36 ns |   3.988 ns |   4.748 ns |    199.02 ns |    216.47 ns |    205.99 ns | 0.0181 |      - |     152 B |
|            XmlToBytes |  6,526.26 ns | 124.815 ns | 110.645 ns |  6,215.09 ns |  6,663.27 ns |  6,543.99 ns | 1.3351 | 0.0381 |   11225 B |
|     YamlDotNetToBytes | 17,676.44 ns | 347.351 ns | 451.655 ns | 17,212.39 ns | 18,634.95 ns | 17,549.57 ns | 1.7090 |      - |   14417 B |
|  ZeroFormatterToBytes |    116.11 ns |   2.314 ns |   3.801 ns |    104.51 ns |    122.81 ns |    116.50 ns | 0.1415 | 0.0002 |    1184 B |

## From Bytes

|                  Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------ |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromBytes |  6,849.05 ns | 115.776 ns | 108.297 ns |  6,623.42 ns |  7,010.53 ns |  6,880.12 ns | 1.1749 | 0.0305 |    9856 B |
|   DataContractFromBytes |  3,508.46 ns |  68.700 ns | 122.114 ns |  3,119.87 ns |  3,712.68 ns |  3,544.28 ns | 1.5259 | 0.0458 |   12784 B |
|            JilFromBytes |    352.89 ns |   5.419 ns |   5.069 ns |    342.50 ns |    359.71 ns |    355.24 ns | 0.0553 |      - |     464 B |
|     MemoryPackFromBytes |     62.49 ns |   1.238 ns |   1.474 ns |     59.02 ns |     64.94 ns |     62.46 ns | 0.0105 |      - |      88 B |
|    MessagePackFromBytes |    211.48 ns |   4.069 ns |   4.178 ns |    205.08 ns |    218.13 ns |    212.66 ns | 0.0105 |      - |      88 B |
|        MsgPackFromBytes |    629.35 ns |  12.617 ns |  15.494 ns |    603.43 ns |    668.78 ns |    626.99 ns | 0.0925 |      - |     776 B |
| NewtonsoftJsonFromBytes |  1,663.26 ns |  30.077 ns |  26.662 ns |  1,613.21 ns |  1,718.53 ns |  1,666.99 ns | 0.3796 |      - |    3176 B |
|       ProtobufFromBytes |    394.08 ns |   6.154 ns |   5.139 ns |    384.82 ns |    403.90 ns |    395.29 ns | 0.0210 |      - |     176 B |
|      SharpYamlFromBytes | 57,463.35 ns | 743.182 ns | 658.812 ns | 56,101.75 ns | 58,591.59 ns | 57,411.36 ns | 3.6621 | 0.1831 |   31012 B |
| SystemTextJsonFromBytes |    421.12 ns |   2.222 ns |   1.735 ns |    419.08 ns |    424.72 ns |    420.49 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromBytes |    385.95 ns |   7.542 ns |   8.070 ns |    374.28 ns |    406.54 ns |    385.40 ns | 0.0105 |      - |      88 B |
|            XmlFromBytes |  8,791.23 ns |  77.727 ns |  68.903 ns |  8,668.07 ns |  8,921.98 ns |  8,782.99 ns | 1.0986 | 0.0153 |    9265 B |
|     YamlDotNetFromBytes | 12,921.71 ns | 257.931 ns | 275.983 ns | 12,311.68 ns | 13,264.80 ns | 13,026.92 ns | 1.7242 | 0.0458 |   14488 B |
|  ZeroFormatterFromBytes |     60.60 ns |   1.241 ns |   1.740 ns |     55.30 ns |     63.16 ns |     60.63 ns | 0.0334 |      - |     280 B |

## To Stream

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|         BinaryToStream |  4,712.3 ns |  82.99 ns |  69.30 ns |  4,574.6 ns |  4,844.6 ns |  4,717.5 ns | 0.7782 | 0.0076 |    6528 B |
|   DataContractToStream |  1,216.5 ns |  24.31 ns |  22.74 ns |  1,177.8 ns |  1,250.4 ns |  1,216.7 ns | 0.3700 |      - |    3096 B |
|            JilToStream |    367.8 ns |   8.71 ns |  25.26 ns |    310.5 ns |    429.2 ns |    365.1 ns | 0.1693 |      - |    1416 B |
|     MemoryPackToStream |    142.4 ns |   3.34 ns |   9.62 ns |    124.7 ns |    166.5 ns |    140.7 ns | 0.0782 |      - |     656 B |
|    MessagePackToStream |    305.1 ns |   5.54 ns |   4.91 ns |    294.5 ns |    314.0 ns |    305.7 ns | 0.0410 |      - |     344 B |
|        MsgPackToStream |    362.1 ns |   6.79 ns |  10.16 ns |    333.2 ns |    380.3 ns |    366.0 ns | 0.0858 |      - |     720 B |
| NewtonsoftJsonToStream |    801.2 ns |  14.99 ns |  19.49 ns |    741.9 ns |    834.5 ns |    803.0 ns | 0.2661 | 0.0010 |    2232 B |
|       ProtobufToStream |    307.2 ns |   5.42 ns |   7.23 ns |    297.2 ns |    325.2 ns |    303.9 ns | 0.0410 |      - |     344 B |
|      SharpYamlToStream | 51,208.9 ns | 967.47 ns | 950.18 ns | 49,738.5 ns | 52,850.5 ns | 51,320.2 ns | 3.4180 | 0.1221 |   28735 B |
| SystemTextJsonToStream |    366.4 ns |   2.53 ns |   2.11 ns |    363.3 ns |    370.6 ns |    366.2 ns | 0.0591 |      - |     496 B |
|       Utf8JsonToStream |    253.1 ns |   5.00 ns |   5.95 ns |    242.5 ns |    265.3 ns |    252.5 ns | 0.0410 |      - |     344 B |
|            XmlToStream |  6,796.8 ns | 127.69 ns | 136.62 ns |  6,422.2 ns |  6,984.1 ns |  6,784.3 ns | 1.2970 |      - |   10841 B |
|     YamlDotNetToStream | 17,734.9 ns | 354.65 ns | 331.74 ns | 17,216.4 ns | 18,396.9 ns | 17,757.9 ns | 1.7090 |      - |   14481 B |
|  ZeroFormatterToStream |    198.2 ns |   6.65 ns |  19.30 ns |    168.3 ns |    255.8 ns |    198.6 ns | 0.1826 | 0.0005 |    1528 B |

## From Stream

|                   Method |         Mean |      Error |     StdDev |       Median |          Min |          Max |   Gen0 |   Gen1 | Allocated |
|------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromStream |  6,849.38 ns | 121.551 ns | 101.501 ns |  6,853.07 ns |  6,712.10 ns |  7,038.79 ns | 1.1673 | 0.0305 |    9792 B |
|   DataContractFromStream |  3,447.76 ns |  67.366 ns |  87.595 ns |  3,459.38 ns |  3,294.53 ns |  3,621.96 ns | 1.5182 | 0.0458 |   12720 B |
|            JilFromStream |    396.30 ns |   7.893 ns |  15.394 ns |    394.86 ns |    370.24 ns |    430.16 ns | 0.0734 |      - |     616 B |
|     MemoryPackFromStream |     94.30 ns |   1.802 ns |   1.850 ns |     94.72 ns |     90.10 ns |     96.66 ns | 0.0191 |      - |     160 B |
|    MessagePackFromStream |    262.93 ns |   4.901 ns |   4.585 ns |    261.69 ns |    253.69 ns |    269.15 ns | 0.0105 |      - |      88 B |
|        MsgPackFromStream |    635.54 ns |  11.228 ns |  10.502 ns |    633.32 ns |    619.12 ns |    655.47 ns | 0.0849 |      - |     712 B |
| NewtonsoftJsonFromStream |  1,680.83 ns |  33.573 ns |  56.093 ns |  1,696.32 ns |  1,550.24 ns |  1,773.69 ns | 0.3967 | 0.0038 |    3320 B |
|       ProtobufFromStream |    279.01 ns |   5.299 ns |   5.669 ns |    278.46 ns |    268.53 ns |    289.47 ns | 0.0105 |      - |      88 B |
|      SharpYamlFromStream |  1,042.33 ns |  20.815 ns |  55.197 ns |  1,019.76 ns |    959.97 ns |  1,207.98 ns | 0.7648 | 0.0038 |    6408 B |
| SystemTextJsonFromStream |    523.52 ns |   9.919 ns |   9.742 ns |    519.80 ns |    511.92 ns |    545.64 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromStream |    382.25 ns |   7.640 ns |   7.146 ns |    384.37 ns |    368.31 ns |    392.97 ns | 0.0105 |      - |      88 B |
|            XmlFromStream |  8,814.86 ns | 145.587 ns | 136.182 ns |  8,807.98 ns |  8,518.81 ns |  9,003.06 ns | 1.0986 |      - |    9201 B |
|     YamlDotNetFromStream | 12,801.06 ns | 229.916 ns | 215.064 ns | 12,786.10 ns | 12,462.65 ns | 13,194.36 ns | 1.7395 | 0.0458 |   14624 B |
|  ZeroFormatterFromStream |     70.28 ns |   1.339 ns |   1.877 ns |     69.89 ns |     67.21 ns |     74.50 ns | 0.0334 |      - |     280 B |
