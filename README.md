# Aoxe.Serialization

---

[![Build Status](https://dev.azure.com/Aoxe/Aoxe.Serialization/_apis/build/status/Mutuduxf.Aoxe.Serialization?branchName=master)](https://dev.azure.com/Aoxe/Aoxe.Serialization/_build/latest?definitionId=1&branchName=master)

Provide an easy way to use serializations. It is also the serializer provider for all Aoxe technology stacks like configuration, cache, queue, rpc, etc.

- [1. Why use Aoxe.Serialization?](#1-why-use-Aoxeserialization)
- [2. Explain](#2-explain)
- [3. Getting Started](#3-getting-started)
  - [3.1. Aoxe.DataContractSerializer](#31-Aoxedatacontractserializer)
  - [3.2. Aoxe.Jil](#32-Aoxejil)
  - [3.3. Aoxe.MemoryPack](#33-Aoxememorypack)
  - [3.4. Aoxe.MessagePack](#34-Aoxemessagepack)
  - [3.5. Aoxe.MsgPack](#35-Aoxemsgpack)
  - [3.6. Aoxe.NetJson](#36-Aoxenetjson)
  - [3.7. Aoxe.NewtonsoftJson](#37-Aoxenewtonsoftjson)
  - [3.8. Aoxe.Utf8Json](#38-Aoxeutf8json)
  - [3.9. Aoxe.Protobuf](#39-Aoxeprotobuf)
  - [3.10. Aoxe.SharpYaml](#310-Aoxesharpyaml)
  - [3.11. Aoxe.SpanJson](#311-Aoxespanjson)
  - [3.12. Aoxe.SystemTextJson](#312-Aoxesystemtextjson)
  - [3.13. Aoxe.Xml](#313-Aoxexml)
  - [3.14. Aoxe.YamlDotNet](#314-Aoxeyamldotnet)
  - [3.15. Aoxe.ZeroFormatter](#315-Aoxezeroformatter)
- [4. Benchmark](#4-benchmark)
  - [4.1. Stream](#41-stream)
    - [4.1.1. To Stream](#411-to-stream)
    - [4.1.2. From Stream](#412-from-stream)
  - [4.2. Bytes](#42-bytes)
    - [4.2.1. To Bytes](#421-to-bytes)
    - [4.2.2. From Bytes](#422-from-bytes)
  - [4.3. Text](#43-text)
    - [4.3.1. Json](#431-json)
      - [4.3.1.1. To Json](#4311-to-json)
      - [4.3.1.2. From Json](#4312-from-json)
    - [4.3.2. Xml](#432-xml)
      - [4.3.2.1. To Xml](#4321-to-xml)
      - [4.3.2.2. From Xml](#4322-from-xml)
    - [4.3.3. Yaml](#433-yaml)
      - [4.3.3.1. To Yaml](#4331-to-yaml)
      - [4.3.3.2. From Yaml](#4332-from-yaml)
    - [4.3.4. Ini](#434-ini)
      - [4.3.4.1. To Ini](#4341-to-ini)
      - [4.3.4.2. From Ini](#4342-from-ini)
    - [4.3.5. Toml](#435-toml)
      - [4.3.5.1. To Toml](#4351-to-toml)
      - [4.3.5.2. From Toml](#4352-from-toml)

## 1. Why use Aoxe.Serialization?

There are many different serializers in the world, they have different features and limitations. This project allows you to use difference serializers in the same way. Also it set nullable and default value for all serializers.

Serializers can be divided into two categories (binary and text):

- Binary serializers
  - MemoryPack
  - MessagePack
  - MsgPack.Cli
  - protobuf-net
  - ZeroFormatter
- Text serializers
  - Json
    - Jil
    - NetJson
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

Though some serializers does not support stream or bytes, the Aoxe serializers will supply the lack. And the text serializers will support text on this base.

## 2. Explain

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
    - Ini
      - string ToIni\<TValue\>(TValue? value)
      - string ToIni(Type type, object? value)
      - TValue? FromIni\<TValue\>(string? xml)
      - object? FromIni(Type type, string? xml)
    - Toml
      - string ToToml\<TValue\>(TValue? value)
      - string ToToml(Type type, object? value)
      - TValue? FromToml\<TValue\>(string? xml)
      - object? FromToml(Type type, string? xml)
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
  Implement Aoxe.Serialization.Abstractions, The Aoxe technology stacks use this library to serialize and deserialize.
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

## 3. Getting Started

Use nuget to install the package which you want.

```shell
PM> Install-Package Aoxe.DataContractSerializer
PM> Install-Package Aoxe.Jil
PM> Install-Package Aoxe.MemoryPack
PM> Install-Package Aoxe.MessagePack
PM> Install-Package Aoxe.MsgPack
PM> Install-Package Aoxe.NewtonsoftJson
PM> Install-Package Aoxe.NetJson
PM> Install-Package Aoxe.Utf8Json
PM> Install-Package Aoxe.Protobuf
PM> Install-Package Aoxe.SharpYaml
PM> Install-Package Aoxe.SpanJson
PM> Install-Package Aoxe.SystemTextJson
PM> Install-Package Aoxe.Xml
PM> Install-Package Aoxe.YamlDotNet
PM> Install-Package Aoxe.ZeroFormatter
```

### 3.1. Aoxe.DataContractSerializer

Base by System.Runtime.Serialization.DataContractSerializer, serializes and deserializes an instance of a type into an XML stream or document using a supplied data contract.

### 3.2. Aoxe.Jil

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

### 3.3. Aoxe.MemoryPack

Zero encoding extreme performance binary serializer for C# and Unity.

### 3.4. Aoxe.MessagePack

The extremely fast MessagePack serializer for C#. It is 10x faster than MsgPack-Cli and outperforms other C# serializers. MessagePack for C# also ships with built-in support for LZ4 compression - an extremely fast compression algorithm. Performance is important, particularly in applications like games, distributed computing, microservices, or data caches.

### 3.5. Aoxe.MsgPack

MessagePack implementation for Common Language Infrastructure / msgpack.org[C#]

### 3.6. Aoxe.NetJson

Faster than Any Binary?

### 3.7. Aoxe.NewtonsoftJson

Json.NET is a popular high-performance JSON framework for .NET [https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)

### 3.8. Aoxe.Utf8Json

Definitely Fastest and Zero Allocation JSON Serializer for C#(NET, .NET Core, Unity, Xamarin).

### 3.9. Aoxe.Protobuf

protobuf-net is a contract based serializer for .NET code, that happens to write data in the "protocol buffers" serialization format engineered by Google. The API, however, is very different to Google's, and follows typical .NET patterns (it is broadly comparable, in usage, to XmlSerializer, DataContractSerializer, etc). It should work for most .NET languages that write standard types and can use attributes.

### 3.10. Aoxe.SharpYaml

SharpYaml is a .NET library that provides a YAML parser and serialization engine for .NET objects, compatible with CoreCLR.

### 3.11. Aoxe.SpanJson

SpanJson is a JSON serializer for .NET Core 6.0+.

### 3.12. Aoxe.SystemTextJson

The System.Text.Json namespace provides high-performance, low-allocating, and standards-compliant capabilities to process JavaScript Object Notation (JSON), which includes serializing objects to JSON text and deserializing JSON text to objects, with UTF-8 support built-in. It also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM) for random access of the JSON elements within a structured view of the data.

### 3.13. Aoxe.Xml

Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.

### 3.14. Aoxe.YamlDotNet

YamlDotNet is a YAML library for netstandard and other .NET runtimes.

YamlDotNet provides low level parsing and emitting of YAML as well as a high level object model similar to XmlDocument. A serialization library is also included that allows to read and write objects from and to YAML streams.

### 3.15. Aoxe.ZeroFormatter

Fastest C# Serializer and Infinitely Fast Deserializer for .NET, .NET Core and Unity.

## 4. Benchmark

```ini
BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.1105/22H2/2022Update/SunValley2)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100-rc.2.23502.2
[Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
DefaultJob : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
```

IterationCount=1000  RunStrategy=Monitoring

### 4.1. Stream

#### 4.1.1. To Stream

| Method                 | Mean         | Error      | StdDev     | Median       | Min          | Max          | Gen0   | Gen1   | Allocated |
|----------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
| DataContractToStream   |    614.77 ns |  11.623 ns |  21.831 ns |    607.04 ns |    579.48 ns |    657.88 ns | 0.2346 | 0.0010 |    1968 B |
| JilToStream            |    160.89 ns |   3.197 ns |   7.902 ns |    161.74 ns |    149.28 ns |    177.27 ns | 0.1118 | 0.0002 |     936 B |
| MemoryPackToStream     |    106.06 ns |   2.157 ns |   4.596 ns |    104.56 ns |    100.21 ns |    114.06 ns | 0.0783 |      - |     656 B |
| MessagePackToStream    |    180.11 ns |   3.409 ns |   3.022 ns |    180.67 ns |    173.95 ns |    184.10 ns | 0.0410 |      - |     344 B |
| MsgPackToStream        |    138.97 ns |   2.759 ns |   6.973 ns |    136.65 ns |    130.31 ns |    160.17 ns | 0.0658 |      - |     552 B |
| NetJsonToStream        |    162.19 ns |   3.093 ns |   3.177 ns |    162.87 ns |    152.39 ns |    166.34 ns | 0.0668 |      - |     560 B |
| NewtonsoftJsonToStream |    411.07 ns |   8.218 ns |  19.531 ns |    402.60 ns |    384.70 ns |    449.70 ns | 0.2179 | 0.0005 |    1824 B |
| ProtobufToStream       |    171.38 ns |   3.157 ns |   2.636 ns |    171.49 ns |    165.16 ns |    175.44 ns | 0.0410 |      - |     344 B |
| SharpYamlToStream      | 23,422.26 ns | 305.706 ns | 271.001 ns | 23,397.31 ns | 22,879.41 ns | 23,955.76 ns | 2.0752 |      - |   18340 B |
| SpanJsonToStream       |    107.76 ns |   2.113 ns |   2.821 ns |    108.34 ns |    100.68 ns |    110.88 ns | 0.0488 |      - |     408 B |
| SystemTextJsonToStream |    177.22 ns |   3.562 ns |   6.690 ns |    177.42 ns |    167.45 ns |    195.76 ns | 0.0591 |      - |     496 B |
| Utf8JsonToStream       |     76.77 ns |   1.091 ns |   1.021 ns |     76.69 ns |     75.29 ns |     78.64 ns | 0.0411 |      - |     344 B |
| XmlToStream            |  5,413.13 ns | 101.784 ns |  95.209 ns |  5,405.25 ns |  5,239.99 ns |  5,609.19 ns | 1.2817 | 0.0305 |   10769 B |
| YamlDotNetToStream     |  8,239.70 ns | 156.836 ns | 146.705 ns |  8,273.23 ns |  7,923.32 ns |  8,450.49 ns | 1.4038 |      - |   11825 B |
| ZeroFormatterToStream  |    120.37 ns |   2.323 ns |   2.582 ns |    120.54 ns |    115.67 ns |    124.31 ns | 0.1788 | 0.0007 |    1496 B |

#### 4.1.2. From Stream

| Method                   | Mean        | Error      | StdDev     | Median      | Min         | Max         | Gen0   | Gen1   | Allocated |
|------------------------- |------------:|-----------:|-----------:|------------:|------------:|------------:|-------:|-------:|----------:|
| DataContractFromStream   | 1,772.29 ns |  29.243 ns |  27.354 ns | 1,775.58 ns | 1,733.71 ns | 1,826.85 ns | 0.9918 | 0.0210 |    8296 B |
| JilFromStream            |   127.57 ns |   2.498 ns |   3.739 ns |   126.57 ns |   122.86 ns |   135.39 ns | 0.0372 |      - |     312 B |
| MemoryPackFromStream     |    66.26 ns |   1.001 ns |   0.936 ns |    66.15 ns |    64.29 ns |    67.65 ns | 0.0134 |      - |     112 B |
| MessagePackFromStream    |   108.56 ns |   1.896 ns |   1.773 ns |   108.02 ns |   105.79 ns |   111.64 ns | 0.0076 |      - |      64 B |
| MsgPackFromStream        |   195.43 ns |   3.689 ns |   3.270 ns |   194.37 ns |   190.80 ns |   203.67 ns | 0.0534 |      - |     448 B |
| NetJsonFromStream        |   222.71 ns |   2.850 ns |   2.666 ns |   222.29 ns |   218.28 ns |   227.30 ns | 0.0448 |      - |     376 B |
| NewtonsoftJsonFromStream |   606.27 ns |  11.604 ns |  10.855 ns |   604.17 ns |   584.02 ns |   627.60 ns | 0.3405 | 0.0029 |    2848 B |
| ProtobufFromStream       |   128.10 ns |   1.953 ns |   1.731 ns |   127.54 ns |   125.87 ns |   131.29 ns | 0.0076 |      - |      64 B |
| SharpYamlFromStream      |   885.33 ns |  17.613 ns |  39.755 ns |   871.24 ns |   831.36 ns |   974.66 ns | 0.7658 | 0.0048 |    6408 B |
| SpanJsonFromStream       |    88.68 ns |   1.332 ns |   1.246 ns |    88.65 ns |    86.38 ns |    90.44 ns | 0.0153 |      - |     128 B |
| SystemTextJsonFromStream |   279.96 ns |   3.207 ns |   2.999 ns |   279.86 ns |   274.24 ns |   286.14 ns | 0.0076 |      - |      64 B |
| Utf8JsonFromStream       |   112.44 ns |   1.566 ns |   1.465 ns |   112.91 ns |   109.70 ns |   114.35 ns | 0.0076 |      - |      64 B |
| XmlFromStream            | 6,901.06 ns | 114.626 ns | 101.613 ns | 6,884.34 ns | 6,710.18 ns | 7,071.92 ns | 1.0071 |      - |    8588 B |
| YamlDotNetFromStream     | 5,890.89 ns | 117.598 ns | 110.001 ns | 5,910.51 ns | 5,692.23 ns | 6,048.19 ns | 1.4191 | 0.0305 |   11936 B |
| ZeroFormatterFromStream  |    49.29 ns |   0.966 ns |   0.949 ns |    49.51 ns |    46.62 ns |    50.40 ns | 0.0296 |      - |     248 B |

### 4.2. Bytes

#### 4.2.1. To Bytes

| Method                | Mean         | Error      | StdDev     | Min          | Max          | Median       | Gen0   | Gen1   | Allocated |
|---------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
| DataContractToBytes   |    664.27 ns |  19.490 ns |  57.161 ns |    578.95 ns |    792.24 ns |    655.74 ns | 0.2794 |      - |    2344 B |
| JilToBytes            |    145.38 ns |   2.890 ns |   6.583 ns |    132.34 ns |    157.76 ns |    146.29 ns | 0.0706 |      - |     592 B |
| MemoryPackToBytes     |     56.20 ns |   0.595 ns |   0.557 ns |     55.34 ns |     57.20 ns |     56.07 ns | 0.0057 |      - |      48 B |
| MessagePackToBytes    |     72.32 ns |   1.422 ns |   1.397 ns |     70.18 ns |     74.41 ns |     72.55 ns | 0.0048 |      - |      40 B |
| MsgPackToBytes        |    157.00 ns |   2.972 ns |   3.650 ns |    148.44 ns |    163.26 ns |    158.10 ns | 0.0706 |      - |     592 B |
| NetJsonToBytes        |    124.72 ns |   2.469 ns |   2.744 ns |    120.02 ns |    129.67 ns |    124.45 ns | 0.0257 |      - |     216 B |
| NewtonsoftJsonToBytes |    360.81 ns |   7.188 ns |   8.827 ns |    339.12 ns |    373.32 ns |    362.96 ns | 0.1779 | 0.0005 |    1488 B |
| ProtobufToBytes       |    189.07 ns |   3.571 ns |   3.969 ns |    180.03 ns |    196.40 ns |    188.49 ns | 0.0458 |      - |     384 B |
| SharpYamlToBytes      | 24,277.75 ns | 453.809 ns | 621.178 ns | 23,489.34 ns | 25,807.42 ns | 24,228.69 ns | 2.1973 |      - |   18396 B |
| SpanJsonToBytes       |     77.93 ns |   1.030 ns |   0.913 ns |     76.41 ns |     79.42 ns |     77.94 ns | 0.0076 |      - |      64 B |
| SystemTextJsonToBytes |    150.26 ns |   2.170 ns |   2.030 ns |    147.87 ns |    154.07 ns |    149.49 ns | 0.0076 |      - |      64 B |
| Utf8JsonToBytes       |     55.73 ns |   0.655 ns |   0.613 ns |     54.98 ns |     56.85 ns |     55.54 ns | 0.0076 |      - |      64 B |
| XmlToBytes            |  5,519.67 ns | 109.294 ns | 116.943 ns |  5,252.93 ns |  5,737.02 ns |  5,515.89 ns | 1.3123 | 0.0305 |   11017 B |
| YamlDotNetToBytes     |  8,220.72 ns | 158.050 ns | 155.226 ns |  7,916.78 ns |  8,479.30 ns |  8,213.22 ns | 1.4038 | 0.0153 |   11761 B |
| ZeroFormatterToBytes  |     74.74 ns |   1.067 ns |   0.998 ns |     72.73 ns |     76.22 ns |     74.90 ns | 0.1377 | 0.0005 |    1152 B |

#### 4.2.2. From Bytes

| Method                  | Mean         | Error      | StdDev     | Min          | Max          | Median       | Gen0   | Gen1   | Allocated |
|------------------------ |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
| DataContractFromBytes   |  1,808.81 ns |  32.524 ns |  55.228 ns |  1,750.61 ns |  1,965.96 ns |  1,802.17 ns | 0.9995 | 0.0191 |    8360 B |
| JilFromBytes            |    114.20 ns |   1.681 ns |   1.573 ns |    111.63 ns |    117.09 ns |    114.19 ns | 0.0296 |      - |     248 B |
| MemoryPackFromBytes     |     47.96 ns |   0.955 ns |   1.275 ns |     45.40 ns |     50.22 ns |     48.10 ns | 0.0076 |      - |      64 B |
| MessagePackFromBytes    |     85.46 ns |   1.440 ns |   1.347 ns |     82.62 ns |     87.78 ns |     85.59 ns | 0.0076 |      - |      64 B |
| MsgPackFromBytes        |    219.12 ns |   3.389 ns |   3.004 ns |    214.23 ns |    225.49 ns |    219.11 ns | 0.0610 |      - |     512 B |
| NetJsonFromBytes        |    233.90 ns |   4.083 ns |   4.538 ns |    224.89 ns |    241.42 ns |    233.89 ns | 0.0372 |      - |     312 B |
| NewtonsoftJsonFromBytes |    584.92 ns |  12.593 ns |  36.735 ns |    533.79 ns |    686.05 ns |    579.09 ns | 0.3319 | 0.0029 |    2784 B |
| ProtobufFromBytes       |    233.63 ns |   3.133 ns |   2.931 ns |    228.92 ns |    238.48 ns |    233.65 ns | 0.0181 |      - |     152 B |
| SharpYamlFromBytes      | 26,055.20 ns | 281.045 ns | 262.890 ns | 25,670.34 ns | 26,535.89 ns | 26,069.27 ns | 2.3804 | 0.0610 |   19939 B |
| SpanJsonFromBytes       |     64.41 ns |   1.189 ns |   1.112 ns |     62.95 ns |     66.21 ns |     64.28 ns | 0.0076 |      - |      64 B |
| SystemTextJsonFromBytes |    230.67 ns |   3.039 ns |   2.694 ns |    226.27 ns |    235.44 ns |    229.81 ns | 0.0076 |      - |      64 B |
| Utf8JsonFromBytes       |    104.34 ns |   1.095 ns |   1.024 ns |    102.44 ns |    105.83 ns |    104.17 ns | 0.0076 |      - |      64 B |
| XmlFromBytes            |  7,196.03 ns | 106.114 ns |  99.259 ns |  7,041.42 ns |  7,363.96 ns |  7,214.21 ns | 1.0071 |      - |    8651 B |
| YamlDotNetFromBytes     |  6,123.06 ns |  87.373 ns |  81.729 ns |  5,945.31 ns |  6,250.51 ns |  6,133.12 ns | 1.4191 | 0.0305 |   11880 B |
| ZeroFormatterFromBytes  |     40.41 ns |   0.818 ns |   1.707 ns |     38.27 ns |     45.30 ns |     39.96 ns | 0.0296 |      - |     248 B |

### 4.3. Text

#### 4.3.1. Json

##### 4.3.1.1. To Json

| Method               | Mean      | Error    | StdDev   |
|--------------------- |----------:|---------:|---------:|
| JilToText            | 115.07 ns | 2.259 ns | 4.460 ns |
| NetJsonToText        | 100.53 ns | 1.289 ns | 1.205 ns |
| NewtonsoftJsonToText | 332.22 ns | 6.472 ns | 8.640 ns |
| SpanJsonToText       | 102.23 ns | 1.610 ns | 1.506 ns |
| SystemTextJsonToText | 168.14 ns | 1.972 ns | 1.845 ns |
| Utf8JsonToText       |  66.74 ns | 1.138 ns | 1.009 ns |

##### 4.3.1.2. From Json

| Method                 | Mean      | Error     | StdDev    |
|----------------------- |----------:|----------:|----------:|
| JilFromText            |  91.71 ns |  1.585 ns |  1.405 ns |
| NetJsonFromText        | 174.18 ns |  2.711 ns |  2.536 ns |
| NewtonsoftJsonFromText | 520.15 ns | 10.420 ns | 25.949 ns |
| SpanJsonFromText       |  85.90 ns |  1.704 ns |  1.673 ns |
| SystemTextJsonFromText | 263.97 ns |  3.804 ns |  3.559 ns |
| Utf8JsonFromText       | 129.68 ns |  2.410 ns |  2.475 ns |

#### 4.3.2. Xml

##### 4.3.2.1. To Xml

| Method             | Mean       | Error    | StdDev   |
|------------------- |-----------:|---------:|---------:|
| DataContractToText |   708.0 ns | 14.03 ns | 16.16 ns |
| XmlToText          | 5,529.7 ns | 62.59 ns | 52.26 ns |

##### 4.3.2.2. From Xml

| Method               | Mean     | Error     | StdDev    | Median   |
|--------------------- |---------:|----------:|----------:|---------:|
| DataContractFromText | 1.921 μs | 0.0383 μs | 0.0872 μs | 1.889 μs |
| XmlFromText          | 7.218 μs | 0.0887 μs | 0.0740 μs | 7.222 μs |

#### 4.3.3. Yaml

##### 4.3.3.1. To Yaml

| Method           | Mean      | Error     | StdDev    |
|----------------- |----------:|----------:|----------:|
| SharpYamlToText  | 22.560 μs | 0.2544 μs | 0.2125 μs |
| YamlDotNetToText |  7.994 μs | 0.1544 μs | 0.1839 μs |

##### 4.3.3.2. From Yaml

| Method             | Mean      | Error     | StdDev    |
|------------------- |----------:|----------:|----------:|
| SharpYamlFromText  | 24.065 μs | 0.4524 μs | 0.4646 μs |
| YamlDotNetFromText |  5.769 μs | 0.1137 μs | 0.1594 μs |

#### 4.3.4. Ini

##### 4.3.4.1. To Ini

| Method          | Mean     | Error     | StdDev    |
|---------------- |---------:|----------:|----------:|
| IniParserToText | 8.570 μs | 0.1496 μs | 0.1469 μs |

##### 4.3.4.2. From Ini

| Method            | Mean     | Error    | StdDev   |
|------------------ |---------:|---------:|---------:|
| IniParserFromText | 10.88 μs | 0.216 μs | 0.281 μs |

#### 4.3.5. Toml

##### 4.3.5.1. To Toml

| Method       | Mean     | Error     | StdDev    |
|------------- |---------:|----------:|----------:|
| TomlynToText | 6.152 μs | 0.0780 μs | 0.0691 μs |

##### 4.3.5.2. From Toml

| Method         | Mean     | Error     | StdDev    |
|--------------- |---------:|----------:|----------:|
| TomlynFromText | 8.785 μs | 0.1127 μs | 0.1054 μs |
