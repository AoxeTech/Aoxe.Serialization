# Benchmark

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.100
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Job-RTTPLA : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

IterationCount=100  RunStrategy=Monitoring

## Text serialize

|                        Method |      Mean |     Error |    StdDev |     Median |       Min |       Max | Allocated |
|------------------------------ |----------:|----------:|----------:|-----------:|----------:|----------:|----------:|
|            JilSerializeToJson |  10.34 us |  1.679 us |  4.950 us |   9.450 us |  5.200 us |  44.20 us |     920 B |
| NewtonsoftJsonSerializeToJson |  12.42 us |  2.630 us |  7.755 us |  10.050 us |  9.200 us |  70.70 us |    1760 B |
|       Utf8JsonSerializeToJson |  11.73 us |  1.637 us |  4.827 us |  10.600 us |  5.600 us |  33.50 us |     272 B |
|             XmlSerializeToXml | 120.96 us | 13.628 us | 40.182 us | 120.750 us | 55.800 us | 348.30 us |   12368 B |

## Text deserialize

|                            Method |      Mean |     Error |    StdDev |       Min |       Max |    Median | Allocated |
|---------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
|            JilDeserializeFromJson |  13.15 us |  1.380 us |  4.068 us |  6.000 us |  32.80 us |  13.60 us |     192 B |
| NewtonsoftJsonDeserializeFromJson |  56.74 us |  4.355 us | 12.840 us | 24.900 us | 116.40 us |  56.60 us |    2960 B |
|       Utf8JsonDeserializeFromJson |  17.18 us |  5.334 us | 15.727 us |  7.700 us | 154.20 us |  14.10 us |     248 B |
|             XmlDeserializeFromXml | 193.44 us | 30.865 us | 91.007 us | 93.000 us | 599.10 us | 169.65 us |    8864 B |

## Bytes serialize

|                  Method |       Mean |     Error |    StdDev |     Median |       Min |       Max | Allocated |
|------------------------ |-----------:|----------:|----------:|-----------:|----------:|----------:|----------:|
|         BinarySerialize |  51.387 us |  6.788 us | 20.014 us |  41.550 us | 33.100 us | 140.70 us |    7904 B |
|            JilSerialize |   9.609 us |  1.189 us |  3.505 us |   9.700 us |  5.400 us |  27.00 us |    1072 B |
|        MsgPackSerialize |  18.450 us |  2.716 us |  8.008 us |  17.150 us |  8.500 us |  58.70 us |     856 B |
| NewtonsoftJsonSerialize |  24.558 us |  3.892 us | 11.477 us |  23.200 us | 11.200 us | 113.60 us |    1904 B |
|       ProtobufSerialize |  16.902 us |  4.598 us | 13.556 us |  13.950 us |  8.000 us | 128.80 us |    1712 B |
|       Utf8JsonSerialize |  15.276 us |  2.777 us |  8.188 us |  13.300 us |  7.200 us |  64.50 us |     152 B |
|            XmlSerialize | 113.895 us | 11.166 us | 32.923 us | 115.300 us | 54.200 us | 265.40 us |   11720 B |
|  ZeroFormatterSerialize |   6.357 us |  1.043 us |  3.076 us |   5.350 us |  4.300 us |  28.10 us |     424 B |

## Bytes deserialize

|                       Method |       Mean |      Error |    StdDev |        Min |       Max |     Median | Allocated |
|----------------------------- |-----------:|-----------:|----------:|-----------:|----------:|-----------:|----------:|
|            BinaryDeserialize | 105.209 us |  6.1408 us | 18.106 us |  71.300 us | 191.60 us | 101.700 us |    9736 B |
|               JilDeserialize |  15.076 us |  1.5861 us |  4.677 us |   8.400 us |  34.50 us |  15.150 us |     472 B |
|           MsgPackDeserialize |  41.192 us |  3.6588 us | 10.788 us |  25.500 us | 114.60 us |  38.850 us |     816 B |
|    NewtonsoftJsonDeserialize |  53.119 us |  3.5525 us | 10.475 us |  34.400 us |  88.30 us |  51.500 us |    3216 B |
|          ProtobufDeserialize |  29.471 us |  2.7322 us |  8.056 us |  15.200 us |  56.90 us |  29.550 us |    1488 B |
| Utf8JsonSerializeDeserialize |  16.442 us |  1.7041 us |  5.024 us |   8.900 us |  45.10 us |  16.250 us |      96 B |
|               XmlDeserialize | 172.534 us | 12.4523 us | 36.716 us | 108.000 us | 328.90 us | 178.350 us |    8528 B |
|     ZeroFormatterDeserialize |   6.656 us |  0.9741 us |  2.872 us |   2.900 us |  25.90 us |   6.000 us |     280 B |

## Stream pack

|             Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|------------------- |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|         BinaryPack | 61.117 us | 8.302 us | 24.479 us | 51.050 us | 36.800 us | 130.30 us |    7440 B |
|            JilPack | 10.376 us | 1.137 us |  3.353 us | 10.300 us |  5.700 us |  24.10 us |    1144 B |
|        MsgPackPack | 17.318 us | 3.044 us |  8.976 us | 16.950 us |  7.700 us |  85.20 us |     792 B |
| NewtonsoftJsonPack | 19.663 us | 3.856 us | 11.371 us | 17.850 us | 10.100 us | 107.60 us |    2256 B |
|       ProtobufPack |  8.484 us | 1.420 us |  4.188 us |  7.050 us |  6.100 us |  39.80 us |    1648 B |
|       Utf8JsonPack |  8.348 us | 1.888 us |  5.566 us |  6.500 us |  5.200 us |  52.20 us |     224 B |
|            XmlPack | 79.039 us | 8.351 us | 24.623 us | 74.700 us | 51.900 us | 168.40 us |   11384 B |
|  ZeroFormatterPack |  6.379 us | 1.088 us |  3.209 us |  5.500 us |  4.000 us |  28.20 us |     776 B |

## Stream unpack

|                  Method |       Mean |     Error |    StdDev |     Median |       Min |       Max | Allocated |
|------------------------ |-----------:|----------:|----------:|-----------:|----------:|----------:|----------:|
|            BinaryUnpack |  77.861 us |  6.547 us | 19.303 us |  74.250 us | 45.300 us | 146.50 us |    9664 B |
|               JilUnpack |  25.369 us |  5.298 us | 15.622 us |  21.350 us | 10.900 us | 130.80 us |     624 B |
|           MsgPackUnpack |  40.459 us |  6.272 us | 18.494 us |  36.750 us | 16.700 us | 137.90 us |     744 B |
|    NewtonsoftJsonUnpack |  54.873 us |  8.582 us | 25.304 us |  51.250 us | 28.300 us | 171.10 us |    3360 B |
|          ProtobufUnpack |  37.790 us | 10.447 us | 30.804 us |  28.800 us | 12.100 us | 207.80 us |    1416 B |
| Utf8JsonSerializeUnpack |  21.050 us |  2.326 us |  6.858 us |  19.850 us |  7.900 us |  59.10 us |      96 B |
|               XmlUnpack | 128.418 us |  9.653 us | 28.463 us | 123.850 us | 79.600 us | 251.30 us |    8456 B |
|     ZeroFormatterUnpack |   8.381 us |  1.316 us |  3.880 us |   7.300 us |  5.800 us |  36.40 us |     280 B |
