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

|                  Method |     Mean |    Error |    StdDev |   Median |       Min |         Max | Allocated |
|------------------------ |---------:|---------:|----------:|---------:|----------:|------------:|----------:|
|         BinarySerialize | 72.56 us | 3.160 us | 30.282 us | 69.10 us | 36.300 us |   321.60 us |    7904 B |
|            JilSerialize | 11.31 us | 0.879 us |  8.419 us | 10.30 us |  5.800 us |   230.70 us |    1072 B |
|        MsgPackSerialize | 17.38 us | 1.022 us |  9.796 us | 16.00 us |  8.100 us |   207.00 us |     856 B |
| NewtonsoftJsonSerialize | 18.04 us | 0.974 us |  9.332 us | 16.00 us | 10.000 us |   151.40 us |    1904 B |
|       ProtobufSerialize | 13.10 us | 0.746 us |  7.152 us | 11.60 us |  7.100 us |   113.10 us |    1712 B |
| SystemTextJsonSerialize | 15.22 us | 0.711 us |  6.810 us | 14.00 us |  8.400 us |    83.30 us |     296 B |
|       Utf8JsonSerialize | 11.57 us | 0.663 us |  6.351 us | 10.40 us |  5.400 us |    73.40 us |     152 B |
|            XmlSerialize | 97.57 us | 5.588 us | 53.544 us | 94.30 us | 50.000 us | 1,322.80 us |   10888 B |

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

|             Method |     Mean |    Error |    StdDev |   Median |       Min |       Max | Allocated |
|------------------- |---------:|---------:|----------:|---------:|----------:|----------:|----------:|
|         BinaryPack | 66.31 us | 2.611 us | 25.015 us | 61.25 us | 37.100 us | 258.00 us |    7440 B |
|            JilPack | 11.49 us | 0.608 us |  5.822 us | 10.40 us |  5.900 us |  66.90 us |    1424 B |
|        MsgPackPack | 16.98 us | 1.263 us | 12.098 us | 14.70 us |  8.100 us | 157.80 us |     792 B |
| NewtonsoftJsonPack | 25.70 us | 1.237 us | 11.849 us | 24.60 us | 10.900 us | 146.50 us |    2256 B |
|       ProtobufPack | 11.47 us | 0.628 us |  6.013 us | 10.00 us |  6.100 us |  87.50 us |    1648 B |
| SystemTextJsonPack | 17.66 us | 1.352 us | 12.950 us | 15.45 us |  9.100 us | 325.40 us |     648 B |
|       Utf8JsonPack | 14.78 us | 0.728 us |  6.977 us | 13.90 us |  6.400 us |  83.00 us |     352 B |
|            XmlPack | 92.78 us | 4.747 us | 45.488 us | 85.85 us | 47.400 us | 724.40 us |   10552 B |

|               Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|--------------------- |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|         BinaryUnpack |  81.06 us | 2.889 us | 27.682 us |  73.65 us | 46.500 us | 385.30 us |    9664 B |
|            JilUnpack |  17.37 us | 0.627 us |  6.011 us |  15.80 us |  9.600 us |  78.30 us |     624 B |
|        MsgPackUnpack |  31.22 us | 1.179 us | 11.295 us |  28.70 us | 15.700 us | 180.50 us |     744 B |
| NewtonsoftJsonUnpack |  50.68 us | 1.553 us | 14.883 us |  49.60 us | 26.800 us | 165.70 us |    3360 B |
|       ProtobufUnpack |  25.81 us | 1.446 us | 13.859 us |  23.60 us | 13.000 us | 312.00 us |    1416 B |
| SystemTextJsonUnpack |  28.83 us | 1.106 us | 10.601 us |  26.85 us | 14.300 us | 125.30 us |     240 B |
|       Utf8JsonUnpack |  16.10 us | 0.770 us |  7.374 us |  14.20 us |  8.200 us | 125.90 us |      96 B |
|            XmlUnpack | 141.45 us | 3.369 us | 32.277 us | 134.15 us | 87.500 us | 358.80 us |    8272 B |

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
