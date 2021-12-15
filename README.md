# Zaabee.Serializers

---

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

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

Though some old serializers does not support stream, the zaabee serializers will supply the lack. And the text serializers will support text on this base.

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

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-JQVSJZ : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

IterationCount=1000  RunStrategy=Monitoring

### Bytes

|                Method |       Mean |     Error |    StdDev |     Median |       Min |       Max | Allocated |
|---------------------- |-----------:|----------:|----------:|-----------:|----------:|----------:|----------:|
|         BinaryToBytes |  70.978 μs | 2.6735 μs | 25.617 μs |  66.500 μs | 31.500 μs | 344.20 μs |   8,264 B |
|   DataContractToBytes |  48.099 μs | 2.1286 μs | 20.396 μs |  46.050 μs | 16.300 μs | 208.90 μs |   4,616 B |
|            JilToBytes |  16.145 μs | 1.2584 μs | 12.057 μs |  14.500 μs |  5.300 μs | 295.80 μs |   1,744 B |
|    MessagePackToBytes |  16.004 μs | 0.8703 μs |  8.339 μs |  15.000 μs |  5.600 μs | 119.40 μs |     560 B |
|        MsgPackToBytes |  27.278 μs | 1.2754 μs | 12.221 μs |  24.900 μs | 10.500 μs | 115.60 μs |   1,168 B |
| NewtonsoftJsonToBytes |  31.716 μs | 1.3819 μs | 13.241 μs |  29.900 μs |  9.300 μs | 139.90 μs |   1,936 B |
|       ProtobufToBytes |  25.564 μs | 1.4332 μs | 13.733 μs |  24.100 μs |  9.200 μs | 265.30 μs |   1,224 B |
| SystemTextJsonToBytes |  34.435 μs | 1.4130 μs | 13.539 μs |  33.550 μs |  6.400 μs | 145.20 μs |   1,400 B |
|       Utf8JsonToBytes |  16.064 μs | 0.7345 μs |  7.038 μs |  14.600 μs |  5.600 μs |  81.20 μs |     632 B |
|            XmlToBytes | 124.557 μs | 4.5231 μs | 43.339 μs | 117.500 μs | 59.300 μs | 487.00 μs |  12,024 B |
|  ZeroFormatterToBytes |   9.244 μs | 0.5838 μs |  5.593 μs |   8.300 μs |  2.800 μs |  85.10 μs |   1,664 B |

|                  Method |       Mean |     Error |    StdDev |     Median |       Min |        Max | Allocated |
|------------------------ |-----------:|----------:|----------:|-----------:|----------:|-----------:|----------:|
|         BinaryFromBytes |  89.914 μs | 3.3825 μs | 32.410 μs |  81.550 μs | 36.700 μs |   359.8 μs |  10,528 B |
|   DataContractFromBytes |  67.952 μs | 5.9526 μs | 57.037 μs |  58.600 μs | 28.200 μs | 1,641.9 μs |  13,832 B |
|            JilFromBytes |  24.355 μs | 1.9714 μs | 18.890 μs |  20.800 μs |  9.000 μs |   439.8 μs |   1,088 B |
|    MessagePackFromBytes |  28.527 μs | 1.3064 μs | 12.518 μs |  25.700 μs | 11.800 μs |   145.6 μs |     760 B |
|        MsgPackFromBytes |  43.660 μs | 2.1569 μs | 20.667 μs |  38.700 μs | 17.700 μs |   261.1 μs |   1,760 B |
| NewtonsoftJsonFromBytes |  60.780 μs | 2.5226 μs | 24.171 μs |  54.950 μs | 25.700 μs |   283.9 μs |   3,872 B |
|       ProtobufFromBytes |  30.538 μs | 1.8031 μs | 17.277 μs |  28.150 μs | 11.600 μs |   261.9 μs |   1,136 B |
| SystemTextJsonFromBytes |  33.869 μs | 2.0329 μs | 19.478 μs |  30.050 μs | 10.900 μs |   216.4 μs |   1,096 B |
|       Utf8JsonFromBytes |  22.692 μs | 1.0457 μs | 10.020 μs |  19.600 μs | 12.100 μs |   117.8 μs |     760 B |
|            XmlFromBytes | 153.780 μs | 5.4601 μs | 52.317 μs | 142.000 μs | 71.400 μs |   466.5 μs |  10,272 B |
|  ZeroFormatterFromBytes |   8.523 μs | 0.5905 μs |  5.658 μs |   7.300 μs |  3.300 μs |   113.2 μs |     952 B |

### Text

|               Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|--------------------- |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|   DataContractToText |  44.09 μs | 2.304 μs | 22.079 μs |  44.40 μs | 13.900 μs | 256.90 μs |   5,488 B |
|            JilToText |  11.73 μs | 0.598 μs |  5.725 μs |  10.90 μs |  4.100 μs |  84.20 μs |   1,304 B |
| NewtonsoftJsonToText |  28.84 μs | 1.472 μs | 14.109 μs |  26.90 μs |  8.600 μs | 182.60 μs |   2,128 B |
| SystemTextJsonToText |  40.14 μs | 1.708 μs | 16.362 μs |  37.70 μs | 13.000 μs | 140.40 μs |   1,320 B |
|       Utf8JsonToText |  18.05 μs | 0.929 μs |  8.905 μs |  16.60 μs |  6.500 μs | 206.50 μs |     464 B |
|            XmlToText | 129.44 μs | 4.894 μs | 46.890 μs | 123.00 μs | 56.000 μs | 500.70 μs |  12,368 B |

|                 Method |      Mean |    Error |    StdDev |    Median |       Min |       Max | Allocated |
|----------------------- |----------:|---------:|----------:|----------:|----------:|----------:|----------:|
|   DataContractFromText |  73.20 μs | 2.597 μs | 24.882 μs |  72.25 μs | 41.300 μs | 238.40 μs |  14,088 B |
|            JilFromText |  15.95 μs | 0.599 μs |  5.739 μs |  14.70 μs |  8.600 μs |  88.00 μs |     856 B |
| NewtonsoftJsonFromText |  53.75 μs | 2.206 μs | 21.136 μs |  47.85 μs | 26.100 μs | 200.00 μs |   3,616 B |
| SystemTextJsonFromText |  37.96 μs | 1.862 μs | 17.846 μs |  37.50 μs | 12.000 μs | 213.90 μs |     760 B |
|       Utf8JsonFromText |  22.12 μs | 1.099 μs | 10.533 μs |  20.50 μs | 12.100 μs | 191.20 μs |     912 B |
|            XmlFromText | 145.97 μs | 5.193 μs | 49.755 μs | 133.60 μs | 70.000 μs | 473.50 μs |  10,888 B |

### Stream

|                 Method |      Mean |    Error |    StdDev |    Median |       Min |         Max | Allocated |
|----------------------- |----------:|---------:|----------:|----------:|----------:|------------:|----------:|
|         BinaryToStream |  70.52 μs | 2.609 μs | 24.999 μs |  67.00 μs | 27.500 μs |   244.50 μs |   7,512 B |
|   DataContractToStream |  44.09 μs | 2.307 μs | 22.101 μs |  43.65 μs | 11.800 μs |   359.40 μs |   3,736 B |
|            JilToStream |  18.38 μs | 0.800 μs |  7.668 μs |  17.20 μs |  5.800 μs |   103.50 μs |   1,800 B |
|    MessagePackToStream |  26.36 μs | 1.254 μs | 12.018 μs |  24.50 μs | 10.600 μs |   201.40 μs |     536 B |
|        MsgPackToStream |  26.25 μs | 1.302 μs | 12.479 μs |  23.90 μs | 10.900 μs |   137.10 μs |   1,104 B |
| NewtonsoftJsonToStream |  36.70 μs | 1.559 μs | 14.939 μs |  34.40 μs | 10.800 μs |   158.30 μs |   2,616 B |
|       ProtobufToStream |  23.12 μs | 1.175 μs | 11.262 μs |  21.80 μs |  5.500 μs |   137.10 μs |     536 B |
| SystemTextJsonToStream |  37.86 μs | 1.429 μs | 13.695 μs |  35.10 μs | 18.100 μs |   137.90 μs |   1,120 B |
|       Utf8JsonToStream |  18.41 μs | 0.925 μs |  8.862 μs |  16.90 μs |  6.500 μs |   103.70 μs |     824 B |
|            XmlToStream | 132.42 μs | 9.742 μs | 93.341 μs | 123.00 μs | 66.800 μs | 2,847.40 μs |  11,688 B |
|  ZeroFormatterToStream |  11.49 μs | 0.639 μs |  6.123 μs |  10.20 μs |  4.500 μs |    72.20 μs |   2,008 B |

|                   Method |       Mean |      Error |     StdDev |     Median |       Min |         Max | Allocated |
|------------------------- |-----------:|-----------:|-----------:|-----------:|----------:|------------:|----------:|
|         BinaryFromStream |  72.575 μs |  3.0032 μs |  28.776 μs |  67.700 μs | 36.700 μs |   355.00 μs |  10,464 B |
|   DataContractFromStream |  59.453 μs |  2.4639 μs |  23.608 μs |  53.750 μs | 27.700 μs |   213.60 μs |  13,144 B |
|            JilFromStream |  20.869 μs |  0.8528 μs |   8.172 μs |  20.150 μs |  9.400 μs |   128.20 μs |   1,336 B |
|    MessagePackFromStream |  28.271 μs |  1.4564 μs |  13.955 μs |  26.400 μs | 13.400 μs |   241.90 μs |     808 B |
|        MsgPackFromStream |  34.679 μs |  2.0772 μs |  19.903 μs |  30.600 μs | 16.900 μs |   478.50 μs |     736 B |
| NewtonsoftJsonFromStream |  55.694 μs |  2.5697 μs |  24.623 μs |  50.600 μs | 27.100 μs |   273.10 μs |   4,016 B |
|       ProtobufFromStream |  21.398 μs |  1.2391 μs |  11.873 μs |  18.600 μs |  9.800 μs |   182.20 μs |     472 B |
| SystemTextJsonFromStream |  38.016 μs |  2.2859 μs |  21.903 μs |  35.600 μs | 13.700 μs |   341.20 μs |     760 B |
|       Utf8JsonFromStream |  18.984 μs |  0.7084 μs |   6.788 μs |  18.500 μs | 11.900 μs |    96.90 μs |     760 B |
|            XmlFromStream | 141.412 μs | 17.8892 μs | 171.411 μs | 126.900 μs | 71.500 μs | 5,316.50 μs |  10,496 B |
|  ZeroFormatterFromStream |   8.388 μs |  0.4612 μs |   4.420 μs |   7.800 μs |  3.300 μs |    51.30 μs |     664 B |

### FileStream Async

|                        Method |     Mean |    Error |    StdDev |   Median |       Min |         Max | Allocated |
|------------------------------ |---------:|---------:|----------:|---------:|----------:|------------:|----------:|
|            JilFromStreamAsync | 170.1 μs |  5.24 μs |  50.23 μs | 159.5 μs | 102.60 μs |    617.2 μs |      3 KB |
|    MessagePackFromStreamAsync | 170.6 μs |  6.67 μs |  63.90 μs | 158.4 μs |  91.90 μs |  1,732.8 μs |      2 KB |
|        MsgPackFromStreamAsync | 117.4 μs | 14.92 μs | 142.94 μs | 105.8 μs |  58.30 μs |  4,444.7 μs |      5 KB |
| NewtonsoftJsonFromStreamAsync | 213.2 μs |  6.24 μs |  59.82 μs | 198.7 μs | 132.80 μs |    899.7 μs |      6 KB |
| SystemTextJsonFromStreamAsync | 186.3 μs | 37.60 μs | 360.30 μs | 162.2 μs | 102.80 μs | 10,735.9 μs |      3 KB |
|       Utf8JsonFromStreamAsync | 143.0 μs |  5.72 μs |  54.82 μs | 133.8 μs |  89.70 μs |  1,074.8 μs |      2 KB |
