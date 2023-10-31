# Zaabee.Serialization

---

[![Build Status](https://dev.azure.com/Zaabee/Zaabee.Serialization/_apis/build/status/Mutuduxf.Zaabee.Serialization?branchName=master)](https://dev.azure.com/Zaabee/Zaabee.Serialization/_build/latest?definitionId=1&branchName=master)

Provide an easy way to use serializations. It is also the serializer provider for all Zaabee technology stacks like configuration, cache, queue, rpc, etc.

## Why use Zaabee.Serialization?

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

Faster than Any Binary?

### Zaabee.NetJson

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
BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.1105/22H2/2022Update/SunValley2)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100-rc.2.23502.2
[Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
DefaultJob : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
```

IterationCount=1000  RunStrategy=Monitoring

## To Text

| Method               | Mean        | Error     | StdDev    | Min         | Max         | Median      | Gen0   | Gen1   | Allocated |
|--------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
| DataContractToText   |  1,188.7 ns |  16.32 ns |  15.27 ns |  1,165.3 ns |  1,212.8 ns |  1,187.9 ns | 0.5779 | 0.0019 |    4848 B |
| JilToText            |    236.3 ns |   4.70 ns |   7.32 ns |    213.7 ns |    251.1 ns |    238.1 ns | 0.1099 |      - |     920 B |
| NetJsonToText        |    268.3 ns |   5.31 ns |   6.32 ns |    255.0 ns |    278.3 ns |    269.8 ns | 0.0668 |      - |     560 B |
| NewtonsoftJsonToText |    596.0 ns |  11.73 ns |  16.82 ns |    546.7 ns |    622.4 ns |    601.2 ns | 0.2079 |      - |    1744 B |
| SharpYamlToText      | 42,325.7 ns | 224.78 ns | 175.49 ns | 41,974.8 ns | 42,580.6 ns | 42,376.8 ns | 2.9297 |      - |   26490 B |
| SpanJsonToText       |    173.7 ns |   1.86 ns |   1.55 ns |    171.3 ns |    176.2 ns |    174.1 ns | 0.0505 |      - |     424 B |
| SystemTextJsonToText |    287.7 ns |   5.49 ns |   5.87 ns |    278.7 ns |    298.7 ns |    287.3 ns | 0.0305 |      - |     256 B |
| Utf8JsonToText       |    213.4 ns |   3.91 ns |   3.47 ns |    207.1 ns |    218.0 ns |    213.4 ns | 0.0315 |      - |     264 B |
| XmlToText            |  6,422.6 ns |  81.76 ns |  76.48 ns |  6,304.9 ns |  6,542.8 ns |  6,416.1 ns | 1.4343 | 0.0305 |   12033 B |
| YamlDotNetToText     | 13,741.7 ns | 167.93 ns | 148.86 ns | 13,366.0 ns | 13,962.5 ns | 13,746.9 ns | 1.7853 | 0.0153 |   14978 B |

## From Text

| Method                 | Mean        | Error     | StdDev    | Min         | Max         | Median      | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|----------:|----------:|------------:|------------:|------------:|-------:|-------:|----------:|
| DataContractFromText   |  3,181.6 ns |  62.65 ns | 140.12 ns |  2,964.5 ns |  3,520.6 ns |  3,154.2 ns | 1.5869 | 0.0458 |   13376 B |
| JilFromText            |    282.5 ns |   5.38 ns |   5.03 ns |    276.6 ns |    289.5 ns |    280.9 ns | 0.0219 |      - |     184 B |
| NetJsonFromText        |    488.5 ns |   9.47 ns |   8.85 ns |    473.0 ns |    499.5 ns |    490.9 ns | 0.0706 |      - |     592 B |
| NewtonsoftJsonFromText |  1,051.5 ns |  20.82 ns |  19.48 ns |  1,020.1 ns |  1,100.7 ns |  1,049.7 ns | 0.3471 | 0.0019 |    2920 B |
| SharpYamlFromText      | 44,351.1 ns | 490.03 ns | 458.37 ns | 43,679.6 ns | 45,324.0 ns | 44,285.2 ns | 3.1738 |      - |   27125 B |
| SpanJsonFromText       |    228.0 ns |   3.20 ns |   3.00 ns |    219.2 ns |    231.8 ns |    227.9 ns | 0.0286 |      - |     240 B |
| SystemTextJsonFromText |    427.2 ns |   5.99 ns |   5.61 ns |    418.0 ns |    435.5 ns |    426.4 ns | 0.0105 |      - |      88 B |
| Utf8JsonFromText       |    394.1 ns |   5.24 ns |   4.90 ns |    386.8 ns |    401.7 ns |    395.5 ns | 0.0286 |      - |     240 B |
| XmlFromText            |  8,074.1 ns | 143.12 ns | 164.82 ns |  7,755.2 ns |  8,472.3 ns |  8,133.5 ns | 1.1292 |      - |    9542 B |
| YamlDotNetFromText     | 10,260.9 ns |  92.87 ns |  86.87 ns | 10,099.3 ns | 10,392.2 ns | 10,254.0 ns | 1.6937 | 0.0458 |   14193 B |

## To Bytes

| Method                | Mean         | Error      | StdDev     | Median       | Min          | Max          | Gen0   | Gen1   | Allocated |
|---------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
| DataContractToBytes   |  1,022.25 ns |  20.287 ns |  19.925 ns |  1,021.84 ns |    989.77 ns |  1,064.43 ns | 0.4406 | 0.0019 |    3688 B |
| JilToBytes            |    267.78 ns |   5.335 ns |  13.961 ns |    269.41 ns |    242.19 ns |    297.31 ns | 0.1278 |      - |    1072 B |
| MemoryPackToBytes     |     64.16 ns |   1.270 ns |   1.061 ns |     63.82 ns |     62.87 ns |     66.74 ns | 0.0086 |      - |      72 B |
| MessagePackToBytes    |    123.78 ns |   1.378 ns |   1.289 ns |    123.20 ns |    122.22 ns |    126.74 ns | 0.0095 |      - |      80 B |
| MsgPackToBytes        |    314.99 ns |   6.169 ns |   9.233 ns |    317.20 ns |    291.55 ns |    328.55 ns | 0.0935 |      - |     784 B |
| NetJsonToBytes        |    316.61 ns |   6.055 ns |   6.478 ns |    318.19 ns |    301.60 ns |    326.85 ns | 0.0849 |      - |     712 B |
| NewtonsoftJsonToBytes |    646.41 ns |  12.876 ns |  29.842 ns |    642.93 ns |    602.96 ns |    701.68 ns | 0.2251 |      - |    1888 B |
| ProtobufToBytes       |    302.79 ns |   5.498 ns |   6.545 ns |    303.93 ns |    289.50 ns |    316.51 ns | 0.0486 |      - |     408 B |
| SharpYamlToBytes      | 43,964.54 ns | 525.816 ns | 466.122 ns | 44,016.81 ns | 42,651.15 ns | 44,575.12 ns | 3.1738 |      - |   28339 B |
| SpanJsonToBytes       |    131.77 ns |   1.359 ns |   1.061 ns |    132.11 ns |    128.92 ns |    133.03 ns | 0.0181 |      - |     152 B |
| SystemTextJsonToBytes |    242.16 ns |   4.802 ns |   4.492 ns |    242.68 ns |    236.65 ns |    249.44 ns | 0.0172 |      - |     144 B |
| Utf8JsonToBytes       |    187.70 ns |   2.922 ns |   2.440 ns |    188.21 ns |    182.21 ns |    191.30 ns | 0.0181 |      - |     152 B |
| XmlToBytes            |  6,134.93 ns | 118.022 ns | 121.200 ns |  6,165.86 ns |  5,790.62 ns |  6,285.02 ns | 1.3504 | 0.0381 |   11353 B |
| YamlDotNetToBytes     | 13,891.84 ns | 135.304 ns | 119.943 ns | 13,887.94 ns | 13,621.94 ns | 14,097.05 ns | 1.8005 | 0.0153 |   15130 B |
| ZeroFormatterToBytes  |     95.99 ns |   3.615 ns |  10.601 ns |     91.45 ns |     82.90 ns |    128.45 ns | 0.1415 | 0.0005 |    1184 B |

## From Bytes

| Method                  | Mean         | Error      | StdDev     | Min          | Max          | Median       | Gen0   | Gen1   | Allocated |
|------------------------ |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
| DataContractFromBytes   |  3,078.37 ns |  60.746 ns | 128.133 ns |  2,848.64 ns |  3,398.08 ns |  3,036.68 ns | 1.5259 | 0.0458 |   12784 B |
| JilFromBytes            |    344.26 ns |   6.461 ns |   6.044 ns |    331.66 ns |    354.58 ns |    345.44 ns | 0.0553 |      - |     464 B |
| MemoryPackFromBytes     |     57.15 ns |   1.125 ns |   1.105 ns |     55.93 ns |     59.42 ns |     56.72 ns | 0.0105 |      - |      88 B |
| MessagePackFromBytes    |    205.90 ns |   2.446 ns |   2.288 ns |    202.76 ns |    209.20 ns |    206.05 ns | 0.0105 |      - |      88 B |
| MsgPackFromBytes        |    448.06 ns |   8.116 ns |   7.591 ns |    436.89 ns |    460.41 ns |    449.23 ns | 0.0925 |      - |     776 B |
| NetJsonFromBytes        |    527.10 ns |  10.504 ns |  12.097 ns |    512.85 ns |    552.94 ns |    521.57 ns | 0.1030 |      - |     864 B |
| NewtonsoftJsonFromBytes |  1,185.07 ns |  17.571 ns |  13.718 ns |  1,148.38 ns |  1,198.58 ns |  1,189.71 ns | 0.3796 |      - |    3176 B |
| ProtobufFromBytes       |    314.19 ns |   4.770 ns |   4.229 ns |    304.61 ns |    319.53 ns |    315.81 ns | 0.0210 |      - |     176 B |
| SharpYamlFromBytes      | 47,744.01 ns | 830.320 ns | 736.057 ns | 46,398.27 ns | 48,587.28 ns | 47,821.22 ns | 3.4180 |      - |   30501 B |
| SpanJsonFromBytes       |    170.90 ns |   2.836 ns |   2.653 ns |    167.22 ns |    175.10 ns |    170.50 ns | 0.0105 |      - |      88 B |
| SystemTextJsonFromBytes |    403.74 ns |   6.524 ns |   5.783 ns |    394.87 ns |    415.02 ns |    403.26 ns | 0.0105 |      - |      88 B |
| Utf8JsonFromBytes       |    356.32 ns |   7.153 ns |   8.516 ns |    343.24 ns |    376.01 ns |    357.93 ns | 0.0105 |      - |      88 B |
| XmlFromBytes            |  8,411.10 ns | 165.114 ns | 154.448 ns |  8,169.12 ns |  8,774.27 ns |  8,412.30 ns | 1.0681 |      - |    9185 B |
| YamlDotNetFromBytes     | 10,665.86 ns | 198.732 ns | 176.171 ns | 10,441.80 ns | 10,961.06 ns | 10,654.92 ns | 1.7242 | 0.0458 |   14457 B |
| ZeroFormatterFromBytes  |     48.25 ns |   0.987 ns |   2.582 ns |     44.07 ns |     57.22 ns |     48.23 ns | 0.0334 |      - |     280 B |

## To Stream

| Method                 | Mean        | Error     | StdDev      | Median      | Min          | Max         | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|----------:|------------:|------------:|-------------:|------------:|-------:|-------:|----------:|
| DataContractToStream   |  1,005.4 ns |  18.69 ns |    16.57 ns |  1,002.4 ns |    971.80 ns |  1,033.5 ns | 0.3700 |      - |    3096 B |
| JilToStream            |    301.2 ns |   5.77 ns |    13.83 ns |    303.9 ns |    272.91 ns |    331.6 ns | 0.1693 | 0.0005 |    1416 B |
| MemoryPackToStream     |    103.0 ns |   2.09 ns |     5.32 ns |    101.7 ns |     94.83 ns |    114.8 ns | 0.0783 |      - |     656 B |
| MessagePackToStream    |    260.5 ns |   5.19 ns |     5.33 ns |    261.8 ns |    248.89 ns |    268.5 ns | 0.0410 |      - |     344 B |
| MsgPackToStream        |    302.1 ns |   6.04 ns |     8.26 ns |    303.2 ns |    278.98 ns |    314.4 ns | 0.0858 |      - |     720 B |
| NetJsonToStream        |    375.2 ns |   7.46 ns |    14.72 ns |    376.4 ns |    341.05 ns |    405.6 ns | 0.1259 |      - |    1056 B |
| NewtonsoftJsonToStream |    770.3 ns |  19.84 ns |    58.19 ns |    757.9 ns |    680.35 ns |    935.0 ns | 0.2661 |      - |    2232 B |
| ProtobufToStream       |    315.2 ns |   3.93 ns |     3.28 ns |    314.9 ns |    309.67 ns |    320.6 ns | 0.0410 |      - |     344 B |
| SharpYamlToStream      | 47,957.8 ns | 954.08 ns | 1,948.93 ns | 47,664.0 ns | 44,666.99 ns | 53,052.8 ns | 3.1738 |      - |   28194 B |
| SpanJsonToStream       |    181.8 ns |   3.88 ns |    11.31 ns |    178.0 ns |    165.17 ns |    210.9 ns | 0.0591 |      - |     496 B |
| SystemTextJsonToStream |    330.1 ns |   6.54 ns |     7.00 ns |    330.5 ns |    320.99 ns |    340.6 ns | 0.0591 |      - |     496 B |
| Utf8JsonToStream       |    212.0 ns |   1.94 ns |     1.62 ns |    211.5 ns |    209.60 ns |    214.5 ns | 0.0410 |      - |     344 B |
| XmlToStream            |  6,124.0 ns | 103.11 ns |    96.44 ns |  6,164.8 ns |  5,839.73 ns |  6,195.9 ns | 1.3123 | 0.0229 |   11001 B |
| YamlDotNetToStream     | 13,883.4 ns | 161.75 ns |   151.30 ns | 13,848.5 ns | 13,658.34 ns | 14,174.3 ns | 1.8158 | 0.0153 |   15194 B |
| ZeroFormatterToStream  |    138.5 ns |   4.19 ns |    12.15 ns |    133.2 ns |    125.00 ns |    168.3 ns | 0.1826 | 0.0005 |    1528 B |

## From Stream

| Method                   | Mean         | Error      | StdDev     | Median       | Min          | Max          | Gen0   | Gen1   | Allocated |
|------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|-------:|----------:|
| DataContractFromStream   |  3,094.84 ns |  61.187 ns | 105.544 ns |  3,067.03 ns |  2,940.95 ns |  3,378.57 ns | 1.5182 | 0.0458 |   12720 B |
| JilFromStream            |    365.96 ns |   6.471 ns |   6.053 ns |    363.64 ns |    359.01 ns |    378.88 ns | 0.0734 |      - |     616 B |
| MemoryPackFromStream     |     78.62 ns |   0.975 ns |   0.912 ns |     78.46 ns |     77.03 ns |     80.34 ns | 0.0191 |      - |     160 B |
| MessagePackFromStream    |    226.97 ns |   3.512 ns |   3.285 ns |    228.40 ns |    220.18 ns |    229.93 ns | 0.0105 |      - |      88 B |
| MsgPackFromStream        |    431.60 ns |   5.564 ns |   5.204 ns |    433.92 ns |    417.54 ns |    437.13 ns | 0.0849 |      - |     712 B |
| NetJsonFromStream        |    542.81 ns |   9.069 ns |   8.483 ns |    544.56 ns |    523.94 ns |    554.22 ns | 0.1211 |      - |    1016 B |
| NewtonsoftJsonFromStream |  1,137.51 ns |  22.662 ns |  37.234 ns |  1,126.40 ns |  1,089.18 ns |  1,196.22 ns | 0.3967 | 0.0038 |    3320 B |
| ProtobufFromStream       |    224.83 ns |   2.907 ns |   2.719 ns |    225.37 ns |    220.74 ns |    229.43 ns | 0.0105 |      - |      88 B |
| SharpYamlFromStream      |    959.82 ns |  18.269 ns |  50.624 ns |    944.00 ns |    887.07 ns |  1,099.78 ns | 0.7648 | 0.0038 |    6408 B |
| SpanJsonFromStream       |    214.90 ns |   2.809 ns |   2.628 ns |    215.50 ns |    208.70 ns |    217.90 ns | 0.0286 |      - |     240 B |
| SystemTextJsonFromStream |    453.29 ns |   8.637 ns |   9.600 ns |    450.00 ns |    442.31 ns |    475.25 ns | 0.0105 |      - |      88 B |
| Utf8JsonFromStream       |    370.18 ns |   6.465 ns |   6.047 ns |    366.47 ns |    362.66 ns |    379.03 ns | 0.0105 |      - |      88 B |
| XmlFromStream            |  7,750.38 ns | 128.853 ns | 120.529 ns |  7,703.26 ns |  7,600.00 ns |  7,924.12 ns | 1.0986 |      - |    9196 B |
| YamlDotNetFromStream     | 10,321.74 ns |  83.572 ns |  78.174 ns | 10,335.67 ns | 10,170.37 ns | 10,471.06 ns | 1.7395 | 0.0458 |   14609 B |
| ZeroFormatterFromStream  |     52.81 ns |   1.038 ns |   1.846 ns |     52.22 ns |     50.16 ns |     57.38 ns | 0.0334 |      - |     280 B |
