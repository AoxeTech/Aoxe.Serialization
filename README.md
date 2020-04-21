# Zaabee.Serializers

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for serializers.

## [Zaabee.Binary](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Binary)

Base by System.Runtime.Serialization.Formatters.Binary.BinaryFormatter,the first party BinaryFormatter from microsoft.

## [Zaabee.Jil](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Jil)

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

## [Zaabee.NewtonsoftJson](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.NewtonsoftJson)

Json.NET is a popular high-performance JSON framework for .NET [https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)

## [Zaabee.MsgPack](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.MsgPack)

MessagePack is an extremely efficient object serialization library. It's like JSON, but very fast and small.

## [Zaabee.Utf8Json](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Utf8Json)

Definitely Fastest and Zero Allocation JSON Serializer for C#(NET, .NET Core, Unity, Xamarin).

## [Zaabee.Protobuf](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Protobuf)

protobuf-net is a contract based serializer for .NET code, that happens to write data in the "protocol buffers" serialization format engineered by Google. The API, however, is very different to Google's, and follows typical .NET patterns (it is broadly comparable, in usage, to XmlSerializer, DataContractSerializer, etc). It should work for most .NET languages that write standard types and can use attributes.

## [Zaabee.SystemTextJson](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.SystemTextJson)

The System.Text.Json namespace provides high-performance, low-allocating, and standards-compliant capabilities to process JavaScript Object Notation (JSON), which includes serializing objects to JSON text and deserializing JSON text to objects, with UTF-8 support built-in. It also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM) for random access of the JSON elements within a structured view of the data.

## [Zaabee.Xml](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Xml)

Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.

## [Zaabee.ZeroFormatter](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.ZeroFormatter)

Fastest C# Serializer and Infinitely Fast Deserializer for .NET, .NET Core and Unity.

## Benchmark

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.101
  [Host]     : .NET Core 2.1.15 (CoreCLR 4.6.28325.01, CoreFX 4.6.28327.02), X64 RyuJIT
  Job-AZAVGG : .NET Core 2.1.15 (CoreCLR 4.6.28325.01, CoreFX 4.6.28327.02), X64 RyuJIT

IterationCount=10000  RunStrategy=Monitoring

### Bytes

|                  Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|------------------------ |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|         BinarySerialize |  67.78 μs | 3.950 μs | 37.849 μs | 54.950 μs | 35.600 μs | 346.80 μs |    7904 B |
|            JilSerialize |  10.93 μs | 0.816 μs |  7.816 μs |  8.700 μs |  4.900 μs |  77.60 μs |    1072 B |
|        MsgPackSerialize |  18.71 μs | 1.199 μs | 11.491 μs | 16.300 μs |  7.600 μs |  95.20 μs |     856 B |
| NewtonsoftJsonSerialize |  22.06 μs | 1.455 μs | 13.939 μs | 19.000 μs |  9.300 μs | 134.90 μs |    1904 B |
|       ProtobufSerialize |  13.11 μs | 1.067 μs | 10.220 μs | 10.050 μs |  5.700 μs | 141.40 μs |    1712 B |
| SystemTextJsonSerialize |  19.56 μs | 1.398 μs | 13.397 μs | 16.650 μs |  7.300 μs | 157.10 μs |     296 B |
|       Utf8JsonSerialize |  12.69 μs | 0.971 μs |  9.300 μs | 10.900 μs |  4.400 μs | 119.40 μs |     152 B |
|            XmlSerialize | 106.50 μs | 5.705 μs | 54.663 μs | 99.500 μs | 43.500 μs | 672.40 μs |   10888 B |

|                    Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|-------------------------- |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|         BinaryDeserialize | 113.89 us | 3.033 us | 29.060 us | 115.25 us | 61.900 us | 283.40 us |    9736 B |
|            JilDeserialize |  16.40 us | 0.697 us |  6.675 us |  15.10 us | 10.200 us | 144.50 us |     472 B |
|        MsgPackDeserialize |  35.81 us | 1.226 us | 11.743 us |  34.10 us | 22.500 us | 191.20 us |     816 B |
| NewtonsoftJsonDeserialize |  53.33 us | 1.738 us | 16.650 us |  50.10 us | 34.700 us | 260.70 us |    3216 B |
|       ProtobufDeserialize |  31.08 us | 1.271 us | 12.180 us |  29.60 us | 13.300 us | 199.50 us |    1488 B |
| SystemTextJsonDeserialize |  26.70 us | 1.387 us | 13.294 us |  25.25 us | 11.800 us | 327.50 us |      96 B |
|       Utf8JsonDeserialize |  16.41 us | 0.624 us |  5.984 us |  15.65 us |  7.500 us |  63.60 us |      96 B |
|            XmlDeserialize | 145.24 us | 3.352 us | 32.121 us | 138.00 us | 91.300 us | 342.90 us |    8344 B |

### Text

|                        Method |     Mean |    Error |    StdDev |   Median |       Min |       Max | Allocated |
|------------------------------ |---------:|---------:|----------:|---------:|----------:|----------:|----------:|
|            JilSerializeToJson | 12.47 us | 0.921 us |  8.830 us | 11.45 us |  5.400 us | 151.70 us |     920 B |
| NewtonsoftJsonSerializeToJson | 15.49 us | 0.759 us |  7.270 us | 13.40 us |  9.200 us |  74.00 us |    1760 B |
| SystemTextJsonSerializeToJson | 18.54 us | 1.122 us | 10.749 us | 16.90 us |  9.400 us | 171.20 us |     408 B |
|       Utf8JsonSerializeToJson | 11.50 us | 1.249 us | 11.966 us | 10.10 us |  5.600 us | 315.80 us |     272 B |
|             XmlSerializeToXml | 92.65 us | 3.580 us | 34.304 us | 88.20 us | 47.200 us | 386.30 us |   11536 B |

|                            Method |      Mean |    Error |    StdDev |    Median |       Min |         Max | Allocated |
|---------------------------------- |----------:|---------:|----------:|----------:|----------:|------------:|----------:|
|            JilDeserializeFromJson |  13.78 us | 0.600 us |  5.746 us |  12.90 us |  6.000 us |    92.20 us |     192 B |
| NewtonsoftJsonDeserializeFromJson |  46.40 us | 1.553 us | 14.878 us |  44.20 us | 22.000 us |   198.90 us |    2960 B |
| SystemTextJsonDeserializeFromJson |  26.46 us | 1.084 us | 10.387 us |  24.30 us | 12.200 us |   105.70 us |      96 B |
|       Utf8JsonDeserializeFromJson |  18.54 us | 1.843 us | 17.662 us |  15.90 us |  8.100 us |   390.90 us |     248 B |
|             XmlDeserializeFromXml | 136.32 us | 5.535 us | 53.034 us | 129.90 us | 76.600 us | 1,337.30 us |    8680 B |

### Stream

|             Method |      Mean |    Error |    StdDev |   Median |       Min |       Max | Allocated |
|------------------- |----------:|---------:|----------:|---------:|----------:|----------:|----------:|
|         BinaryPack |  68.53 μs | 4.071 μs | 39.009 μs | 59.40 μs | 34.300 μs | 415.30 μs |    7440 B |
|            JilPack |  14.01 μs | 0.881 μs |  8.443 μs | 12.70 μs |  5.300 μs |  90.70 μs |    1424 B |
|        MsgPackPack |  17.75 μs | 1.205 μs | 11.547 μs | 15.15 μs |  7.300 μs |  78.90 μs |     792 B |
| NewtonsoftJsonPack |  22.95 μs | 1.579 μs | 15.134 μs | 19.85 μs | 10.400 μs | 157.30 μs |    2256 B |
|       ProtobufPack |  12.97 μs | 1.426 μs | 13.666 μs | 10.60 μs |  5.700 μs | 354.70 μs |    1648 B |
| SystemTextJsonPack |  19.25 μs | 1.958 μs | 18.760 μs | 15.20 μs |  8.500 μs | 339.60 μs |     648 B |
|       Utf8JsonPack |  15.00 μs | 1.015 μs |  9.721 μs | 12.80 μs |  5.500 μs |  95.90 μs |     352 B |
|            XmlPack | 100.06 μs | 5.407 μs | 51.812 μs | 91.15 μs | 43.600 μs | 391.80 μs |   10552 B |

|               Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|--------------------- |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|         BinaryUnpack |  91.25 μs | 3.293 μs | 31.558 μs |  84.10 μs | 44.200 μs | 246.00 μs |    9664 B |
|            JilUnpack |  17.82 μs | 0.883 μs |  8.458 μs |  16.30 μs |  7.700 μs |  75.20 μs |     624 B |
|        MsgPackUnpack |  34.01 μs | 1.711 μs | 16.392 μs |  31.30 μs | 14.400 μs | 153.50 μs |     744 B |
| NewtonsoftJsonUnpack |  57.31 μs | 2.292 μs | 21.962 μs |  54.85 μs | 24.800 μs | 178.20 μs |    3360 B |
|       ProtobufUnpack |  29.34 μs | 1.727 μs | 16.545 μs |  26.40 μs | 11.800 μs | 236.30 μs |    1416 B |
| SystemTextJsonUnpack |  36.16 μs | 1.631 μs | 15.625 μs |  33.00 μs | 13.900 μs | 174.70 μs |     240 B |
|       Utf8JsonUnpack |  19.07 μs | 1.003 μs |  9.609 μs |  17.60 μs |  7.700 μs |  97.50 μs |      96 B |
|            XmlUnpack | 195.23 μs | 6.697 μs | 64.173 μs | 186.90 μs | 90.000 μs | 678.00 μs |    8272 B |

### FileStream Async

|                  Method |     Mean |     Error |    StdDev |   Median |      Min |       Max | Allocated |
|------------------------ |---------:|----------:|----------:|---------:|---------:|----------:|----------:|
|            JilPackAsync | 1.438 ms | 0.0105 ms | 0.1008 ms | 1.432 ms | 1.025 ms |  2.230 ms |   1.88 KB |
|        MsgPackPackAsync | 4.056 ms | 0.0889 ms | 0.8519 ms | 3.852 ms | 3.401 ms | 11.163 ms |   2.19 KB |
| NewtonsoftJsonPackAsync | 1.429 ms | 0.0152 ms | 0.1460 ms | 1.418 ms | 1.071 ms |  4.107 ms |   2.71 KB |
| SystemTextJsonPackAsync | 1.585 ms | 0.0157 ms | 0.1502 ms | 1.564 ms | 1.324 ms |  3.964 ms |   1.69 KB |
|       Utf8JsonPackAsync | 1.440 ms | 0.0111 ms | 0.1062 ms | 1.431 ms | 1.184 ms |  1.942 ms |   1.37 KB |

|                    Method |     Mean |   Error |   StdDev |   Median |      Min |      Max | Allocated |
|-------------------------- |---------:|--------:|---------:|---------:|---------:|---------:|----------:|
|            JilUnpackAsync | 146.8 us | 2.89 us | 27.70 us | 142.3 us | 106.7 us | 409.5 us |     864 B |
|        MsgPackUnpackAsync | 344.9 us | 5.43 us | 52.03 us | 336.3 us | 254.2 us | 894.2 us |    1832 B |
| NewtonsoftJsonUnpackAsync | 201.8 us | 3.22 us | 30.82 us | 196.2 us | 142.4 us | 536.2 us |     928 B |
| SystemTextJsonUnpackAsync | 184.6 us | 3.28 us | 31.44 us | 180.0 us | 126.2 us | 457.2 us |     944 B |
|       Utf8JsonUnpackAsync |       NA |      NA |       NA |       NA |       NA |       NA |         - |
