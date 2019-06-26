# Zaabee.Serializers

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for json.net/protobuf/jil/Utf8Json/xml

## QuickStart

### TestModel

```CSharp
[Serializable]
public class TestModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
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

## Benchmark

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.529 (1809/October2018Update/Redstone5)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.100
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

|                  Method |       Mean |     Error |     StdDev |        Min |        Max |     Median |   Gen 0 | Allocated |
|------------------------ |-----------:|----------:|-----------:|-----------:|-----------:|-----------:|--------:|----------:|
|         BinarySerialize | 126.028 us | 3.7209 us | 10.8539 us | 106.497 us | 152.004 us | 124.803 us |  9.2773 |   19940 B |
|            JilSerialize |   6.334 us | 0.1633 us |  0.4712 us |   5.479 us |   7.581 us |   6.244 us |  2.3346 |    4904 B |
|           JsonSerialize |  19.405 us | 0.9043 us |  2.6523 us |  14.325 us |  25.242 us |  19.785 us |  2.9907 |    6328 B |
| Utf8JsonSerializeString |   5.681 us | 0.1322 us |  0.3662 us |   5.120 us |   6.952 us |   5.587 us |  0.7706 |    1632 B |
|  Utf8JsonSerializeBytes |   4.868 us | 0.0919 us |  0.2148 us |   4.434 us |   5.407 us |   4.897 us |  0.3891 |     832 B |
|       ProtobufSerialize |   4.332 us | 0.0929 us |  0.2694 us |   3.864 us |   5.095 us |   4.282 us |  0.5798 |    1232 B |
|            XmlSerialize |  66.176 us | 1.5435 us |  4.4285 us |  58.675 us |  78.309 us |  65.349 us | 13.5498 |   28500 B |
|       BinaryDeserialize | 100.838 us | 2.0162 us |  5.3115 us |  88.538 us | 111.820 us | 100.584 us | 10.6201 |   22408 B |
|          JilDeserialize |   7.316 us | 0.1455 us |  0.4009 us |   6.494 us |   8.295 us |   7.262 us |  0.7477 |    1576 B |
|         JsonDeserialize |  35.500 us | 0.8303 us |  2.4482 us |  30.478 us |  41.988 us |  35.363 us |  2.5024 |    5328 B |
|   Utf8DeserializeString |  10.659 us | 0.2110 us |  0.5255 us |   9.757 us |  11.981 us |  10.685 us |  0.8240 |    1736 B |
|    Utf8DeserializeBytes |  10.317 us | 0.4271 us |  1.1765 us |   8.792 us |  13.601 us |  10.080 us |  0.4272 |     904 B |
|     ProtobufDeserialize |  10.787 us | 0.2315 us |  0.6680 us |   9.593 us |  12.517 us |  10.718 us |  0.7172 |    1512 B |
|          XmlDeserialize | 128.613 us | 3.3231 us |  9.7461 us | 108.185 us | 154.670 us | 127.390 us |  8.3008 |   17562 B |
