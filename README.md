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

### Stream

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|         BinaryToStream |  4,546.3 ns |  54.84 ns |  45.79 ns |  4,441.0 ns |  4,628.8 ns |  4,553.1 ns | 0.7782 | 0.0076 |    6528 B |
|   DataContractToStream |  1,150.6 ns |  22.90 ns |  21.42 ns |  1,114.1 ns |  1,189.1 ns |  1,151.2 ns | 0.3700 |      - |    3096 B |
|            JilToStream |    327.6 ns |   6.40 ns |   9.78 ns |    298.6 ns |    340.1 ns |    329.5 ns | 0.1693 |      - |    1416 B |
|    MessagePackToStream |    277.2 ns |   4.39 ns |   4.10 ns |    269.3 ns |    283.6 ns |    278.5 ns | 0.0410 |      - |     344 B |
|        MsgPackToStream |    340.7 ns |   6.69 ns |   7.16 ns |    321.7 ns |    347.7 ns |    342.6 ns | 0.0858 |      - |     720 B |
| NewtonsoftJsonToStream |    976.1 ns |  19.18 ns |  27.51 ns |    903.5 ns |  1,021.7 ns |    986.4 ns | 0.2661 | 0.0010 |    2232 B |
|       ProtobufToStream |    290.6 ns |   5.69 ns |   6.32 ns |    280.1 ns |    301.4 ns |    289.2 ns | 0.0410 |      - |     344 B |
|      SharpYamlToStream | 48,152.4 ns | 286.14 ns | 238.94 ns | 47,598.9 ns | 48,342.4 ns | 48,234.1 ns | 3.3569 | 0.1221 |   28503 B |
| SystemTextJsonToStream |    366.0 ns |   6.96 ns |   6.51 ns |    352.8 ns |    373.3 ns |    368.1 ns | 0.0591 |      - |     496 B |
|       Utf8JsonToStream |    255.2 ns |   3.05 ns |   2.38 ns |    249.6 ns |    257.0 ns |    256.1 ns | 0.0410 |      - |     344 B |
|            XmlToStream |  5,848.0 ns |  89.27 ns |  83.50 ns |  5,575.4 ns |  5,949.0 ns |  5,875.1 ns | 1.2741 | 0.0153 |   10697 B |
|     YamlDotNetToStream | 16,553.8 ns | 282.88 ns | 250.77 ns | 16,130.5 ns | 16,965.0 ns | 16,535.8 ns | 1.5564 |      - |   13265 B |
|  ZeroFormatterToStream |    179.5 ns |   3.54 ns |   7.54 ns |    151.7 ns |    189.4 ns |    179.8 ns | 0.1826 | 0.0005 |    1528 B |

|                   Method |         Mean |      Error |     StdDev |       Median |          Min |          Max |   Gen0 |   Gen1 | Allocated |
|------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromStream |  6,491.42 ns |  68.184 ns |  60.443 ns |  6,499.45 ns |  6,406.23 ns |  6,615.16 ns | 1.1673 | 0.0305 |    9792 B |
|   DataContractFromStream |  3,077.49 ns |  60.866 ns | 141.067 ns |  3,012.83 ns |  2,911.37 ns |  3,373.17 ns | 1.5182 | 0.0458 |   12720 B |
|            JilFromStream |    366.70 ns |   7.009 ns |   6.557 ns |    365.95 ns |    356.27 ns |    376.62 ns | 0.0734 |      - |     616 B |
|    MessagePackFromStream |    253.70 ns |   2.012 ns |   1.882 ns |    253.19 ns |    251.60 ns |    257.35 ns | 0.0105 |      - |      88 B |
|        MsgPackFromStream |    582.55 ns |   9.362 ns |   8.300 ns |    580.64 ns |    564.77 ns |    595.36 ns | 0.0849 |      - |     712 B |
| NewtonsoftJsonFromStream |  1,671.96 ns |  28.469 ns |  23.773 ns |  1,674.58 ns |  1,603.73 ns |  1,699.22 ns | 0.3967 | 0.0038 |    3320 B |
|       ProtobufFromStream |    253.24 ns |   4.883 ns |   4.795 ns |    251.10 ns |    248.03 ns |    260.50 ns | 0.0105 |      - |      88 B |
|      SharpYamlFromStream |  1,018.30 ns |  20.354 ns |  45.941 ns |  1,000.53 ns |    975.67 ns |  1,125.26 ns | 0.7648 | 0.0038 |    6408 B |
| SystemTextJsonFromStream |    545.64 ns |   2.509 ns |   2.224 ns |    544.95 ns |    542.62 ns |    550.14 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromStream |    393.45 ns |   4.257 ns |   3.774 ns |    392.52 ns |    388.60 ns |    400.67 ns | 0.0105 |      - |      88 B |
|            XmlFromStream |  8,003.54 ns |  94.286 ns |  83.582 ns |  8,021.25 ns |  7,822.34 ns |  8,124.45 ns | 1.0681 | 0.0153 |    9025 B |
|     YamlDotNetFromStream | 12,830.52 ns | 121.738 ns | 113.874 ns | 12,797.76 ns | 12,605.42 ns | 13,042.32 ns | 1.7395 | 0.0458 |   14576 B |
|  ZeroFormatterFromStream |     62.69 ns |   1.269 ns |   2.731 ns |     61.67 ns |     59.33 ns |     68.09 ns | 0.0334 |      - |     280 B |

### FileStream Async

|                        Method |      Mean |     Error |    StdDev |       Min |       Max |    Median |   Gen0 | Allocated |
|------------------------------ |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
|            JilFromStreamAsync |  8.434 μs | 0.1644 μs | 0.2250 μs |  8.219 μs |  8.988 μs |  8.365 μs | 0.1984 |    1721 B |
|    MessagePackFromStreamAsync |  9.323 μs | 0.0502 μs | 0.0469 μs |  9.248 μs |  9.408 μs |  9.325 μs | 0.0610 |     562 B |
|        MsgPackFromStreamAsync |  4.156 μs | 0.0432 μs | 0.0404 μs |  4.105 μs |  4.232 μs |  4.149 μs | 0.4120 |    3488 B |
| NewtonsoftJsonFromStreamAsync | 11.135 μs | 0.0694 μs | 0.0615 μs | 11.011 μs | 11.239 μs | 11.125 μs | 0.5798 |    4589 B |
| SystemTextJsonFromStreamAsync |  7.371 μs | 0.1074 μs | 0.0952 μs |  7.266 μs |  7.595 μs |  7.345 μs | 0.1068 |    1009 B |
|       Utf8JsonFromStreamAsync |  7.000 μs | 0.0456 μs | 0.0405 μs |  6.921 μs |  7.068 μs |  6.999 μs | 0.0763 |     657 B |

### Bytes

|                Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|---------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|         BinaryToBytes |  4,476.0 ns |  42.88 ns |  40.11 ns |  4,435.3 ns |  4,542.2 ns |  4,453.9 ns | 0.8316 | 0.0076 |    6992 B |
|   DataContractToBytes |  1,230.4 ns |  17.50 ns |  16.37 ns |  1,208.3 ns |  1,262.0 ns |  1,226.3 ns | 0.4711 | 0.0019 |    3944 B |
|            JilToBytes |    330.6 ns |   5.34 ns |   5.25 ns |    323.3 ns |    343.0 ns |    330.3 ns | 0.1278 |      - |    1072 B |
|    MessagePackToBytes |    126.7 ns |   1.35 ns |   1.26 ns |    124.6 ns |    128.4 ns |    127.1 ns | 0.0095 |      - |      80 B |
|        MsgPackToBytes |    386.2 ns |   4.68 ns |   4.38 ns |    380.3 ns |    392.9 ns |    384.4 ns | 0.0992 |      - |     832 B |
| NewtonsoftJsonToBytes |    744.7 ns |   5.57 ns |   4.65 ns |    736.6 ns |    752.3 ns |    744.1 ns | 0.2251 |      - |    1888 B |
|       ProtobufToBytes |    295.9 ns |   2.50 ns |   2.34 ns |    292.7 ns |    300.9 ns |    295.0 ns | 0.0486 |      - |     408 B |
|      SharpYamlToBytes | 52,149.1 ns | 596.85 ns | 558.29 ns | 51,555.9 ns | 53,521.9 ns | 51,986.5 ns | 3.2959 | 0.1221 |   28008 B |
| SystemTextJsonToBytes |    335.9 ns |   3.86 ns |   3.42 ns |    331.5 ns |    341.8 ns |    335.3 ns | 0.0172 |      - |     144 B |
|       Utf8JsonToBytes |    236.4 ns |   3.11 ns |   2.75 ns |    232.9 ns |    241.8 ns |    235.8 ns | 0.0181 |      - |     152 B |
|            XmlToBytes |  6,101.2 ns |  84.66 ns |  79.19 ns |  6,010.0 ns |  6,269.1 ns |  6,075.8 ns | 1.3809 | 0.0153 |   11569 B |
|     YamlDotNetToBytes | 17,803.4 ns | 112.41 ns |  93.87 ns | 17,578.6 ns | 17,946.1 ns | 17,812.3 ns | 1.5869 |      - |   13273 B |
|  ZeroFormatterToBytes |    116.0 ns |   1.97 ns |   1.84 ns |    112.7 ns |    118.9 ns |    116.1 ns | 0.1415 |      - |    1184 B |

|                  Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------ |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromBytes |  6,663.79 ns |  89.857 ns |  84.052 ns |  6,585.51 ns |  6,868.56 ns |  6,623.84 ns | 1.1749 | 0.0305 |    9856 B |
|   DataContractFromBytes |  3,551.52 ns |  44.279 ns |  39.253 ns |  3,485.51 ns |  3,615.05 ns |  3,553.81 ns | 1.5373 | 0.0420 |   12872 B |
|            JilFromBytes |    329.90 ns |   6.258 ns |   7.685 ns |    318.13 ns |    343.72 ns |    329.72 ns | 0.0544 |      - |     456 B |
|    MessagePackFromBytes |    219.68 ns |   2.376 ns |   2.106 ns |    217.14 ns |    224.42 ns |    219.01 ns | 0.0105 |      - |      88 B |
|        MsgPackFromBytes |    665.10 ns |   5.163 ns |   4.829 ns |    657.19 ns |    675.63 ns |    664.11 ns | 0.0954 |      - |     800 B |
| NewtonsoftJsonFromBytes |  1,832.35 ns |  34.457 ns |  33.841 ns |  1,793.04 ns |  1,905.41 ns |  1,822.94 ns | 0.3796 |      - |    3176 B |
|       ProtobufFromBytes |    377.73 ns |   3.823 ns |   3.576 ns |    372.53 ns |    384.26 ns |    378.00 ns | 0.0210 |      - |     176 B |
|      SharpYamlFromBytes | 59,176.05 ns | 592.396 ns | 554.127 ns | 58,515.94 ns | 60,215.21 ns | 59,286.00 ns | 3.5400 | 0.1221 |   30236 B |
| SystemTextJsonFromBytes |    497.89 ns |   3.465 ns |   3.241 ns |    487.57 ns |    501.65 ns |    498.34 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromBytes |    351.24 ns |   4.409 ns |   3.909 ns |    347.80 ns |    360.38 ns |    349.57 ns | 0.0105 |      - |      88 B |
|            XmlFromBytes |  8,354.30 ns |  59.500 ns |  52.746 ns |  8,278.91 ns |  8,478.61 ns |  8,350.44 ns | 1.1139 | 0.0153 |    9353 B |
|     YamlDotNetFromBytes | 13,770.97 ns | 268.822 ns | 511.461 ns | 13,163.26 ns | 15,613.03 ns | 13,576.64 ns | 1.7548 | 0.0458 |   14736 B |
|  ZeroFormatterFromBytes |     51.03 ns |   0.841 ns |   0.787 ns |     50.01 ns |     52.79 ns |     50.82 ns | 0.0334 |      - |     280 B |

### Text

|               Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|--------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractToText |  1,394.5 ns |  27.13 ns |  27.86 ns |  1,354.7 ns |  1,450.2 ns |  1,392.8 ns | 0.6084 | 0.0019 |    5104 B |
|            JilToText |    264.0 ns |   1.88 ns |   1.67 ns |    261.3 ns |    266.5 ns |    263.8 ns | 0.1097 |      - |     920 B |
| NewtonsoftJsonToText |    717.7 ns |   4.97 ns |   4.41 ns |    711.9 ns |    725.6 ns |    718.1 ns | 0.2079 |      - |    1744 B |
|      SharpYamlToText | 51,351.7 ns | 961.48 ns | 899.37 ns | 50,346.3 ns | 53,082.1 ns | 50,974.1 ns | 3.0518 | 0.1221 |   26151 B |
| SystemTextJsonToText |    373.8 ns |   5.12 ns |   4.79 ns |    365.3 ns |    383.4 ns |    374.2 ns | 0.0305 |      - |     256 B |
|       Utf8JsonToText |    263.4 ns |   1.50 ns |   1.17 ns |    261.3 ns |    264.9 ns |    263.8 ns | 0.0324 |      - |     272 B |
|            XmlToText |  6,186.5 ns |  93.96 ns |  83.29 ns |  6,114.0 ns |  6,374.1 ns |  6,147.6 ns | 1.4572 | 0.0153 |   12249 B |
|     YamlDotNetToText | 17,880.1 ns | 240.50 ns | 213.20 ns | 17,518.6 ns | 18,254.1 ns | 17,898.4 ns | 1.5564 |      - |   13161 B |

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|   DataContractFromText |  3,628.3 ns |  62.67 ns |  74.61 ns |  3,506.3 ns |  3,837.3 ns |  3,606.9 ns | 1.6060 | 0.0534 |   13464 B |
|            JilFromText |    282.2 ns |   5.30 ns |   5.67 ns |    276.8 ns |    295.2 ns |    279.4 ns | 0.0219 |      - |     184 B |
| NewtonsoftJsonFromText |  1,733.8 ns |  19.82 ns |  18.54 ns |  1,711.3 ns |  1,770.7 ns |  1,734.4 ns | 0.3471 |      - |    2920 B |
|      SharpYamlFromText | 56,163.0 ns | 313.61 ns | 261.88 ns | 55,882.4 ns | 56,873.6 ns | 56,093.0 ns | 3.1738 | 0.1221 |   26860 B |
| SystemTextJsonFromText |    574.1 ns |   8.30 ns |   7.36 ns |    564.6 ns |    588.3 ns |    571.6 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromText |    449.7 ns |   4.07 ns |   3.81 ns |    445.0 ns |    458.2 ns |    449.6 ns | 0.0286 |      - |     240 B |
|            XmlFromText |  8,773.4 ns |  74.13 ns |  69.34 ns |  8,666.0 ns |  8,916.8 ns |  8,767.7 ns | 1.1597 | 0.0153 |    9705 B |
|     YamlDotNetFromText | 13,944.2 ns | 195.83 ns | 173.59 ns | 13,698.2 ns | 14,176.7 ns | 14,029.4 ns | 1.7242 | 0.0458 |   14481 B |
