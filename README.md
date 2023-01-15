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
BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22621.819)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
```

IterationCount=1000  RunStrategy=Monitoring

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

|                Method |        Mean |     Error |    StdDev |          Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|---------------------- |------------:|----------:|----------:|-------------:|------------:|------------:|-------:|-------:|----------:|
|         BinaryToBytes |  4,734.7 ns |  64.93 ns |  50.69 ns |  4,589.41 ns |  4,786.6 ns |  4,745.5 ns | 0.8316 | 0.0153 |    6992 B |
|   DataContractToBytes |  1,155.8 ns |  11.84 ns |  11.08 ns |  1,140.52 ns |  1,172.6 ns |  1,158.9 ns | 0.4406 | 0.0019 |    3688 B |
|            JilToBytes |    268.8 ns |   5.28 ns |   8.07 ns |    245.17 ns |    278.9 ns |    270.4 ns | 0.1278 |      - |    1072 B |
|    MessagePackToBytes |    126.8 ns |   2.42 ns |   2.15 ns |    124.05 ns |    130.4 ns |    126.8 ns | 0.0095 |      - |      80 B |
|        MsgPackToBytes |    351.8 ns |   6.65 ns |   6.53 ns |    341.36 ns |    362.8 ns |    350.9 ns | 0.0935 |      - |     784 B |
| NewtonsoftJsonToBytes |    757.5 ns |  14.78 ns |  20.72 ns |    698.87 ns |    785.5 ns |    759.6 ns | 0.2251 |      - |    1888 B |
|       ProtobufToBytes |    320.8 ns |   4.61 ns |   4.31 ns |    314.16 ns |    327.3 ns |    322.3 ns | 0.0486 |      - |     408 B |
|      SharpYamlToBytes | 47,014.3 ns | 177.37 ns | 157.24 ns | 46,752.85 ns | 47,276.8 ns | 46,985.2 ns | 3.4180 | 0.1221 |   28655 B |
| SystemTextJsonToBytes |    311.6 ns |   4.79 ns |   4.25 ns |    308.36 ns |    320.0 ns |    309.8 ns | 0.0172 |      - |     144 B |
|       Utf8JsonToBytes |    207.5 ns |   2.98 ns |   2.64 ns |    202.39 ns |    212.1 ns |    207.3 ns | 0.0181 |      - |     152 B |
|            XmlToBytes |  5,685.9 ns | 104.95 ns |  93.04 ns |  5,406.02 ns |  5,804.8 ns |  5,688.4 ns | 1.3199 | 0.0381 |   11049 B |
|     YamlDotNetToBytes | 16,116.4 ns | 269.44 ns | 252.04 ns | 15,673.65 ns | 16,493.5 ns | 16,187.3 ns | 1.5564 |      - |   13201 B |
|  ZeroFormatterToBytes |    106.0 ns |   2.11 ns |   3.97 ns |     94.12 ns |    113.8 ns |    106.2 ns | 0.1415 | 0.0002 |    1184 B |

## From Bytes

|                  Method |         Mean |        Error |       StdDev |       Median |          Min |          Max |   Gen0 |   Gen1 | Allocated |
|------------------------ |-------------:|-------------:|-------------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromBytes |  6,514.54 ns |    73.281 ns |    68.547 ns |  6,492.17 ns |  6,366.98 ns |  6,602.93 ns | 1.1749 | 0.0305 |    9856 B |
|   DataContractFromBytes |  3,372.40 ns |    67.061 ns |    87.199 ns |  3,373.61 ns |  3,046.68 ns |  3,484.73 ns | 1.5259 | 0.0458 |   12784 B |
|            JilFromBytes |    340.02 ns |     6.588 ns |     6.163 ns |    339.65 ns |    328.64 ns |    348.72 ns | 0.0553 |      - |     464 B |
|    MessagePackFromBytes |    221.92 ns |     2.805 ns |     2.624 ns |    221.77 ns |    217.36 ns |    226.50 ns | 0.0105 |      - |      88 B |
|        MsgPackFromBytes |    642.57 ns |    12.023 ns |    11.809 ns |    640.56 ns |    624.20 ns |    666.80 ns | 0.0925 |      - |     776 B |
| NewtonsoftJsonFromBytes |  1,575.24 ns |    30.524 ns |    35.151 ns |  1,572.30 ns |  1,463.72 ns |  1,633.45 ns | 0.3757 |      - |    3152 B |
|       ProtobufFromBytes |    362.74 ns |     5.058 ns |     4.731 ns |    363.03 ns |    354.76 ns |    370.34 ns | 0.0210 |      - |     176 B |
|      SharpYamlFromBytes | 55,807.57 ns | 1,089.584 ns | 2,589.512 ns | 54,796.64 ns | 52,655.88 ns | 63,333.26 ns | 3.6621 | 0.1831 |   30780 B |
| SystemTextJsonFromBytes |    425.57 ns |     7.848 ns |     7.341 ns |    426.44 ns |    415.26 ns |    440.20 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromBytes |    350.83 ns |     3.171 ns |     2.966 ns |    351.35 ns |    346.78 ns |    354.82 ns | 0.0105 |      - |      88 B |
|            XmlFromBytes |  7,783.34 ns |   119.293 ns |   111.587 ns |  7,816.96 ns |  7,605.92 ns |  7,919.57 ns | 1.0834 | 0.0153 |    9089 B |
|     YamlDotNetFromBytes | 12,736.91 ns |   225.718 ns |   200.093 ns | 12,760.23 ns | 12,215.63 ns | 13,043.91 ns | 1.7242 | 0.0458 |   14440 B |
|  ZeroFormatterFromBytes |     56.75 ns |     1.136 ns |     1.115 ns |     56.88 ns |     53.99 ns |     58.76 ns | 0.0334 |      - |     280 B |

## To Stream

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|         BinaryToStream |  4,404.2 ns |  86.58 ns |  76.75 ns |  4,308.4 ns |  4,527.4 ns |  4,410.9 ns | 0.7782 | 0.0076 |    6528 B |
|   DataContractToStream |  1,070.5 ns |  13.07 ns |  11.59 ns |  1,053.5 ns |  1,095.4 ns |  1,068.2 ns | 0.3700 |      - |    3096 B |
|            JilToStream |    304.8 ns |   5.79 ns |   4.52 ns |    299.5 ns |    317.3 ns |    303.7 ns | 0.1683 |      - |    1408 B |
|    MessagePackToStream |    277.1 ns |   5.52 ns |   5.90 ns |    262.5 ns |    284.7 ns |    278.5 ns | 0.0410 |      - |     344 B |
|        MsgPackToStream |    332.3 ns |   6.43 ns |   9.43 ns |    309.4 ns |    347.4 ns |    331.9 ns | 0.0858 |      - |     720 B |
| NewtonsoftJsonToStream |    815.9 ns |  15.79 ns |  21.62 ns |    753.4 ns |    841.9 ns |    819.8 ns | 0.2661 | 0.0010 |    2232 B |
|       ProtobufToStream |    275.0 ns |   5.13 ns |   4.55 ns |    266.2 ns |    278.0 ns |    277.1 ns | 0.0410 |      - |     344 B |
|      SharpYamlToStream | 46,358.2 ns | 384.51 ns | 340.86 ns | 45,719.0 ns | 46,985.3 ns | 46,308.5 ns | 3.3569 | 0.1221 |   28503 B |
| SystemTextJsonToStream |    334.6 ns |   6.70 ns |   6.27 ns |    329.5 ns |    351.2 ns |    331.2 ns | 0.0591 |      - |     496 B |
|       Utf8JsonToStream |    252.4 ns |   4.47 ns |   4.18 ns |    243.7 ns |    257.8 ns |    252.8 ns | 0.0410 |      - |     344 B |
|            XmlToStream |  5,543.0 ns | 107.45 ns | 105.53 ns |  5,195.0 ns |  5,673.2 ns |  5,550.3 ns | 1.2741 | 0.0153 |   10697 B |
|     YamlDotNetToStream | 16,159.6 ns | 219.15 ns | 171.10 ns | 15,868.9 ns | 16,342.3 ns | 16,227.7 ns | 1.5564 |      - |   13265 B |
|  ZeroFormatterToStream |    159.6 ns |   3.16 ns |   5.93 ns |    141.6 ns |    170.4 ns |    159.4 ns | 0.1826 | 0.0005 |    1528 B |

## From Stream

|                   Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromStream |  6,767.72 ns |  75.362 ns |  70.494 ns |  6,690.40 ns |  6,896.62 ns |  6,741.96 ns | 1.1673 | 0.0305 |    9792 B |
|   DataContractFromStream |  3,093.56 ns |  35.399 ns |  29.560 ns |  3,036.47 ns |  3,147.02 ns |  3,093.93 ns | 1.5182 | 0.0458 |   12720 B |
|            JilFromStream |    362.22 ns |   7.238 ns |   7.433 ns |    352.85 ns |    375.11 ns |    362.86 ns | 0.0734 |      - |     616 B |
|    MessagePackFromStream |    253.25 ns |   4.776 ns |   4.467 ns |    247.48 ns |    261.59 ns |    252.40 ns | 0.0105 |      - |      88 B |
|        MsgPackFromStream |    595.73 ns |   6.842 ns |   6.400 ns |    586.86 ns |    607.56 ns |    593.61 ns | 0.0849 |      - |     712 B |
| NewtonsoftJsonFromStream |  1,545.87 ns |  26.908 ns |  23.854 ns |  1,500.31 ns |  1,588.88 ns |  1,542.55 ns | 0.3967 | 0.0038 |    3320 B |
|       ProtobufFromStream |    268.03 ns |   4.857 ns |   4.543 ns |    262.88 ns |    274.58 ns |    265.70 ns | 0.0105 |      - |      88 B |
|      SharpYamlFromStream |  1,117.84 ns |  22.371 ns |  34.163 ns |  1,003.10 ns |  1,182.64 ns |  1,117.51 ns | 0.7648 | 0.0038 |    6408 B |
| SystemTextJsonFromStream |    530.19 ns |   7.345 ns |   6.511 ns |    519.88 ns |    539.80 ns |    530.63 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromStream |    374.28 ns |   5.881 ns |   5.501 ns |    367.13 ns |    382.68 ns |    375.81 ns | 0.0105 |      - |      88 B |
|            XmlFromStream |  7,806.16 ns | 102.136 ns |  95.538 ns |  7,612.10 ns |  7,950.43 ns |  7,803.55 ns | 1.0681 | 0.0153 |    9025 B |
|     YamlDotNetFromStream | 12,963.18 ns | 204.927 ns | 191.689 ns | 12,481.42 ns | 13,268.38 ns | 12,946.46 ns | 1.7395 | 0.0458 |   14592 B |
|  ZeroFormatterFromStream |     65.34 ns |   0.920 ns |   1.704 ns |     62.71 ns |     70.65 ns |     64.86 ns | 0.0334 |      - |     280 B |
