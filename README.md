# Zaabee.Serializers

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for json.net/protobuf/jil/MsgPack/Utf8Json/xml/ZeroFormatter

## QuickStart

### TestModel

```CSharp
[Serializable]
[ZeroFormattable]
public class TestModel
{
    [Index(0)]
    public Guid Id { get; set; }
    [Index(1)]
    public int Age { get; set; }
    [Index(2)]
    public string Name { get; set; }
    [Index(3)]
    public DateTimeOffset CreateTime { get; set; }
}
```

```CSharp
var testModel = new TestModel
{
    Id = Guid.NewGuid(),
    Age = new Random().Next(0, 100),
    CreateTime = DateTime.Now,
    Name = "banana"
};
```

### [Zaabee.Binary](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Binary)

```CSharp
var bytes = testModel.ToBytes();
var result = bytes.FromBytes<TestModel>();
```

### [Zaabee.Jil](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Jil)

```CSharp
var json = testModel.ToJil();

var result1 = jsonStr.FromJil<TestModel>();
var result2 = jsonStr.FromJil(typeof(TestModel)) as TestModel;
```

### [Zaabee.NewtonsoftJson](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.NewtonsoftJson)

```CSharp
var json1 = testModel.ToJson();
var json2 = testModel.ToJson(new List<string> {"Id", "Name"});
var json3 = testModel.ToJson(null, true);

var result1 = jsonStr.FromJson<TestModel>();
var result2 = jsonStr.FromJson(typeof(TestModel)) as TestModel;
```

### [Zaabee.MsgPack](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.MsgPack)

```CSharp
var bytes = testModel.ToMsgPack();
var result1 = bytes.FromMsgPak<TestModel>();
```

### [Zaabee.Utf8Json](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Utf8Json)

```CSharp
var json = testModel.Utf8JsonToString();
var result1 = json.FromUtf8Json<TestModel>();
var bytes = testModel.Utf8JsonToBytes();
var result2 = bytes.FromUtf8Json<TestModel>();
```

### [Zaabee.Protobuf](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Protobuf)

```CSharp
var bytes = testModel.ToProtobuf();
var deserializeModel1 = bytes.FromProtobuf<TestModel>();
var deserializeModel2 = bytes.FromProtobuf(typeof(TestModel)) as TestModel;
```

### [Zaabee.Xml](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Xml)

```CSharp
var xml1 = testModel.ToXml();
var deserializeModel1 = xml.FromXml<TestModel>();
var deserializeModel2 = xml.FromXml(typeof(TestModel)) as TestModel;

var xml2 = testModel.ToXml(Encoding.UTF32);
var deserializeModel3 = xml.FromXml<TestModel>(Encoding.UTF32);
```

### [Zaabee.ZeroFormatter](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.ZeroFormatter)

```CSharp
var bytes = testModel.ToZeroFormatter();
var result1 = bytes.FromZeroFormatter<TestModel>();
```

## Benchmark

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.100
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

|                   Method |        Mean |      Error |       StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|------------------------- |------------:|-----------:|-------------:|------------:|------------:|------------:|-------:|----------:|
|          BinarySerialize | 17,305.1 ns | 782.444 ns | 2,244.980 ns | 16,653.7 ns | 14,752.8 ns | 23,145.6 ns | 3.5400 |    7450 B |
|             JilSerialize |    734.2 ns |  14.693 ns |    35.203 ns |    726.7 ns |    657.1 ns |    836.0 ns | 0.4377 |     920 B |
|            JsonSerialize |  2,007.0 ns |  40.061 ns |   108.989 ns |  1,986.4 ns |  1,821.0 ns |  2,339.9 ns | 0.9842 |    2072 B |
|         MsgPackSerialize |    990.0 ns |  20.462 ns |    43.607 ns |    977.6 ns |    936.5 ns |  1,116.8 ns | 0.4072 |     856 B |
|  Utf8JsonSerializeString |    795.8 ns |  15.886 ns |    35.857 ns |    784.8 ns |    752.7 ns |    912.4 ns | 0.1287 |     272 B |
|   Utf8JsonSerializeBytes |    643.8 ns |  12.790 ns |    23.386 ns |    640.5 ns |    606.5 ns |    711.3 ns | 0.0715 |     152 B |
|        ProtobufSerialize |  1,522.5 ns |  31.996 ns |    76.042 ns |  1,507.2 ns |  1,398.3 ns |  1,801.8 ns | 0.3834 |     808 B |
|             XmlSerialize | 16,813.8 ns | 335.546 ns |   692.961 ns | 16,638.1 ns | 15,641.2 ns | 18,595.0 ns | 7.4768 |   15696 B |
|   ZeroFormatterSerialize |    327.1 ns |   6.568 ns |     8.540 ns |    326.5 ns |    311.2 ns |    342.3 ns | 0.2017 |     424 B |

|                   Method |        Mean |      Error |       StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|------------------------- |------------:|-----------:|-------------:|------------:|------------:|------------:|-------:|----------:|
|        BinaryDeserialize | 17,960.0 ns | 355.908 ns |   710.787 ns | 17,912.4 ns | 16,572.3 ns | 19,917.8 ns | 4.6387 |    9736 B |
|           JilDeserialize |    873.6 ns |  17.912 ns |    51.967 ns |    859.8 ns |    807.3 ns |  1,018.1 ns | 0.0896 |     192 B |
|          JsonDeserialize |  4,728.2 ns |  93.011 ns |   172.403 ns |  4,696.0 ns |  4,361.1 ns |  5,185.4 ns | 1.4038 |    2960 B |
|       MsgPackDeserialize |  1,580.2 ns |  31.530 ns |    50.916 ns |  1,567.1 ns |  1,482.9 ns |  1,698.4 ns | 0.3872 |     816 B |
|    Utf8DeserializeString |  1,293.6 ns |  25.773 ns |    65.599 ns |  1,270.6 ns |  1,194.4 ns |  1,470.1 ns | 0.1163 |     248 B |
|     Utf8DeserializeBytes |  1,136.7 ns |  22.589 ns |    44.588 ns |  1,128.5 ns |  1,045.5 ns |  1,227.5 ns | 0.0439 |      96 B |
|      ProtobufDeserialize |  2,529.1 ns |  50.462 ns |   109.699 ns |  2,502.8 ns |  2,350.1 ns |  2,816.5 ns | 0.3090 |     656 B |
|           XmlDeserialize | 29,321.3 ns | 675.701 ns | 1,971.051 ns | 28,809.8 ns | 26,181.7 ns | 34,679.1 ns | 4.2114 |    8928 B |
| ZeroFormatterDeserialize |    132.2 ns |   2.656 ns |     4.721 ns |    131.8 ns |    123.8 ns |    144.3 ns | 0.1333 |     280 B |
