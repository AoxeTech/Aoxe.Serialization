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

Though some serializers does not support stream or bytes, the zaabee serializers will supply the lack. And the text serializers will support text on this base.

## Explain

- Helper
  Unified code style and provide lack of features. The default enconding is UTF-8.
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
- Extensions
  Supply Extension methods base by Helper. Also it supports generic type and non-generic type.
  - Bytes
    - FromBytes
  - Object
    - PackTo
    - ToBytes
    - ToJson/ToXml
    - ToStream
  - Stream
    - FromStream
    - PackBy
  - String
    - FromJson/FromXml
- Serializer
  Implement Zaabee.Serializer.Abstractions, The Zaabee technology stacks use this class to serialize and deserialize. It will return Array.Empty\<byte\>()/string.Empty/Stream.Null if the value is null.
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
PM> Install-Package Zaabee.SystemTextJson
PM> Install-Package Zaabee.Xml
PM> Install-Package Zaabee.ZeroFormatter
```

### [Zaabee.Binary](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Binary)

Base by System.Runtime.Serialization.Formatters.Binary.BinaryFormatter, the first party BinaryFormatter from microsoft.

### [Zaabee.DataContractSerializer](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.DataContractSerializer)

Base by System.Runtime.Serialization.DataContractSerializer, serializes and deserializes an instance of a type into an XML stream or document using a supplied data contract.

### [Zaabee.Jil](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Jil)

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

### [Zaabee.NewtonsoftJson](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.NewtonsoftJson)

Json.NET is a popular high-performance JSON framework for .NET [https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)

### [Zaabee.MessagePack](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.MessagePack)

The extremely fast MessagePack serializer for C#. It is 10x faster than MsgPack-Cli and outperforms other C# serializers. MessagePack for C# also ships with built-in support for LZ4 compression - an extremely fast compression algorithm. Performance is important, particularly in applications like games, distributed computing, microservices, or data caches.

### [Zaabee.MsgPack](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.MsgPack)

MessagePack implementation for Common Language Infrastructure / msgpack.org[C#]

### [Zaabee.Utf8Json](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Utf8Json)

Definitely Fastest and Zero Allocation JSON Serializer for C#(NET, .NET Core, Unity, Xamarin).

### [Zaabee.Protobuf](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Protobuf)

protobuf-net is a contract based serializer for .NET code, that happens to write data in the "protocol buffers" serialization format engineered by Google. The API, however, is very different to Google's, and follows typical .NET patterns (it is broadly comparable, in usage, to XmlSerializer, DataContractSerializer, etc). It should work for most .NET languages that write standard types and can use attributes.

### [Zaabee.SystemTextJson](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.SystemTextJson)

The System.Text.Json namespace provides high-performance, low-allocating, and standards-compliant capabilities to process JavaScript Object Notation (JSON), which includes serializing objects to JSON text and deserializing JSON text to objects, with UTF-8 support built-in. It also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM) for random access of the JSON elements within a structured view of the data.

### [Zaabee.Xml](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.Xml)

Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.

### [Zaabee.ZeroFormatter](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/src/Zaabee.ZeroFormatter)

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

|                 Method |        Mean |     Error |    StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|----------:|
|         BinaryToStream | 11,169.2 ns | 219.05 ns | 377.85 ns | 11,179.7 ns | 10,383.5 ns | 12,087.7 ns | 3.1128 |   6,529 B |
|   DataContractToStream |  2,997.2 ns |  67.87 ns | 194.74 ns |  2,944.2 ns |  2,666.4 ns |  3,539.0 ns | 1.6022 |   3,352 B |
|            JilToStream |    951.1 ns |  25.16 ns |  67.15 ns |    947.0 ns |    746.6 ns |  1,181.4 ns | 0.6771 |   1,416 B |
|    MessagePackToStream |    575.9 ns |  11.41 ns |  24.57 ns |    572.8 ns |    535.5 ns |    631.1 ns | 0.1640 |     344 B |
|        MsgPackToStream |    717.9 ns |  13.85 ns |  19.87 ns |    708.5 ns |    694.9 ns |    762.7 ns | 0.3672 |     768 B |
| NewtonsoftJsonToStream |  1,590.2 ns |  31.73 ns |  76.64 ns |  1,578.3 ns |  1,427.5 ns |  1,769.1 ns | 1.0662 |   2,232 B |
|       ProtobufToStream |    536.0 ns |  10.63 ns |  18.90 ns |    529.2 ns |    511.4 ns |    579.8 ns | 0.1640 |     344 B |
| SystemTextJsonToStream |    764.8 ns |  14.42 ns |  16.03 ns |    763.9 ns |    736.8 ns |    795.7 ns | 0.2365 |     496 B |
|       Utf8JsonToStream |    518.3 ns |  10.13 ns |  17.47 ns |    513.9 ns |    491.6 ns |    568.8 ns | 0.1640 |     344 B |
|            XmlToStream | 13,902.5 ns | 353.22 ns | 996.26 ns | 13,709.4 ns | 12,540.8 ns | 16,888.5 ns | 5.2795 |  11,060 B |
|  ZeroFormatterToStream |    343.3 ns |   6.86 ns |  17.84 ns |    339.2 ns |    308.0 ns |    383.6 ns | 0.7300 |   1,528 B |

|                   Method |        Mean |     Error |    StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|------------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|----------:|
|         BinaryFromStream | 12,303.7 ns | 218.31 ns | 364.75 ns | 12,234.8 ns | 11,749.7 ns | 13,101.4 ns | 4.6692 |   9,792 B |
|   DataContractFromStream |  6,819.1 ns | 129.39 ns | 121.03 ns |  6,846.4 ns |  6,454.6 ns |  6,994.8 ns | 6.1111 |  12,808 B |
|            JilFromStream |    647.6 ns |  12.81 ns |  28.91 ns |    643.1 ns |    603.2 ns |    720.5 ns | 0.2937 |     616 B |
|    MessagePackFromStream |    519.7 ns |  10.21 ns |  15.59 ns |    515.0 ns |    499.8 ns |    558.2 ns | 0.0420 |      88 B |
|        MsgPackFromStream |  1,084.8 ns |  20.46 ns |  45.33 ns |  1,074.0 ns |  1,023.1 ns |  1,205.7 ns | 0.3510 |     736 B |
| NewtonsoftJsonFromStream |  3,378.2 ns |  66.33 ns | 119.62 ns |  3,335.6 ns |  3,228.4 ns |  3,646.1 ns | 1.5945 |   3,344 B |
|       ProtobufFromStream |    507.8 ns |   9.18 ns |   7.17 ns |    506.5 ns |    499.2 ns |    519.5 ns | 0.0420 |      88 B |
| SystemTextJsonFromStream |  1,202.7 ns |  23.61 ns |  47.70 ns |  1,198.0 ns |  1,117.5 ns |  1,306.8 ns | 0.0420 |      88 B |
|       Utf8JsonFromStream |    815.7 ns |  14.67 ns |  36.53 ns |    809.7 ns |    739.0 ns |    916.2 ns | 0.0420 |      88 B |
|            XmlFromStream | 18,056.3 ns | 355.13 ns | 725.43 ns | 17,772.6 ns | 17,015.0 ns | 19,784.7 ns | 4.5471 |   9,531 B |
|  ZeroFormatterFromStream |    117.9 ns |   2.38 ns |   2.84 ns |    118.1 ns |    114.1 ns |    126.3 ns | 0.1338 |     280 B |

### FileStream Async

|                        Method |     Mean |    Error |   StdDev |    Median |       Min |      Max |  Gen 0 | Allocated |
|------------------------------ |---------:|---------:|---------:|----------:|----------:|---------:|-------:|----------:|
|            JilFromStreamAsync | 39.06 μs | 0.362 μs | 0.339 μs | 39.046 μs | 38.271 μs | 39.64 μs | 0.7935 |   1,731 B |
|    MessagePackFromStreamAsync | 49.22 μs | 0.967 μs | 1.668 μs | 49.537 μs | 44.573 μs | 52.07 μs | 0.2441 |     572 B |
|        MsgPackFromStreamAsync | 10.01 μs | 0.190 μs | 0.169 μs |  9.977 μs |  9.733 μs | 10.40 μs | 1.6785 |   3,512 B |
| NewtonsoftJsonFromStreamAsync | 64.14 μs | 1.357 μs | 4.002 μs | 65.349 μs | 54.389 μs | 70.97 μs | 2.3193 |   4,635 B |
| SystemTextJsonFromStreamAsync | 36.96 μs | 0.722 μs | 1.013 μs | 37.002 μs | 34.618 μs | 38.70 μs | 0.4272 |     980 B |
|       Utf8JsonFromStreamAsync | 34.68 μs | 0.541 μs | 0.506 μs | 34.796 μs | 33.127 μs | 35.24 μs | 0.3052 |     658 B |

### Bytes

|                Method |        Mean |     Error |      StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|---------------------- |------------:|----------:|------------:|------------:|------------:|------------:|-------:|----------:|
|         BinaryToBytes |  9,676.7 ns | 293.75 ns |   838.08 ns |  9,519.4 ns |  8,169.2 ns | 12,024.5 ns | 3.3264 |   6,994 B |
|   DataContractToBytes |  2,889.4 ns | 142.37 ns |   408.48 ns |  2,804.3 ns |  2,304.5 ns |  4,069.2 ns | 1.8845 |   3,944 B |
|            JilToBytes |    744.7 ns |  22.71 ns |    64.05 ns |    730.6 ns |    644.6 ns |    935.7 ns | 0.5121 |   1,072 B |
|    MessagePackToBytes |    325.0 ns |  11.80 ns |    33.08 ns |    316.5 ns |    278.9 ns |    419.7 ns | 0.0381 |      80 B |
|        MsgPackToBytes |  1,111.9 ns | 122.06 ns |   359.88 ns |    946.4 ns |    711.8 ns |  1,971.0 ns | 0.3977 |     832 B |
| NewtonsoftJsonToBytes |  2,031.9 ns |  59.39 ns |   166.54 ns |  2,002.9 ns |  1,744.0 ns |  2,514.5 ns | 0.9003 |   1,888 B |
|       ProtobufToBytes |    792.4 ns |  16.39 ns |    46.49 ns |    790.3 ns |    721.1 ns |    953.8 ns | 0.1945 |     408 B |
| SystemTextJsonToBytes |    876.7 ns |  20.79 ns |    59.31 ns |    864.6 ns |    764.4 ns |  1,029.8 ns | 0.1411 |     296 B |
|       Utf8JsonToBytes |    685.3 ns |  39.09 ns |   115.25 ns |    641.9 ns |    532.9 ns |  1,023.7 ns | 0.0725 |     152 B |
|            XmlToBytes | 19,995.6 ns | 759.93 ns | 2,240.68 ns | 19,934.7 ns | 15,149.3 ns | 24,367.4 ns | 5.4321 |  11,396 B |
|  ZeroFormatterToBytes |    328.6 ns |   8.84 ns |    25.65 ns |    320.7 ns |    277.5 ns |    396.7 ns | 0.5660 |   1,184 B |

|                  Method |        Mean |       Error |      StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|------------------------ |------------:|------------:|------------:|------------:|------------:|------------:|-------:|----------:|
|         BinaryFromBytes | 12,666.7 ns |   250.40 ns |   500.08 ns | 12,459.5 ns | 12,029.0 ns | 13,855.3 ns | 4.6997 |   9,856 B |
|   DataContractFromBytes |  7,231.5 ns |   143.05 ns |   279.01 ns |  7,164.5 ns |  6,852.5 ns |  7,975.3 ns | 6.1417 |  12,872 B |
|            JilFromBytes | 25,137.6 ns | 1,798.35 ns | 5,101.62 ns | 24,500.0 ns | 15,300.0 ns | 39,400.0 ns |      - |   1,128 B |
|    MessagePackFromBytes |    516.4 ns |    12.92 ns |    36.44 ns |    507.9 ns |    456.5 ns |    626.8 ns | 0.0420 |      88 B |
|        MsgPackFromBytes |  1,275.6 ns |    25.22 ns |    65.10 ns |  1,265.9 ns |  1,162.3 ns |  1,470.8 ns | 0.3815 |     800 B |
| NewtonsoftJsonFromBytes |  3,606.3 ns |    71.73 ns |   160.44 ns |  3,576.1 ns |  3,383.9 ns |  4,051.4 ns | 1.5259 |   3,200 B |
|       ProtobufFromBytes |    726.9 ns |    14.28 ns |    21.37 ns |    721.3 ns |    693.4 ns |    769.4 ns | 0.0839 |     176 B |
| SystemTextJsonFromBytes |  1,012.8 ns |    20.23 ns |    42.67 ns |    997.8 ns |    946.5 ns |  1,114.7 ns | 0.0420 |      88 B |
|       Utf8JsonFromBytes |    803.0 ns |    15.91 ns |    24.29 ns |    802.5 ns |    751.4 ns |    853.4 ns | 0.0420 |      88 B |
|            XmlFromBytes | 18,814.4 ns |   343.81 ns |   535.27 ns | 18,704.1 ns | 18,052.1 ns | 20,310.0 ns | 4.5776 |   9,595 B |
|  ZeroFormatterFromBytes |    129.6 ns |     2.63 ns |     6.41 ns |    128.2 ns |    119.3 ns |    145.0 ns | 0.1338 |     280 B |

### Text

|               Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |  Gen 0 | Allocated |
|--------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|----------:|
|   DataContractToText |  2,761.5 ns |  57.37 ns | 164.61 ns |  2,512.4 ns |  3,213.8 ns |  2,725.1 ns | 2.4338 |   5,104 B |
|            JilToText |    615.8 ns |  12.21 ns |  19.72 ns |    588.6 ns |    668.1 ns |    611.3 ns | 0.4396 |     920 B |
| NewtonsoftJsonToText |  1,410.8 ns |  28.04 ns |  60.36 ns |  1,305.3 ns |  1,566.3 ns |  1,396.8 ns | 0.8335 |   1,744 B |
| SystemTextJsonToText |    726.9 ns |  13.75 ns |  26.48 ns |    658.7 ns |    792.1 ns |    726.8 ns | 0.1945 |     408 B |
|       Utf8JsonToText |    515.7 ns |   8.51 ns |   7.55 ns |    504.3 ns |    530.7 ns |    515.1 ns | 0.1259 |     264 B |
|            XmlToText | 13,829.3 ns | 275.35 ns | 725.37 ns | 12,341.0 ns | 15,702.0 ns | 13,742.1 ns | 5.7373 |  12,028 B |

|                 Method |        Mean |     Error |      StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|----------------------- |------------:|----------:|------------:|------------:|------------:|------------:|-------:|----------:|
|   DataContractFromText |  7,008.6 ns | 140.20 ns |   252.80 ns |  6,968.6 ns |  6,585.5 ns |  7,506.4 ns | 6.4240 |  13,464 B |
|            JilFromText |    530.7 ns |  11.07 ns |    31.76 ns |    520.6 ns |    485.9 ns |    618.4 ns | 0.0877 |     184 B |
| NewtonsoftJsonFromText |  3,427.3 ns | 101.94 ns |   284.18 ns |  3,376.5 ns |  2,910.8 ns |  4,203.8 ns | 1.4038 |   2,944 B |
| SystemTextJsonFromText |  1,179.4 ns |  23.40 ns |    65.62 ns |  1,175.0 ns |  1,068.7 ns |  1,331.5 ns | 0.0420 |      88 B |
|       Utf8JsonFromText |    899.2 ns |  22.12 ns |    60.56 ns |    877.8 ns |    823.1 ns |  1,096.9 ns | 0.1144 |     240 B |
|            XmlFromText | 20,156.5 ns | 438.35 ns | 1,243.51 ns | 19,843.2 ns | 18,048.7 ns | 24,317.1 ns | 4.7302 |   9,932 B |
