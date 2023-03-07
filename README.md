# Zaabee.Serializations

---

[![Build Status](https://dev.azure.com/Zaabee/Zaabee.Serializations/_apis/build/status/Mutuduxf.Zaabee.Serializations?branchName=master)](https://dev.azure.com/Zaabee/Zaabee.Serializations/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for serializers. It is also the serializer provider for all Zaabee technology stacks.

## Why use Zaabee.Serializations?

There are many different serializers in the world, they have different features and limitations. This project allows you to use difference serializers in the same way. Also it set nullable and default value for all serializers.

Serializers can be divided into two categories:

- Binary serializers
  - BinaryFormatter
  - MemoryPack
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
PM> Install-Package Zaabee.Binary
PM> Install-Package Zaabee.DataContractSerializer
PM> Install-Package Zaabee.Jil
PM> Install-Package Zaabee.MemoryPack
PM> Install-Package Zaabee.MessagePack
PM> Install-Package Zaabee.MsgPack
PM> Install-Package Zaabee.NewtonsoftJson
PM> Install-Package Zaabee.Utf8Json
PM> Install-Package Zaabee.Protobuf
PM> Install-Package Zaabee.SharpYaml
PM> Install-Package Zaabee.SystemTextJson
PM> Install-Package Zaabee.Xml
PM> Install-Package Zaabee.YamlDotNet
PM> Install-Package Zaabee.ZeroFormatter
```

### [Zaabee.Binary](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.Binary)

Base by System.Runtime.Serialization.Formatters.Binary.BinaryFormatter, the first party BinaryFormatter from microsoft.

### [Zaabee.DataContractSerializer](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.DataContractSerializer)

Base by System.Runtime.Serialization.DataContractSerializer, serializes and deserializes an instance of a type into an XML stream or document using a supplied data contract.

### [Zaabee.Jil](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.Jil)

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

### [Zaabee.MemoryPack](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.MemoryPack)

Zero encoding extreme performance binary serializer for C# and Unity.

### [Zaabee.MessagePack](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.MessagePack)

The extremely fast MessagePack serializer for C#. It is 10x faster than MsgPack-Cli and outperforms other C# serializers. MessagePack for C# also ships with built-in support for LZ4 compression - an extremely fast compression algorithm. Performance is important, particularly in applications like games, distributed computing, microservices, or data caches.

### [Zaabee.MsgPack](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.MsgPack)

MessagePack implementation for Common Language Infrastructure / msgpack.org[C#]

### [Zaabee.NewtonsoftJson](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.NewtonsoftJson)

Json.NET is a popular high-performance JSON framework for .NET [https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)

### [Zaabee.Utf8Json](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.Utf8Json)

Definitely Fastest and Zero Allocation JSON Serializer for C#(NET, .NET Core, Unity, Xamarin).

### [Zaabee.Protobuf](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.Protobuf)

protobuf-net is a contract based serializer for .NET code, that happens to write data in the "protocol buffers" serialization format engineered by Google. The API, however, is very different to Google's, and follows typical .NET patterns (it is broadly comparable, in usage, to XmlSerializer, DataContractSerializer, etc). It should work for most .NET languages that write standard types and can use attributes.

### [Zaabee.SharpYaml](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.SharpYaml)

SharpYaml is a .NET library that provides a YAML parser and serialization engine for .NET objects, compatible with CoreCLR.

### [Zaabee.SystemTextJson](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.SystemTextJson)

The System.Text.Json namespace provides high-performance, low-allocating, and standards-compliant capabilities to process JavaScript Object Notation (JSON), which includes serializing objects to JSON text and deserializing JSON text to objects, with UTF-8 support built-in. It also provides types to read and write JSON text encoded as UTF-8, and to create an in-memory document object model (DOM) for random access of the JSON elements within a structured view of the data.

### [Zaabee.Xml](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.Xml)

Serializes and deserializes objects into and from XML documents. The XmlSerializer enables you to control how objects are encoded into XML.

### [Zaabee.YamlDotNet](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.YamlDotNet)

YamlDotNet is a YAML library for netstandard and other .NET runtimes.

YamlDotNet provides low level parsing and emitting of YAML as well as a high level object model similar to XmlDocument. A serialization library is also included that allows to read and write objects from and to YAML streams.

### [Zaabee.ZeroFormatter](https://github.com/PicoHex/Zaabee.Serializations/tree/master/src/Zaabee.ZeroFormatter)

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

|                Method |         Mean |      Error |       StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|---------------------- |-------------:|-----------:|-------------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryToBytes |  4,987.47 ns |  71.184 ns |    59.442 ns |  4,836.92 ns |  5,065.51 ns |  5,001.74 ns | 0.8316 | 0.0153 |    6992 B |
|   DataContractToBytes |  1,214.89 ns |  24.269 ns |    64.779 ns |  1,119.84 ns |  1,387.79 ns |  1,201.78 ns | 0.4406 | 0.0019 |    3688 B |
|            JilToBytes |    292.61 ns |   5.788 ns |     6.890 ns |    275.03 ns |    304.00 ns |    293.36 ns | 0.1268 |      - |    1064 B |
|     MemoryPackToBytes |     75.54 ns |   0.652 ns |     0.509 ns |     74.51 ns |     76.56 ns |     75.58 ns | 0.0086 |      - |      72 B |
|    MessagePackToBytes |    130.98 ns |   2.132 ns |     1.780 ns |    128.72 ns |    135.52 ns |    130.58 ns | 0.0095 |      - |      80 B |
|        MsgPackToBytes |    430.01 ns |   8.043 ns |     9.878 ns |    404.00 ns |    449.21 ns |    430.90 ns | 0.0935 |      - |     784 B |
| NewtonsoftJsonToBytes |    790.07 ns |  14.989 ns |    17.843 ns |    746.30 ns |    819.93 ns |    794.47 ns | 0.2251 |      - |    1888 B |
|       ProtobufToBytes |    330.01 ns |   5.525 ns |     5.168 ns |    317.65 ns |    338.22 ns |    329.77 ns | 0.0486 |      - |     408 B |
|      SharpYamlToBytes | 52,566.54 ns | 999.230 ns | 1,263.706 ns | 50,510.43 ns | 54,622.47 ns | 52,595.25 ns | 3.4180 | 0.1221 |   28887 B |
| SystemTextJsonToBytes |    316.65 ns |   6.229 ns |     9.323 ns |    306.69 ns |    339.88 ns |    313.68 ns | 0.0172 |      - |     144 B |
|       Utf8JsonToBytes |    212.69 ns |   4.145 ns |     4.257 ns |    205.83 ns |    220.65 ns |    213.07 ns | 0.0181 |      - |     152 B |
|            XmlToBytes |  6,626.78 ns |  93.163 ns |    82.586 ns |  6,508.13 ns |  6,790.26 ns |  6,603.06 ns | 1.3351 | 0.0381 |   11225 B |
|     YamlDotNetToBytes | 16,924.27 ns | 252.382 ns |   236.078 ns | 16,607.94 ns | 17,392.12 ns | 16,905.08 ns | 1.7090 |      - |   14417 B |
|  ZeroFormatterToBytes |    118.65 ns |   2.361 ns |     6.463 ns |    106.97 ns |    137.21 ns |    118.12 ns | 0.1415 | 0.0002 |    1184 B |

## From Bytes

|                  Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------ |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromBytes |  6,576.95 ns | 120.655 ns | 112.860 ns |  6,256.77 ns |  6,705.43 ns |  6,622.37 ns | 1.1749 | 0.0305 |    9856 B |
|   DataContractFromBytes |  3,361.70 ns |  63.724 ns |  73.385 ns |  3,101.38 ns |  3,458.00 ns |  3,367.21 ns | 1.5259 | 0.0458 |   12784 B |
|            JilFromBytes |    356.12 ns |   6.263 ns |   7.920 ns |    339.68 ns |    374.37 ns |    355.06 ns | 0.0553 |      - |     464 B |
|     MemoryPackFromBytes |     63.54 ns |   1.282 ns |   1.526 ns |     60.84 ns |     65.59 ns |     63.62 ns | 0.0105 |      - |      88 B |
|    MessagePackFromBytes |    209.91 ns |   3.979 ns |   3.722 ns |    204.98 ns |    215.93 ns |    209.62 ns | 0.0105 |      - |      88 B |
|        MsgPackFromBytes |    637.16 ns |  11.740 ns |  10.407 ns |    623.06 ns |    658.49 ns |    636.04 ns | 0.0925 |      - |     776 B |
| NewtonsoftJsonFromBytes |  1,703.32 ns |  32.754 ns |  42.589 ns |  1,580.40 ns |  1,792.70 ns |  1,704.39 ns | 0.3796 |      - |    3176 B |
|       ProtobufFromBytes |    378.97 ns |   4.883 ns |   4.328 ns |    371.15 ns |    387.95 ns |    378.32 ns | 0.0210 |      - |     176 B |
|      SharpYamlFromBytes | 56,073.10 ns | 459.833 ns | 430.128 ns | 55,579.39 ns | 56,954.84 ns | 56,077.51 ns | 3.6621 | 0.1831 |   31012 B |
| SystemTextJsonFromBytes |    420.99 ns |   8.333 ns |   8.184 ns |    406.84 ns |    430.00 ns |    422.55 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromBytes |    382.05 ns |   6.425 ns |   6.010 ns |    371.80 ns |    390.43 ns |    383.89 ns | 0.0105 |      - |      88 B |
|            XmlFromBytes |  8,592.52 ns | 105.360 ns |  93.398 ns |  8,396.27 ns |  8,744.24 ns |  8,594.79 ns | 1.0986 | 0.0153 |    9265 B |
|     YamlDotNetFromBytes | 12,363.14 ns | 246.078 ns | 241.682 ns | 12,090.82 ns | 12,792.97 ns | 12,268.50 ns | 1.7242 | 0.0458 |   14480 B |
|  ZeroFormatterFromBytes |     54.31 ns |   1.129 ns |   3.292 ns |     49.28 ns |     63.29 ns |     53.74 ns | 0.0334 |      - |     280 B |

## To Stream

|                 Method |        Mean |     Error |    StdDev |         Min |         Max |      Median |   Gen0 |   Gen1 | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
|         BinaryToStream |  4,712.3 ns |  82.99 ns |  69.30 ns |  4,574.6 ns |  4,844.6 ns |  4,717.5 ns | 0.7782 | 0.0076 |    6528 B |
|   DataContractToStream |  1,216.5 ns |  24.31 ns |  22.74 ns |  1,177.8 ns |  1,250.4 ns |  1,216.7 ns | 0.3700 |      - |    3096 B |
|            JilToStream |    367.8 ns |   8.71 ns |  25.26 ns |    310.5 ns |    429.2 ns |    365.1 ns | 0.1693 |      - |    1416 B |
|     MemoryPackToStream |    142.4 ns |   3.34 ns |   9.62 ns |    124.7 ns |    166.5 ns |    140.7 ns | 0.0782 |      - |     656 B |
|    MessagePackToStream |    305.1 ns |   5.54 ns |   4.91 ns |    294.5 ns |    314.0 ns |    305.7 ns | 0.0410 |      - |     344 B |
|        MsgPackToStream |    362.1 ns |   6.79 ns |  10.16 ns |    333.2 ns |    380.3 ns |    366.0 ns | 0.0858 |      - |     720 B |
| NewtonsoftJsonToStream |    801.2 ns |  14.99 ns |  19.49 ns |    741.9 ns |    834.5 ns |    803.0 ns | 0.2661 | 0.0010 |    2232 B |
|       ProtobufToStream |    307.2 ns |   5.42 ns |   7.23 ns |    297.2 ns |    325.2 ns |    303.9 ns | 0.0410 |      - |     344 B |
|      SharpYamlToStream | 51,208.9 ns | 967.47 ns | 950.18 ns | 49,738.5 ns | 52,850.5 ns | 51,320.2 ns | 3.4180 | 0.1221 |   28735 B |
| SystemTextJsonToStream |    366.4 ns |   2.53 ns |   2.11 ns |    363.3 ns |    370.6 ns |    366.2 ns | 0.0591 |      - |     496 B |
|       Utf8JsonToStream |    253.1 ns |   5.00 ns |   5.95 ns |    242.5 ns |    265.3 ns |    252.5 ns | 0.0410 |      - |     344 B |
|            XmlToStream |  6,796.8 ns | 127.69 ns | 136.62 ns |  6,422.2 ns |  6,984.1 ns |  6,784.3 ns | 1.2970 |      - |   10841 B |
|     YamlDotNetToStream | 17,734.9 ns | 354.65 ns | 331.74 ns | 17,216.4 ns | 18,396.9 ns | 17,757.9 ns | 1.7090 |      - |   14481 B |
|  ZeroFormatterToStream |    198.2 ns |   6.65 ns |  19.30 ns |    168.3 ns |    255.8 ns |    198.6 ns | 0.1826 | 0.0005 |    1528 B |

## From Stream

|                   Method |         Mean |      Error |     StdDev |          Min |          Max |       Median |   Gen0 |   Gen1 | Allocated |
|------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
|         BinaryFromStream |  6,617.83 ns | 131.732 ns | 175.858 ns |  6,234.47 ns |  6,921.91 ns |  6,645.71 ns | 1.1673 | 0.0305 |    9792 B |
|   DataContractFromStream |  3,138.78 ns |  60.659 ns |  53.772 ns |  3,077.54 ns |  3,278.26 ns |  3,127.56 ns | 1.5182 | 0.0458 |   12720 B |
|            JilFromStream |    381.52 ns |   6.998 ns |   6.546 ns |    372.65 ns |    391.66 ns |    381.03 ns | 0.0734 |      - |     616 B |
|     MemoryPackFromStream |     90.00 ns |   1.772 ns |   1.480 ns |     87.71 ns |     92.44 ns |     90.35 ns | 0.0191 |      - |     160 B |
|    MessagePackFromStream |    249.70 ns |   4.944 ns |   4.856 ns |    239.24 ns |    256.75 ns |    251.16 ns | 0.0105 |      - |      88 B |
|        MsgPackFromStream |    610.39 ns |  11.741 ns |  10.983 ns |    586.17 ns |    624.97 ns |    613.34 ns | 0.0849 |      - |     712 B |
| NewtonsoftJsonFromStream |  1,684.46 ns |  33.577 ns |  31.408 ns |  1,585.85 ns |  1,724.34 ns |  1,687.75 ns | 0.3929 | 0.0019 |    3296 B |
|       ProtobufFromStream |    272.48 ns |   5.149 ns |   5.723 ns |    258.62 ns |    279.10 ns |    273.94 ns | 0.0105 |      - |      88 B |
|      SharpYamlFromStream |  1,077.03 ns |  19.478 ns |  24.633 ns |    991.26 ns |  1,115.52 ns |  1,077.67 ns | 0.7648 | 0.0038 |    6408 B |
| SystemTextJsonFromStream |    526.23 ns |   4.214 ns |   3.519 ns |    520.38 ns |    533.05 ns |    525.67 ns | 0.0105 |      - |      88 B |
|       Utf8JsonFromStream |    376.94 ns |   7.420 ns |   7.287 ns |    363.75 ns |    392.27 ns |    379.00 ns | 0.0105 |      - |      88 B |
|            XmlFromStream |  8,655.45 ns |  70.547 ns |  62.538 ns |  8,523.14 ns |  8,754.58 ns |  8,655.51 ns | 1.0986 |      - |    9201 B |
|     YamlDotNetFromStream | 13,136.67 ns | 162.207 ns | 143.793 ns | 12,879.25 ns | 13,342.91 ns | 13,156.62 ns | 1.7395 | 0.0458 |   14640 B |
|  ZeroFormatterFromStream |     67.33 ns |   1.241 ns |   1.569 ns |     64.74 ns |     72.05 ns |     66.98 ns | 0.0334 |      - |     280 B |
