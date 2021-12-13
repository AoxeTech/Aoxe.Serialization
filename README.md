# Zaabee.Serializers

---

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for serializers. It is also the serializer provider for all Zaabee technology stacks.

## Project meaning

There are many different serializers in the world, they have different features and limitations. This project allows you to use difference serializers in the same way. Also it set nullable and default value for all serializers.

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
      - Task\<MemoryStream\> ToStreamAsync\<TValue\>(TValue? value)
      - Task\<MemoryStream\> ToStreamAsync(Type type, object? value)
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
The Zaabee technology stacks uses this class to serialize and deserialize. It will return Array.Empty\<byte\>()/string.Empty/Stream.Null if the value is null.
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

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.302
  [Host]     : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT
  Job-CIJWEL : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT

IterationCount=10000  RunStrategy=Monitoring

### Bytes

|                Method |       Mean |    Error |    StdDev |    Median |       Min |        Max | Allocated |
|---------------------- |-----------:|---------:|----------:|----------:|----------:|-----------:|----------:|
|         BinaryToBytes |  67.585 μs | 7.783 μs | 74.577 μs | 56.200 μs | 25.600 μs | 1,542.8 μs |    7824 B |
|            JilToBytes |  15.753 μs | 1.731 μs | 16.583 μs | 11.600 μs |  5.000 μs |   176.8 μs |    1072 B |
|        MsgPackToBytes |  29.938 μs | 3.852 μs | 36.913 μs | 22.000 μs |  7.200 μs |   399.7 μs |     840 B |
| NewtonsoftJsonToBytes |  29.479 μs | 4.747 μs | 45.488 μs | 20.100 μs |  8.600 μs |   506.9 μs |    1888 B |
|       ProtobufToBytes |  23.990 μs | 3.432 μs | 32.883 μs | 16.750 μs |  6.500 μs |   339.4 μs |     416 B |
| SystemTextJsonToBytes |  24.757 μs | 3.802 μs | 36.433 μs | 15.650 μs |  6.600 μs |   351.0 μs |     296 B |
|       Utf8JsonToBytes |  15.786 μs | 1.651 μs | 15.815 μs | 12.700 μs |  4.500 μs |   182.1 μs |     152 B |
|            XmlToBytes | 113.928 μs | 9.322 μs | 89.325 μs | 92.150 μs | 36.000 μs |   982.4 μs |   11184 B |
|  ZeroFormatterToBytes |   8.342 μs | 1.063 μs | 10.184 μs |  5.900 μs |  2.900 μs |   108.9 μs |    1184 B |

|                  Method |      Mean |     Error |    StdDev |     Median |       Min |        Max | Allocated |
|------------------------ |----------:|----------:|----------:|-----------:|----------:|-----------:|----------:|
|         BinaryFromBytes | 125.49 μs |  7.405 μs |  70.96 μs | 111.300 μs | 50.200 μs | 1,101.2 μs |    9872 B |
|            JilFromBytes |  23.46 μs |  1.448 μs |  13.87 μs |  20.400 μs |  9.300 μs |   150.4 μs |     456 B |
|        MsgPackFromBytes |  50.67 μs |  5.281 μs |  50.61 μs |  40.050 μs | 20.500 μs |   651.3 μs |     808 B |
| NewtonsoftJsonFromBytes |  74.21 μs |  7.212 μs |  69.10 μs |  59.450 μs | 30.400 μs |   856.2 μs |    3200 B |
|       ProtobufFromBytes |  33.65 μs |  2.905 μs |  27.83 μs |  28.100 μs | 13.600 μs |   255.8 μs |     184 B |
| SystemTextJsonFromBytes |  36.07 μs |  4.297 μs |  41.18 μs |  27.600 μs | 10.900 μs |   733.8 μs |      88 B |
|       Utf8JsonFromBytes |  24.16 μs |  1.686 μs |  16.16 μs |  20.600 μs |  8.300 μs |   170.7 μs |      88 B |
|            XmlFromBytes | 152.54 μs | 11.165 μs | 106.98 μs | 131.700 μs | 68.500 μs | 1,569.3 μs |    8648 B |
|  ZeroFormatterFromBytes |  10.62 μs |  1.402 μs |  13.43 μs |   8.000 μs |  3.500 μs |   289.9 μs |     280 B |

### Text

|               Method |      Mean |    Error |   StdDev |   Median |       Min |      Max | Allocated |
|--------------------- |----------:|---------:|---------:|---------:|----------:|---------:|----------:|
|            JilToText |  13.27 μs | 1.399 μs | 13.40 μs | 10.50 μs |  4.200 μs | 170.7 μs |     920 B |
| NewtonsoftJsonToText |  25.42 μs | 3.756 μs | 35.99 μs | 17.30 μs |  8.300 μs | 390.4 μs |    1744 B |
| SystemTextJsonToText |  23.90 μs | 3.864 μs | 37.02 μs | 15.20 μs |  6.400 μs | 443.3 μs |     408 B |
|       Utf8JsonToText |  16.78 μs | 1.949 μs | 18.68 μs | 12.45 μs |  5.000 μs | 178.3 μs |     272 B |
|            XmlToText | 105.16 μs | 9.684 μs | 92.79 μs | 85.10 μs | 34.900 μs | 977.1 μs |   11832 B |

|                 Method |      Mean |     Error |    StdDev |    Median |       Min |        Max | Allocated |
|----------------------- |----------:|----------:|----------:|----------:|----------:|-----------:|----------:|
|            JilFromText |  16.73 μs |  1.263 μs |  12.11 μs |  14.30 μs |  5.500 μs |   150.1 μs |     184 B |
| NewtonsoftJsonFromText |  61.75 μs |  5.712 μs |  54.73 μs |  49.60 μs | 18.700 μs |   679.6 μs |    2944 B |
| SystemTextJsonFromText |  39.73 μs |  4.157 μs |  39.83 μs |  30.45 μs |  9.200 μs |   438.5 μs |      88 B |
|       Utf8JsonFromText |  23.25 μs |  1.837 μs |  17.60 μs |  20.00 μs |  7.000 μs |   231.1 μs |     240 B |
|            XmlFromText | 161.43 μs | 11.511 μs | 110.29 μs | 141.20 μs | 56.300 μs | 1,669.1 μs |    8984 B |

### Stream

|                 Method |      Mean |    Error |   StdDev |    Median |       Min |        Max | Allocated |
|----------------------- |----------:|---------:|---------:|----------:|----------:|-----------:|----------:|
|         BinaryToStream |  69.47 μs | 8.858 μs | 84.87 μs | 55.350 μs | 25.000 μs | 1,990.7 μs |    7360 B |
|            JilToStream |  16.79 μs | 2.084 μs | 19.96 μs | 11.900 μs |  5.400 μs |   202.5 μs |    1424 B |
|        MsgPackToStream |  26.57 μs | 3.908 μs | 37.45 μs | 19.100 μs |  6.700 μs |   523.1 μs |     776 B |
| NewtonsoftJsonToStream |  31.80 μs | 5.139 μs | 49.25 μs | 20.700 μs |  9.100 μs |   522.3 μs |    2240 B |
|       ProtobufToStream |  24.45 μs | 3.381 μs | 32.40 μs | 17.600 μs |  6.400 μs |   330.2 μs |     352 B |
| SystemTextJsonToStream |  25.42 μs | 3.887 μs | 37.25 μs | 16.500 μs |  6.400 μs |   405.9 μs |     648 B |
|       Utf8JsonToStream |  16.32 μs | 1.831 μs | 17.55 μs | 12.200 μs |  5.100 μs |   167.7 μs |     352 B |
|            XmlToStream | 102.81 μs | 8.876 μs | 85.04 μs | 84.250 μs | 34.100 μs | 1,007.5 μs |   10848 B |
|  ZeroFormatterToStream |  11.08 μs | 1.441 μs | 13.81 μs |  7.900 μs |  3.600 μs |   122.8 μs |    1536 B |

|                   Method |      Mean |     Error |     StdDev |     Median |       Min |        Max | Allocated |
|------------------------- |----------:|----------:|-----------:|-----------:|----------:|-----------:|----------:|
|         BinaryFromStream | 128.25 μs |  8.229 μs |  78.850 μs | 110.900 μs | 75.100 μs | 1,054.5 μs |    9800 B |
|            JilFromStream |  22.95 μs |  1.616 μs |  15.485 μs |  19.300 μs |  9.300 μs |   154.0 μs |     616 B |
|        MsgPackFromStream |  44.20 μs |  4.431 μs |  42.458 μs |  34.800 μs | 17.200 μs |   503.8 μs |     736 B |
| NewtonsoftJsonFromStream |  69.35 μs |  6.626 μs |  63.491 μs |  57.000 μs | 30.200 μs |   851.4 μs |    3344 B |
|       ProtobufFromStream |  28.39 μs |  2.328 μs |  22.302 μs |  23.300 μs | 10.700 μs |   235.1 μs |      88 B |
| SystemTextJsonFromStream |  37.38 μs |  5.362 μs |  51.377 μs |  26.600 μs | 12.600 μs | 1,049.6 μs |     232 B |
|       Utf8JsonFromStream |  24.75 μs |  1.748 μs |  16.747 μs |  21.200 μs | 10.700 μs |   229.0 μs |      88 B |
|            XmlFromStream | 156.03 μs | 11.137 μs | 106.715 μs | 137.450 μs | 63.100 μs | 1,942.6 μs |    8576 B |
|  ZeroFormatterFromStream |  10.12 μs |  0.977 μs |   9.358 μs |   7.900 μs |  4.000 μs |   116.5 μs |     280 B |

### FileStream Async

|                      Method |     Mean |    Error |   StdDev |   Median |       Min |      Max | Allocated |
|---------------------------- |---------:|---------:|---------:|---------:|----------:|---------:|----------:|
|            JilToStreamAsync | 23.78 μs | 3.019 μs | 28.93 μs | 16.90 μs |  6.400 μs | 304.4 μs |    1560 B |
|        MsgPackToStreamAsync | 63.17 μs | 7.323 μs | 70.17 μs | 48.10 μs | 16.500 μs | 790.0 μs |    1176 B |
| NewtonsoftJsonToStreamAsync | 36.26 μs | 5.475 μs | 52.46 μs | 23.70 μs | 10.400 μs | 540.4 μs |    2384 B |
| SystemTextJsonToStreamAsync | 32.94 μs | 4.859 μs | 46.55 μs | 22.20 μs |  7.800 μs | 504.7 μs |     648 B |
|       Utf8JsonToStreamAsync | 25.01 μs | 2.966 μs | 28.42 μs | 19.45 μs |  6.600 μs | 420.8 μs |     496 B |

|                        Method |     Mean |    Error |    StdDev |   Median |      Min |        Max | Allocated |
|------------------------------ |---------:|---------:|----------:|---------:|---------:|-----------:|----------:|
|            JilFromStreamAsync | 210.3 μs |  7.87 μs |  75.37 μs | 191.2 μs | 120.7 μs |   964.8 μs |   2.08 KB |
|        MsgPackFromStreamAsync | 392.1 μs | 21.49 μs | 205.95 μs | 346.4 μs | 241.9 μs | 3,260.6 μs |  10.59 KB |
| NewtonsoftJsonFromStreamAsync | 260.0 μs | 12.04 μs | 115.40 μs | 234.8 μs | 152.5 μs | 1,385.6 μs |   4.89 KB |
| SystemTextJsonFromStreamAsync | 223.8 μs | 10.66 μs | 102.16 μs | 200.8 μs | 123.7 μs | 1,661.7 μs |   1.27 KB |
|       Utf8JsonFromStreamAsync | 202.1 μs |  6.87 μs |  65.85 μs | 187.2 μs | 128.3 μs |   989.6 μs |   1.06 KB |
