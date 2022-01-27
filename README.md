# Zaabee.Serializers

---

[![Build Status](https://dev.azure.com/Zaabee/Zaabee.Serializers/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee.Serializers/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for serializers. It is also the serializer provider for all Zaabee technology stacks.

## Why use Zaabee.Serializers?

There are many different serializers in the world, they have different features and limitations. This project allows you to use difference serializers in the same way. Also it set nullable and default value for all serializers.

Serializers can be divided into two categories:

- Binary serializers
  - BinaryFormatter
  - MessagePack
  - MsgPack.Cli
  - protobuf-net
  - ZeroFormatter
- Text serializers
  - Json
    - Jil
    - Newtonsoft.Json
    - System.Text.Json
    - Utf8Json
  - Xml
    - XmlSerializer
    - DataContractSerializer
  - Yaml
    - SharpYaml
    - YamlDotNet

Though some serializers does not support stream or bytes, the zaabee serializers will supply the lack. And the text serializers will support text on this base.

## Explain

- Helper: Unified code style and provide lack of features. The default enconding is UTF-8.
  - stream
    - sync
      - MemoryStream ToStream\<TValue\>(TValue? value)
      - MemoryStream ToStream(Type type, object? value)
      - void Pack\<TValue\>(TValue? value, Stream? stream)
      - void Pack(Type type, object? value, Stream? stream)
      - TValue? FromStream\<TValue\>(Stream? stream)
      - object? FromStream(Type type, Stream? stream)
    - asyc
      - Task PackAsync\<TValue\>(TValue? value, Stream? stream)
      - Task PackAsync(Type type, object? value, Stream? stream)
      - Task\<TValue?\> FromStreamAsync\<TValue\>(Stream? stream)
      - Task\<object?\> FromStreamAsync(Type type, Stream? stream)
  - bytes
    - byte[] ToBytes\<TValue\>(TValue? value)
    - byte[] ToBytes(Type type, object? value)
    - TValue? FromBytes\<TValue\>(byte[]? bytes)
    - object? FromBytes(Type type, byte[]? bytes)
  - text
    - json
      - string ToJson\<TValue\>(TValue? value)
      - string ToJson(Type type, object? value)
      - TValue? FromJson\<TValue\>(string? json)
      - object? FromJson(Type type, string? json)
    - xml
      - string ToXml\<TValue\>(TValue? value)
      - string ToXml(Type type, object? value)
      - TValue? FromXml\<TValue\>(string? xml)
      - object? FromXml(Type type, string? xml)
    - yaml
      - string ToYaml\<TValue\>(TValue? value)
      - string ToYaml(Type type, object? value)
      - TValue? FromYaml\<TValue\>(string? xml)
      - object? FromYaml(Type type, string? xml)
- Extensions: Supply Extension methods base by Helper. Also it supports generic type and non-generic type.
  - Bytes
    - FromBytes
  - Object
    - PackTo
    - ToBytes
    - ToJson/ToXml/ToYaml
    - ToStream
  - Stream
    - FromStream
    - PackBy
  - String
    - FromJson/FromXml/FromYaml
- Serializer
  Implement Zaabee.Serializer.Abstractions, The Zaabee technology stacks use this library to serialize and deserialize.
  - Stream
    - stream ToStream\<TValue\>(TValue? value)
    - TValue? FromStream\<TValue\>(Stream? stream)
    - stream ToStream(Type type, object? value)
    - object? FromStream(Type type, Stream? stream)
  - Bytes
    - byte[] ToBytes\<TValue\>(TValue? value)
    - TValue? FromBytes\<TValue\>(byte[]? bytes)
    - byte[] ToBytes(Type type, object? value)
    - object? FromBytes(Type type, byte[]? bytes)
  - Text
    - string ToText\<TValue\>(TValue? value)
    - TValue? FromText\<TValue\>(string? text)
    - string ToText(Type type, object? value)
    - object? FromText(Type type, string? text)

## Getting Started

Use nuget to install the package which you want.

```shell
PM> Install-Package Zaabee.Binary
PM> Install-Package Zaabee.DataContractSerializer
PM> Install-Package Zaabee.Jil
PM> Install-Package Zaabee.NewtonsoftJson
PM> Install-Package Zaabee.MessagePack
PM> Install-Package Zaabee.MsgPack
PM> Install-Package Zaabee.Utf8Json
PM> Install-Package Zaabee.Protobuf
PM> Install-Package Zaabee.SharpYaml
PM> Install-Package Zaabee.SystemTextJson
PM> Install-Package Zaabee.Xml
PM> Install-Package Zaabee.YamlDotNet
PM> Install-Package Zaabee.ZeroFormatter
```

### [Zaabee.Binary](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.Binary)

Base by System.Runtime.Serialization.Formatters.Binary.BinaryFormatter, the first party BinaryFormatter from microsoft.

### [Zaabee.DataContractSerializer](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.DataContractSerializer)

Base by System.Runtime.Serialization.DataContractSerializer, serializes and deserializes an instance of a type into an XML stream or document using a supplied data contract.

### [Zaabee.Jil](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.Jil)

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

### [Zaabee.NewtonsoftJson](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.NewtonsoftJson)

Json.NET is a popular high-performance JSON framework for .NET [https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)

### [Zaabee.MessagePack](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.MessagePack)

The extremely fast MessagePack serializer for C#. It is 10x faster than MsgPack-Cli and outperforms other C# serializers. MessagePack for C# also ships with built-in support for LZ4 compression - an extremely fast compression algorithm. Performance is important, particularly in applications like games, distributed computing, microservices, or data caches.

### [Zaabee.MsgPack](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.MsgPack)

MessagePack implementation for Common Language Infrastructure / msgpack.org[C#]

### [Zaabee.Utf8Json](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.Utf8Json)

Definitely Fastest and Zero Allocation JSON Serializer for C#(NET, .NET Core, Unity, Xamarin).

### [Zaabee.Protobuf](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.Protobuf)

protobuf-net is a contract based serializer for .NET code, that happens to write data in the "protocol buffers" serialization format engineered by Google. The API, however, is very different to Google's, and follows typical .NET patterns (it is broadly comparable, in usage, to XmlSerializer, DataContractSerializer, etc). It should work for most .NET languages that write standard types and can use attributes.

### [Zaabee.SharpYaml](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.SharpYaml)

SharpYaml is a .NET library that provides a YAML parser and serialization engine for .NET objects, compatible with CoreCLR.

### [Zaabee.SystemTextJson](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.SystemTextJson)

The System.Text.Json namespace provides high-performance, low-allocating, and standards-compliant capabilities to process JavaScript Object Notation (JSON), which includes serializing objects to JSON text and deserializing JSON text to objects, with UTF-8 support built-in. It also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM) for random access of the JSON elements within a structured view of the data.

### [Zaabee.Xml](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.Xml)

Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.

### [Zaabee.YamlDotNet](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.YamlDotNet)

YamlDotNet is a YAML library for netstandard and other .NET runtimes.

YamlDotNet provides low level parsing and emitting of YAML as well as a high level object model similar to XmlDocument. A serialization library is also included that allows to read and write objects from and to YAML streams.

### [Zaabee.ZeroFormatter](https://github.com/PicoHex/Zaabee.Serializers/tree/master/src/Zaabee.ZeroFormatter)

Fastest C# Serializer and Infinitely Fast Deserializer for .NET, .NET Core and Unity.

## Benchmark

```ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1415 (21H1/May2021Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
```

IterationCount=1000  RunStrategy=Monitoring

### Stream

|                 Method |         Mean |       Error |      StdDev |       Median |         Min |          Max |   Gen 0 | Allocated |
|----------------------- |-------------:|------------:|------------:|-------------:|------------:|-------------:|--------:|----------:|
|         BinaryToStream |   8,190.0 ns |   157.04 ns |   209.65 ns |   8,170.8 ns |  7,845.7 ns |   8,585.7 ns |  3.1128 |   6,529 B |
|   DataContractToStream |   2,058.2 ns |    39.39 ns |    75.89 ns |   2,046.5 ns |  1,950.2 ns |   2,278.7 ns |  1.6022 |   3,352 B |
|            JilToStream |     688.1 ns |    16.42 ns |    47.37 ns |     671.9 ns |    618.4 ns |     824.7 ns |  0.6771 |   1,416 B |
|    MessagePackToStream |     532.4 ns |    11.31 ns |    31.91 ns |     522.9 ns |    488.8 ns |     634.6 ns |  0.1640 |     344 B |
|        MsgPackToStream |     697.4 ns |    14.06 ns |    38.73 ns |     690.7 ns |    633.5 ns |     819.9 ns |  0.3672 |     768 B |
| NewtonsoftJsonToStream |   1,582.8 ns |    38.42 ns |   112.07 ns |   1,581.7 ns |  1,408.9 ns |   1,850.4 ns |  1.0662 |   2,232 B |
|       ProtobufToStream |     582.2 ns |    24.77 ns |    70.26 ns |     564.4 ns |    500.1 ns |     770.2 ns |  0.1640 |     344 B |
|      SharpYamlToStream | 110,214.1 ns | 2,443.57 ns | 7,011.06 ns | 109,428.0 ns | 96,962.8 ns | 127,875.2 ns | 13.1836 |  27,634 B |
| SystemTextJsonToStream |     709.6 ns |    15.97 ns |    46.32 ns |     705.8 ns |    633.5 ns |     819.7 ns |  0.2365 |     496 B |
|       Utf8JsonToStream |     507.1 ns |    11.07 ns |    31.60 ns |     496.1 ns |    463.0 ns |     596.3 ns |  0.1640 |     344 B |
|            XmlToStream |  12,136.9 ns |   256.15 ns |   722.47 ns |  11,919.8 ns | 11,217.4 ns |  14,458.4 ns |  5.2795 |  11,060 B |
|     YamlDotNetToStream |  35,182.8 ns | 1,013.38 ns | 2,956.09 ns |  34,156.0 ns | 31,821.5 ns |  43,367.9 ns |  6.2256 |  13,133 B |
|  ZeroFormatterToStream |     328.4 ns |     8.40 ns |    23.82 ns |     321.8 ns |    294.6 ns |     403.5 ns |  0.7300 |   1,528 B |

|                   Method |        Mean |     Error |    StdDev |      Median |         Min |         Max |   Gen 0 | Allocated |
|------------------------- |------------:|----------:|----------:|------------:|------------:|------------:|--------:|----------:|
|         BinaryFromStream | 11,159.5 ns | 198.71 ns | 185.87 ns | 11,208.8 ns | 10,781.8 ns | 11,462.8 ns |  4.6692 |   9,792 B |
|   DataContractFromStream |  6,268.8 ns | 119.46 ns | 132.78 ns |  6,259.5 ns |  6,080.0 ns |  6,598.7 ns |  6.1111 |  12,808 B |
|            JilFromStream |    574.1 ns |  10.62 ns |   8.87 ns |    572.5 ns |    558.4 ns |    593.2 ns |  0.2937 |     616 B |
|    MessagePackFromStream |    475.2 ns |   9.53 ns |  12.06 ns |    470.6 ns |    461.2 ns |    504.2 ns |  0.0420 |      88 B |
|        MsgPackFromStream |  1,104.5 ns |  20.46 ns |  18.14 ns |  1,104.1 ns |  1,076.7 ns |  1,135.0 ns |  0.3510 |     736 B |
| NewtonsoftJsonFromStream |  3,048.0 ns |  35.90 ns |  39.90 ns |  3,040.4 ns |  2,994.5 ns |  3,116.4 ns |  1.5945 |   3,344 B |
|       ProtobufFromStream |    480.2 ns |   9.38 ns |   9.21 ns |    478.6 ns |    470.2 ns |    505.8 ns |  0.0420 |      88 B |
|      SharpYamlFromStream |  5,799.9 ns | 115.86 ns | 190.37 ns |  5,754.6 ns |  5,499.8 ns |  6,354.9 ns |  3.0746 |   6,440 B |
| SystemTextJsonFromStream |  1,082.6 ns |  22.46 ns |  65.52 ns |  1,058.7 ns |  1,010.4 ns |  1,249.0 ns |  0.0420 |      88 B |
|       Utf8JsonFromStream |    755.2 ns |  14.94 ns |  26.55 ns |    744.8 ns |    720.3 ns |    811.0 ns |  0.0420 |      88 B |
|            XmlFromStream | 16,172.1 ns | 320.79 ns | 284.37 ns | 16,097.3 ns | 15,857.4 ns | 16,776.6 ns |  4.5471 |   9,531 B |
|     YamlDotNetFromStream | 23,973.1 ns | 472.19 ns | 597.16 ns | 23,921.1 ns | 22,945.1 ns | 25,278.0 ns | 11.0474 |  23,138 B |
|  ZeroFormatterFromStream |    120.8 ns |   2.04 ns |   2.50 ns |    121.0 ns |    115.7 ns |    126.2 ns |  0.1338 |     280 B |

### FileStream Async

|                        Method |      Mean |     Error |    StdDev |       Min |      Max |    Median |  Gen 0 | Allocated |
|------------------------------ |----------:|----------:|----------:|----------:|---------:|----------:|-------:|----------:|
|            JilFromStreamAsync | 37.639 μs | 0.3318 μs | 0.3104 μs | 37.210 μs | 38.23 μs | 37.731 μs | 0.7935 |   1,726 B |
|    MessagePackFromStreamAsync | 48.675 μs | 0.9557 μs | 1.9085 μs | 42.430 μs | 51.67 μs | 49.239 μs | 0.2441 |     583 B |
|        MsgPackFromStreamAsync |  9.364 μs | 0.1846 μs | 0.2400 μs |  9.020 μs | 10.01 μs |  9.311 μs | 1.6785 |   3,512 B |
| NewtonsoftJsonFromStreamAsync | 67.747 μs | 1.3427 μs | 3.2684 μs | 56.948 μs | 72.29 μs | 68.219 μs | 2.3193 |   4,654 B |
| SystemTextJsonFromStreamAsync | 34.850 μs | 0.3215 μs | 0.2850 μs | 34.321 μs | 35.38 μs | 34.898 μs | 0.4272 |     977 B |
|       Utf8JsonFromStreamAsync | 32.602 μs | 0.4081 μs | 0.3618 μs | 32.031 μs | 33.22 μs | 32.593 μs | 0.3052 |     660 B |

### Bytes

|                Method |         Mean |       Error |      StdDev |         Min |          Max |       Median |   Gen 0 | Allocated |
|---------------------- |-------------:|------------:|------------:|------------:|-------------:|-------------:|--------:|----------:|
|         BinaryToBytes |   8,109.8 ns |   161.08 ns |   225.81 ns |  7,753.6 ns |   8,606.4 ns |   8,069.5 ns |  3.3417 |   6,994 B |
|   DataContractToBytes |   2,110.5 ns |    40.45 ns |    49.67 ns |  2,043.1 ns |   2,250.6 ns |   2,103.8 ns |  1.8845 |   3,944 B |
|            JilToBytes |     580.3 ns |    10.76 ns |     9.54 ns |    566.7 ns |     597.5 ns |     579.0 ns |  0.5121 |   1,072 B |
|    MessagePackToBytes |     265.4 ns |     5.11 ns |     7.96 ns |    254.3 ns |     288.2 ns |     263.9 ns |  0.0381 |      80 B |
|        MsgPackToBytes |     678.4 ns |    12.08 ns |    10.09 ns |    658.8 ns |     698.5 ns |     676.9 ns |  0.3977 |     832 B |
| NewtonsoftJsonToBytes |   1,429.4 ns |    41.02 ns |   116.35 ns |  1,284.3 ns |   1,756.7 ns |   1,408.8 ns |  0.9022 |   1,888 B |
|       ProtobufToBytes |     641.7 ns |    24.99 ns |    71.29 ns |    552.5 ns |     839.2 ns |     628.5 ns |  0.1945 |     408 B |
|      SharpYamlToBytes | 105,588.3 ns | 2,098.50 ns | 5,226.01 ns | 94,862.1 ns | 121,006.5 ns | 105,616.1 ns | 13.1836 |  27,818 B |
| SystemTextJsonToBytes |     587.0 ns |    14.16 ns |    40.39 ns |    533.8 ns |     689.3 ns |     576.4 ns |  0.1411 |     296 B |
|       Utf8JsonToBytes |     441.6 ns |     8.78 ns |    13.41 ns |    419.8 ns |     468.2 ns |     439.8 ns |  0.0725 |     152 B |
|            XmlToBytes |  11,763.2 ns |   234.23 ns |   320.61 ns | 11,222.2 ns |  12,430.0 ns |  11,722.0 ns |  5.4321 |  11,396 B |
|     YamlDotNetToBytes |  33,598.7 ns |   663.66 ns | 1,013.48 ns | 31,665.0 ns |  36,160.8 ns |  33,397.7 ns |  6.2256 |  13,069 B |
|  ZeroFormatterToBytes |     219.1 ns |     3.60 ns |     7.43 ns |    207.6 ns |     240.3 ns |     217.5 ns |  0.5660 |   1,184 B |

|                  Method |          Mean |        Error |       StdDev |        Median |           Min |          Max |   Gen 0 | Allocated |
|------------------------ |--------------:|-------------:|-------------:|--------------:|--------------:|-------------:|--------:|----------:|
|         BinaryFromBytes |  11,284.25 ns |   225.665 ns |   285.394 ns |  11,226.93 ns |  10,958.17 ns |  12,059.0 ns |  4.6997 |   9,856 B |
|   DataContractFromBytes |   6,188.18 ns |   123.414 ns |   103.056 ns |   6,189.96 ns |   6,036.78 ns |   6,415.4 ns |  6.1493 |  12,872 B |
|            JilFromBytes |     570.55 ns |    11.235 ns |    21.375 ns |     560.37 ns |     545.17 ns |     637.0 ns |  0.2213 |     464 B |
|    MessagePackFromBytes |     430.13 ns |     8.529 ns |    14.939 ns |     422.20 ns |     407.96 ns |     472.0 ns |  0.0420 |      88 B |
|        MsgPackFromBytes |   1,101.17 ns |    18.170 ns |    19.442 ns |   1,099.26 ns |   1,071.76 ns |   1,136.5 ns |  0.3815 |     800 B |
| NewtonsoftJsonFromBytes |   2,944.52 ns |    45.944 ns |    49.159 ns |   2,951.07 ns |   2,860.15 ns |   3,047.5 ns |  1.5259 |   3,200 B |
|       ProtobufFromBytes |     641.06 ns |    11.469 ns |    22.906 ns |     632.32 ns |     617.37 ns |     708.2 ns |  0.0839 |     176 B |
|      SharpYamlFromBytes | 116,275.03 ns | 2,279.274 ns | 3,119.896 ns | 115,529.63 ns | 110,813.89 ns | 124,096.5 ns | 14.4043 |  30,249 B |
| SystemTextJsonFromBytes |     844.24 ns |    14.197 ns |    11.855 ns |     841.62 ns |     827.14 ns |     869.3 ns |  0.0420 |      88 B |
|       Utf8JsonFromBytes |     688.51 ns |    13.249 ns |    12.393 ns |     684.46 ns |     670.07 ns |     712.8 ns |  0.0420 |      88 B |
|            XmlFromBytes |  16,222.13 ns |   232.034 ns |   193.759 ns |  16,271.15 ns |  15,880.48 ns |  16,496.3 ns |  4.5776 |   9,595 B |
|     YamlDotNetFromBytes |  23,928.67 ns |   465.417 ns |   588.604 ns |  23,656.92 ns |  23,131.42 ns |  25,392.4 ns | 10.9863 |  22,986 B |
|  ZeroFormatterFromBytes |      97.10 ns |     1.940 ns |     2.782 ns |      96.47 ns |      92.77 ns |     103.2 ns |  0.1339 |     280 B |

### Text

|               Method |         Mean |       Error |       StdDev |       Median |         Min |          Max |   Gen 0 | Allocated |
|--------------------- |-------------:|------------:|-------------:|-------------:|------------:|-------------:|--------:|----------:|
|   DataContractToText |   2,585.6 ns |    70.55 ns |    204.67 ns |   2,504.4 ns |  2,328.8 ns |   3,184.0 ns |  2.4376 |   5,104 B |
|            JilToText |     539.2 ns |    13.26 ns |     38.24 ns |     525.6 ns |    487.0 ns |     641.7 ns |  0.4396 |     920 B |
| NewtonsoftJsonToText |   1,413.8 ns |    48.20 ns |    138.30 ns |   1,377.7 ns |  1,201.8 ns |   1,805.4 ns |  0.8335 |   1,744 B |
|      SharpYamlToText | 110,423.5 ns | 4,647.67 ns | 12,565.24 ns | 106,247.5 ns | 94,687.3 ns | 157,092.9 ns | 12.2070 |  25,960 B |
| SystemTextJsonToText |     613.6 ns |    12.19 ns |     29.90 ns |     603.3 ns |    580.4 ns |     700.2 ns |  0.1945 |     408 B |
|       Utf8JsonToText |     484.7 ns |     8.58 ns |     12.03 ns |     479.5 ns |    467.4 ns |     519.8 ns |  0.1259 |     264 B |
|            XmlToText |  12,154.2 ns |   242.43 ns |    355.36 ns |  12,117.0 ns | 11,635.7 ns |  12,956.9 ns |  5.7373 |  12,028 B |
|     YamlDotNetToText |  32,803.9 ns |   585.82 ns |  1,085.86 ns |  32,734.7 ns | 31,166.0 ns |  35,379.7 ns |  6.1646 |  12,917 B |

|                 Method |         Mean |       Error |      StdDev |       Median |          Min |          Max |   Gen 0 | Allocated |
|----------------------- |-------------:|------------:|------------:|-------------:|-------------:|-------------:|--------:|----------:|
|   DataContractFromText |   6,335.4 ns |    72.27 ns |    60.35 ns |   6,360.3 ns |   6,204.3 ns |   6,410.1 ns |  6.4240 |  13,464 B |
|            JilFromText |     448.4 ns |     7.73 ns |     8.60 ns |     444.9 ns |     437.5 ns |     471.9 ns |  0.0877 |     184 B |
| NewtonsoftJsonFromText |   2,879.9 ns |    56.89 ns |   132.99 ns |   2,827.6 ns |   2,694.1 ns |   3,189.2 ns |  1.4038 |   2,944 B |
|      SharpYamlFromText | 111,579.6 ns | 2,206.33 ns | 3,864.22 ns | 109,914.7 ns | 105,527.9 ns | 119,206.3 ns | 12.6953 |  26,871 B |
| SystemTextJsonFromText |     993.4 ns |    19.84 ns |    45.59 ns |     978.4 ns |     929.3 ns |   1,106.3 ns |  0.0420 |      88 B |
|       Utf8JsonFromText |     769.6 ns |    13.77 ns |    12.21 ns |     768.6 ns |     750.2 ns |     789.2 ns |  0.1144 |     240 B |
|            XmlFromText |  16,828.9 ns |   328.74 ns |   558.22 ns |  16,649.0 ns |  16,119.8 ns |  18,143.3 ns |  4.7302 |   9,924 B |
|     YamlDotNetFromText |  23,825.1 ns |   422.22 ns |   352.57 ns |  23,836.4 ns |  23,255.6 ns |  24,382.4 ns | 10.8643 |  22,722 B |
