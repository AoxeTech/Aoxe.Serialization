# Zaabee.Serializers

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for json.net/protobuf/jil/MsgPack/Utf8Json/xml/ZeroFormatter

## QuickStart

### TestModel

```CSharp
[Serializable]
[ProtoContract]
[ZeroFormattable]
public class TestModel
{
    [ProtoMember(1)] [Index(0)] public virtual Guid Id { get; set; }
    [ProtoMember(2)] [Index(1)] public virtual int Age { get; set; }
    [ProtoMember(3)] [Index(2)] public virtual string Name { get; set; }
    [ProtoMember(4)] [Index(3)] public virtual DateTime CreateTime { get; set; }
    [ProtoMember(5)] [Index(4)] public virtual Gender Gender { get; set; }
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
var bytesResult1 = bytes.FromBytes<TestModel>();
var bytesResult2 = bytes.FromBytes(typeof(TestModel));

var stream = testModel.ToStream();
var streamResult = stream.FromStream<TestModel>();

var ms = new MemoryStream();
testModel.PackTo(ms);
var msResult = ms.FromStream<TestModel>();
```

### [Zaabee.Jil](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Jil)

```CSharp
var json = testModel.ToJil();

var result1 = json.FromJil<TestModel>();
var result2 = json.FromJil(typeof(TestModel)) as TestModel;
```

### [Zaabee.NewtonsoftJson](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.NewtonsoftJson)

```CSharp
var json = testModel.ToJson();

var result1 = json.FromJson<TestModel>();
var result2 = json.FromJson(typeof(TestModel)) as TestModel;
```

### [Zaabee.MsgPack](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.MsgPack)

```CSharp
var bytes = testModel.ToMsgPack();
var result = bytes.FromMsgPak<TestModel>();
```

### [Zaabee.Utf8Json](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Utf8Json)

```CSharp
var json = testModel.ToJson();
var result1 = json.FromJson<TestModel>();
var bytes = testModel.ToBytes();
var result2 = bytes.FromBytes<TestModel>();
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

### Serialize

|          Method |        Mean |      Error |       StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|---------------- |------------:|-----------:|-------------:|------------:|------------:|------------:|-------:|----------:|
|   ZeroFormatter |    344.3 ns |   6.837 ns |    14.718 ns |    313.9 ns |    388.5 ns |    341.6 ns | 0.2017 |     424 B |
|   Utf8JsonBytes |    665.3 ns |  13.259 ns |    30.197 ns |    610.7 ns |    759.8 ns |    659.4 ns | 0.0715 |     152 B |
|             Jil |    715.6 ns |  13.449 ns |    11.922 ns |    691.4 ns |    732.7 ns |    718.2 ns | 0.4377 |     920 B |
|  Utf8JsonString |    820.0 ns |  17.972 ns |    27.980 ns |    771.3 ns |    898.3 ns |    821.1 ns | 0.1287 |     272 B |
|         MsgPack |    979.8 ns |  19.256 ns |    34.723 ns |    918.0 ns |  1,057.1 ns |    975.5 ns | 0.4072 |     856 B |
|        Protobuf |  1,036.9 ns |  25.119 ns |    63.936 ns |    953.7 ns |  1,222.1 ns |  1,022.3 ns | 0.3166 |     664 B |
|      NewtonJson |  1,876.5 ns |  36.609 ns |    51.321 ns |  1,789.8 ns |  2,009.2 ns |  1,877.9 ns | 0.9842 |    2072 B |
|          Binary | 15,294.1 ns | 322.520 ns |   680.305 ns | 14,258.9 ns | 17,165.6 ns | 15,373.9 ns | 3.5400 |    7450 B |
|             Xml | 18,742.8 ns | 367.487 ns |   603.791 ns | 17,644.6 ns | 19,874.9 ns | 18,641.5 ns | 7.5684 |   15904 B |

### Deserialize

|          Method |        Mean |      Error |       StdDev |      Median |         Min |         Max |  Gen 0 | Allocated |
|---------------- |------------:|-----------:|-------------:|------------:|------------:|------------:|-------:|----------:|
|   ZeroFormatter |    135.7 ns |   2.733 ns |     6.704 ns |    124.0 ns |    153.0 ns |    135.2 ns | 0.1333 |     280 B |
|             Jil |    936.1 ns |  20.958 ns |    61.795 ns |    824.0 ns |  1,098.0 ns |    932.0 ns | 0.0896 |     192 B |
|   Utf8JsonBytes |  1,160.8 ns |  23.067 ns |    64.683 ns |  1,044.7 ns |  1,320.7 ns |  1,150.3 ns | 0.0439 |      96 B |
|  Utf8JsonString |  1,346.4 ns |  26.723 ns |    38.325 ns |  1,271.3 ns |  1,429.0 ns |  1,348.1 ns | 0.1163 |     248 B |
|        Protobuf |  1,578.1 ns |  33.284 ns |    32.689 ns |  1,526.0 ns |  1,645.8 ns |  1,575.2 ns | 0.2098 |     440 B |
|         MsgPack |  1,787.5 ns |  34.918 ns |    66.434 ns |  1,661.5 ns |  1,936.9 ns |  1,792.7 ns | 0.3853 |     816 B |
|      NewtonJson |  4,873.8 ns |  96.720 ns |   193.161 ns |  4,416.9 ns |  5,307.1 ns |  4,878.2 ns | 1.4038 |    2960 B |
|          Binary | 18,457.0 ns | 367.981 ns |   759.944 ns | 17,249.2 ns | 20,345.6 ns | 18,324.6 ns | 4.6387 |    9736 B |
|             Xml | 30,689.0 ns | 654.219 ns | 1,128.495 ns | 28,955.6 ns | 33,292.7 ns | 30,540.3 ns | 4.3335 |    9136 B |
