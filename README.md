# Zaabee.Serialization

---

[![Build Status](https://dev.azure.com/Zaabee/Zaabee.Serialization/_apis/build/status/Mutuduxf.Zaabee.Serialization?branchName=master)](https://dev.azure.com/Zaabee/Zaabee.Serialization/_build/latest?definitionId=1&branchName=master)

Provide an easy way to use serializations. It is also the serializer provider for all Zaabee technology stacks like configuration, cache, queue, rpc, etc.

## Why use Zaabee.Serialization?

There are many different serializers in the world, they have different features and limitations. This project allows you to use difference serializers in the same way. Also it set nullable and default value for all serializers.

Serializers can be divided into two categories:

- Binary serializers
  - MemoryPack
  - MessagePack
  - MsgPack.Cli
  - protobuf-net
  - ZeroFormatter
- Text serializers
  - Json
    - Jil
    - Newtonsoft.Json
    - SpanJson
    - System.Text.Json
    - Utf8Json
  - Xml
    - XmlSerializer
    - DataContractSerializer
  - Yaml
    - SharpYaml
    - YamlDotNet
  - Ini
    - ini-parser-netstandard
  - Toml
    - Tomlet
    - Tomlyn
    - Tommy

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
    - async
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
  Implement Zaabee.Serialization.Abstractions, The Zaabee technology stacks use this library to serialize and deserialize.
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
PM> Install-Package Zaabee.DataContractSerializer
PM> Install-Package Zaabee.Jil
PM> Install-Package Zaabee.MemoryPack
PM> Install-Package Zaabee.MessagePack
PM> Install-Package Zaabee.MsgPack
PM> Install-Package Zaabee.NewtonsoftJson
PM> Install-Package Zaabee.Utf8Json
PM> Install-Package Zaabee.Protobuf
PM> Install-Package Zaabee.SharpYaml
PM> Install-Package Zaabee.SpanJson
PM> Install-Package Zaabee.SystemTextJson
PM> Install-Package Zaabee.Xml
PM> Install-Package Zaabee.YamlDotNet
PM> Install-Package Zaabee.ZeroFormatter
```

### Zaabee.DataContractSerializer

Base by System.Runtime.Serialization.DataContractSerializer, serializes and deserializes an instance of a type into an XML stream or document using a supplied data contract.

### Zaabee.Jil

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

### Zaabee.MemoryPack

Zero encoding extreme performance binary serializer for C# and Unity.

### Zaabee.MessagePack

The extremely fast MessagePack serializer for C#. It is 10x faster than MsgPack-Cli and outperforms other C# serializers. MessagePack for C# also ships with built-in support for LZ4 compression - an extremely fast compression algorithm. Performance is important, particularly in applications like games, distributed computing, microservices, or data caches.

### Zaabee.MsgPack

MessagePack implementation for Common Language Infrastructure / msgpack.org[C#]

### Zaabee.NewtonsoftJson

Json.NET is a popular high-performance JSON framework for .NET [https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)

### Zaabee.Utf8Json

Definitely Fastest and Zero Allocation JSON Serializer for C#(NET, .NET Core, Unity, Xamarin).

### Zaabee.Protobuf

protobuf-net is a contract based serializer for .NET code, that happens to write data in the "protocol buffers" serialization format engineered by Google. The API, however, is very different to Google's, and follows typical .NET patterns (it is broadly comparable, in usage, to XmlSerializer, DataContractSerializer, etc). It should work for most .NET languages that write standard types and can use attributes.

### Zaabee.SharpYaml

SharpYaml is a .NET library that provides a YAML parser and serialization engine for .NET objects, compatible with CoreCLR.

### Zaabee.SpanJson

SpanJson is a JSON serializer for .NET Core 6.0+.

### Zaabee.SystemTextJson

The System.Text.Json namespace provides high-performance, low-allocating, and standards-compliant capabilities to process JavaScript Object Notation (JSON), which includes serializing objects to JSON text and deserializing JSON text to objects, with UTF-8 support built-in. It also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM) for random access of the JSON elements within a structured view of the data.

### Zaabee.Xml

Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.

### Zaabee.YamlDotNet

YamlDotNet is a YAML library for netstandard and other .NET runtimes.

YamlDotNet provides low level parsing and emitting of YAML as well as a high level object model similar to XmlDocument. A serialization library is also included that allows to read and write objects from and to YAML streams.

### Zaabee.ZeroFormatter

Fastest C# Serializer and Infinitely Fast Deserializer for .NET, .NET Core and Unity.

## Benchmark

```ini
BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1105/22H2/2022Update/SunValley2)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-preview.2.23157.25
  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
```

IterationCount=1000  RunStrategy=Monitoring

## To Text

|               Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|--------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractToText |  1,356.3 ns |  26.90 ns |  27.62 ns |  1,316.3 ns |  1,400.7 ns |  1,361.8 ns | 0.5779 | 0.0019 |    4840 B |
|            JilToText |    241.5 ns |   4.74 ns |   7.65 ns |    219.4 ns |    250.0 ns |    241.6 ns | 0.1099 |      - |     920 B |
| NewtonsoftJsonToText |    665.5 ns |  13.23 ns |  20.61 ns |    609.3 ns |    696.7 ns |    670.1 ns | 0.2079 |      - |    1744 B |
|      SharpYamlToText | 48,402.4 ns | 613.94 ns | 544.24 ns | 47,565.4 ns | 49,210.7 ns | 48,490.8 ns | 3.1738 | 0.1221 |   26998 B |
|       SpanJsonToText |    191.5 ns |   1.97 ns |   1.75 ns |    189.4 ns |    195.3 ns |    191.3 ns | 0.0505 |      - |     424 B |
| SystemTextJsonToText |    329.1 ns |   5.23 ns |   4.89 ns |    322.4 ns |    338.2 ns |    327.8 ns | 0.0305 |      - |     256 B |
|       Utf8JsonToText |    249.6 ns |   4.16 ns |   3.69 ns |    243.6 ns |    255.8 ns |    249.1 ns | 0.0324 |      - |     272 B |
|            XmlToText |  6,646.9 ns |  98.22 ns |  82.02 ns |  6,488.4 ns |  6,776.7 ns |  6,669.6 ns | 1.4191 | 0.0381 |   11905 B |
|     YamlDotNetToText | 17,063.3 ns | 158.51 ns | 132.37 ns | 16,856.4 ns | 17,277.5 ns | 17,019.1 ns | 1.6785 |      - |   14265 B |

## From Text

|                 Method |        Mean |       Error |      StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|------------:|------------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractFromText |  3,483.3 ns |    66.38 ns |    76.44 ns |  3,325.5 ns |  3,620.9 ns |  3,458.8 ns | 1.5984 | 0.0496 |   13376 B |
|            JilFromText |    305.7 ns |     4.99 ns |     4.90 ns |    301.0 ns |    317.9 ns |    303.6 ns | 0.0219 |      - |     184 B |
| NewtonsoftJsonFromText |  1,470.7 ns |    26.79 ns |    40.92 ns |  1,390.2 ns |  1,550.0 ns |  1,478.5 ns | 0.3452 | 0.0019 |    2896 B |
|      SharpYamlFromText | 52,973.8 ns | 1,044.49 ns | 1,072.61 ns | 51,673.2 ns | 54,587.1 ns | 52,851.3 ns | 3.2959 | 0.1221 |   27636 B |
|       SpanJsonFromText |    240.6 ns |     4.30 ns |     4.02 ns |    235.1 ns |    248.7 ns |    240.4 ns | 0.0286 |      - |     240 B |
| SystemTextJsonFromText |    492.5 ns |     9.53 ns |    11.70 ns |    476.6 ns |    512.7 ns |    491.2 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromText |    447.2 ns |     7.38 ns |     6.90 ns |    432.7 ns |    455.8 ns |    447.2 ns | 0.0286 |      - |     240 B |
|            XmlFromText |  9,095.2 ns |   176.69 ns |   203.48 ns |  8,727.7 ns |  9,367.4 ns |  9,131.3 ns | 1.1444 | 0.0153 |    9617 B |
|     YamlDotNetFromText | 13,669.6 ns |   265.97 ns |   284.59 ns | 13,165.2 ns | 14,076.8 ns | 13,678.1 ns | 1.6937 | 0.0458 |   14224 B |

## To Bytes

|                Method |         Mean |      Error |       StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|---------------------- |-------------:|-----------:|-------------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|   DataContractToBytes |  1,252.09 ns |  23.989 ns |    25.668 ns |  1,210.03 ns |  1,298.81 ns |  1,252.81 ns | 0.4406 | 0.0019 |    3688 B |
|            JilToBytes |    302.13 ns |   5.805 ns |     7.549 ns |    286.12 ns |    317.62 ns |    301.55 ns | 0.1278 |      - |    1072 B |
|     MemoryPackToBytes |     78.66 ns |   1.410 ns |     1.319 ns |     76.82 ns |     81.54 ns |     78.57 ns | 0.0086 |      - |      72 B |
|    MessagePackToBytes |    136.71 ns |   2.639 ns |     3.338 ns |    130.28 ns |    141.40 ns |    137.58 ns | 0.0095 |      - |      80 B |
|        MsgPackToBytes |    397.14 ns |   7.129 ns |     8.755 ns |    376.47 ns |    411.03 ns |    396.39 ns | 0.0935 |      - |     784 B |
| NewtonsoftJsonToBytes |    881.27 ns |  17.395 ns |    20.708 ns |    836.31 ns |    913.02 ns |    885.60 ns | 0.2251 |      - |    1888 B |
|       ProtobufToBytes |    332.72 ns |   5.909 ns |     8.283 ns |    319.62 ns |    353.67 ns |    330.75 ns | 0.0486 |      - |     408 B |
|      SharpYamlToBytes | 50,819.16 ns | 963.966 ns | 1,183.837 ns | 48,815.15 ns | 52,846.36 ns | 51,034.31 ns | 3.4180 | 0.1221 |   28887 B |
|       SpanJsonToBytes |    153.18 ns |   3.040 ns |     3.379 ns |    148.26 ns |    158.63 ns |    153.38 ns | 0.0181 |      - |     152 B |
| SystemTextJsonToBytes |    320.42 ns |   6.391 ns |     8.532 ns |    307.81 ns |    339.21 ns |    321.77 ns | 0.0172 |      - |     144 B |
|       Utf8JsonToBytes |    222.18 ns |   4.408 ns |     4.329 ns |    215.00 ns |    227.77 ns |    222.78 ns | 0.0181 |      - |     152 B |
|            XmlToBytes |  6,603.77 ns |  78.620 ns |    73.541 ns |  6,417.23 ns |  6,703.50 ns |  6,603.53 ns | 1.3351 | 0.0381 |   11225 B |
|     YamlDotNetToBytes | 16,939.23 ns | 107.499 ns |    89.767 ns | 16,808.07 ns | 17,092.06 ns | 16,947.22 ns | 1.7090 |      - |   14417 B |
|  ZeroFormatterToBytes |    115.55 ns |   2.304 ns |     4.909 ns |     98.23 ns |    124.80 ns |    116.68 ns | 0.1415 | 0.0002 |    1184 B |

## From Bytes

|                  Method |         Mean |        Error |       StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------ |-------------:|-------------:|-------------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|   DataContractFromBytes |  3,363.75 ns |    65.633 ns |    67.400 ns |  3,167.38 ns |  3,429.84 ns |  3,386.18 ns | 1.5259 | 0.0458 |   12784 B |
|            JilFromBytes |    347.16 ns |     6.752 ns |     9.898 ns |    332.28 ns |    365.02 ns |    347.02 ns | 0.0553 |      - |     464 B |
|     MemoryPackFromBytes |     67.12 ns |     1.002 ns |     0.937 ns |     64.73 ns |     68.27 ns |     67.50 ns | 0.0105 |      - |      88 B |
|    MessagePackFromBytes |    232.88 ns |     3.171 ns |     2.648 ns |    228.92 ns |    238.16 ns |    232.76 ns | 0.0105 |      - |      88 B |
|        MsgPackFromBytes |    683.06 ns |    13.312 ns |    12.452 ns |    671.06 ns |    706.36 ns |    679.41 ns | 0.0925 |      - |     776 B |
| NewtonsoftJsonFromBytes |  1,656.22 ns |    12.590 ns |     9.830 ns |  1,641.80 ns |  1,669.98 ns |  1,657.28 ns | 0.3796 |      - |    3176 B |
|       ProtobufFromBytes |    391.11 ns |     3.745 ns |     3.503 ns |    385.72 ns |    396.75 ns |    391.38 ns | 0.0210 |      - |     176 B |
|      SharpYamlFromBytes | 58,250.34 ns | 1,048.033 ns | 1,779.639 ns | 55,354.25 ns | 62,160.92 ns | 58,125.42 ns | 3.6621 | 0.1831 |   31012 B |
|       SpanJsonFromBytes |    175.81 ns |     3.483 ns |     4.529 ns |    170.45 ns |    184.67 ns |    175.69 ns | 0.0105 |      - |      88 B |
| SystemTextJsonFromBytes |    441.51 ns |     8.834 ns |    10.173 ns |    426.25 ns |    455.91 ns |    440.80 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromBytes |    367.67 ns |     4.327 ns |     3.836 ns |    360.96 ns |    372.39 ns |    368.79 ns | 0.0105 |      - |      88 B |
|            XmlFromBytes |  8,542.04 ns |    50.415 ns |    44.691 ns |  8,494.08 ns |  8,628.21 ns |  8,529.94 ns | 1.0986 | 0.0153 |    9265 B |
|     YamlDotNetFromBytes | 13,186.13 ns |   262.235 ns |   392.501 ns | 12,548.42 ns | 13,986.78 ns | 13,232.63 ns | 1.7242 | 0.0458 |   14480 B |
|  ZeroFormatterFromBytes |     56.61 ns |     1.147 ns |     2.237 ns |     52.75 ns |     60.78 ns |     56.38 ns | 0.0334 |      - |     280 B |

## To Stream

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractToStream |  1,096.6 ns |   8.77 ns |   7.77 ns |  1,087.3 ns |  1,109.1 ns |  1,096.1 ns | 0.3700 |      - |    3096 B |
|            JilToStream |    326.7 ns |   6.40 ns |  10.51 ns |    295.5 ns |    345.3 ns |    329.4 ns | 0.1693 |      - |    1416 B |
|     MemoryPackToStream |    127.6 ns |   2.56 ns |   3.75 ns |    113.2 ns |    133.2 ns |    127.6 ns | 0.0782 |      - |     656 B |
|    MessagePackToStream |    268.6 ns |   3.44 ns |   2.69 ns |    260.7 ns |    270.5 ns |    269.3 ns | 0.0410 |      - |     344 B |
|        MsgPackToStream |    349.2 ns |   6.78 ns |   8.33 ns |    325.9 ns |    358.9 ns |    351.8 ns | 0.0858 |      - |     720 B |
| NewtonsoftJsonToStream |    831.8 ns |  16.63 ns |  26.86 ns |    756.8 ns |    872.3 ns |    830.5 ns | 0.2661 | 0.0010 |    2232 B |
|       ProtobufToStream |    288.8 ns |   5.42 ns |   5.80 ns |    274.9 ns |    297.0 ns |    287.8 ns | 0.0410 |      - |     344 B |
|      SharpYamlToStream | 50,014.5 ns | 909.70 ns | 806.43 ns | 48,295.0 ns | 51,256.8 ns | 49,756.7 ns | 3.4180 | 0.1221 |   28735 B |
|       SpanJsonToStream |    193.8 ns |   3.79 ns |   6.23 ns |    177.0 ns |    202.4 ns |    193.6 ns | 0.0591 |      - |     496 B |
| SystemTextJsonToStream |    366.8 ns |   7.32 ns |  10.95 ns |    345.6 ns |    383.1 ns |    366.6 ns | 0.0591 |      - |     496 B |
|       Utf8JsonToStream |    243.9 ns |   1.97 ns |   1.65 ns |    241.4 ns |    246.6 ns |    244.1 ns | 0.0410 |      - |     344 B |
|            XmlToStream |  6,286.8 ns | 107.47 ns |  95.27 ns |  6,027.4 ns |  6,437.6 ns |  6,292.4 ns | 1.2970 | 0.0381 |   10873 B |
|     YamlDotNetToStream | 16,983.0 ns | 332.82 ns | 341.78 ns | 16,549.1 ns | 17,552.2 ns | 16,772.9 ns | 1.7090 |      - |   14481 B |
|  ZeroFormatterToStream |    162.9 ns |   3.23 ns |   6.06 ns |    142.1 ns |    172.5 ns |    163.4 ns | 0.1826 | 0.0005 |    1528 B |

## From Stream

|                   Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|   DataContractFromStream |  3,524.49 ns |  90.853 ns | 263.581 ns |  3,097.38 ns |  4,245.22 ns |  3,472.83 ns | 1.5182 | 0.0458 |   12720 B |
|            JilFromStream |    409.97 ns |   8.046 ns |   9.265 ns |    398.62 ns |    432.47 ns |    407.50 ns | 0.0734 |      - |     616 B |
|     MemoryPackFromStream |     91.12 ns |   1.854 ns |   2.345 ns |     87.44 ns |     96.13 ns |     90.82 ns | 0.0191 |      - |     160 B |
|    MessagePackFromStream |    264.43 ns |   5.217 ns |   6.597 ns |    253.77 ns |    277.11 ns |    264.68 ns | 0.0105 |      - |      88 B |
|        MsgPackFromStream |    611.66 ns |   9.817 ns |   9.182 ns |    596.85 ns |    630.17 ns |    613.55 ns | 0.0849 |      - |     712 B |
| NewtonsoftJsonFromStream |  1,838.93 ns |  34.543 ns |  69.779 ns |  1,720.80 ns |  2,058.19 ns |  1,842.04 ns | 0.3967 | 0.0038 |    3320 B |
|       ProtobufFromStream |    297.08 ns |   5.828 ns |   8.723 ns |    286.85 ns |    313.73 ns |    297.95 ns | 0.0105 |      - |      88 B |
|      SharpYamlFromStream |  1,218.18 ns |  24.284 ns |  64.397 ns |  1,098.36 ns |  1,373.33 ns |  1,208.58 ns | 0.7648 | 0.0038 |    6408 B |
|       SpanJsonFromStream |    258.08 ns |   5.111 ns |   8.817 ns |    241.50 ns |    276.52 ns |    258.27 ns | 0.0286 |      - |     240 B |
| SystemTextJsonFromStream |    585.35 ns |   9.731 ns |   7.597 ns |    575.30 ns |    600.58 ns |    583.68 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromStream |    417.24 ns |   8.013 ns |  10.968 ns |    402.27 ns |    442.29 ns |    415.56 ns | 0.0105 |      - |      88 B |
|            XmlFromStream |  9,073.17 ns | 176.943 ns | 275.479 ns |  8,706.75 ns |  9,841.82 ns |  9,006.50 ns | 1.0986 | 0.0153 |    9193 B |
|     YamlDotNetFromStream | 13,062.25 ns | 256.301 ns | 350.828 ns | 12,584.22 ns | 13,710.07 ns | 13,078.77 ns | 1.7395 | 0.0458 |   14640 B |
|  ZeroFormatterFromStream |     68.59 ns |   1.383 ns |   1.359 ns |     66.99 ns |     71.86 ns |     68.16 ns | 0.0334 |      - |     280 B |
