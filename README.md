# Zaabee.Serializers

[![Build Status](https://dev.azure.com/Zaabee/Zaabee/_apis/build/status/Mutuduxf.Zaabee.Serializers?branchName=master)](https://dev.azure.com/Zaabee/Zaabee/_build/latest?definitionId=1&branchName=master)

The wraps and extensions for json.net/protobuf/jil/Utf8Json/xml

## QuickStart

### TestModel

```CSharp
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

### [Zaabee.Jil](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Jil)

```CSharp
var json = testModel.ToJil();

var result1 = jsonStr.FromJil<TestModel>();
var result2 = jsonStr.FromJil(typeof(TestModel)) as TestModel;
```

### [Zaabee.Json](https://github.com/Mutuduxf/Zaabee.Serializers/tree/master/Zaabee.Json)

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

|                  Method |       Mean |     Error |     StdDev |     Median |       Min |        Max |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |-----------:|----------:|-----------:|-----------:|----------:|-----------:|--------:|------:|------:|----------:|
|            JilSerialize |   4.483 us | 0.1208 us |  0.3428 us |   4.477 us |  3.823 us |   5.304 us |  2.3346 |     - |     - |    4904 B |
|           JsonSerialize |  14.786 us | 0.4052 us |  1.1625 us |  14.665 us | 12.932 us |  18.012 us |  2.9907 |     - |     - |    6320 B |
| Utf8JsonSerializeString |   5.295 us | 0.1490 us |  0.4228 us |   5.180 us |  4.521 us |   6.594 us |  0.7706 |     - |     - |    1632 B |
|  Utf8JsonSerializeBytes |   4.596 us | 0.1634 us |  0.4555 us |   4.551 us |  3.833 us |   5.812 us |  0.3891 |     - |     - |     832 B |
|       ProtobufSerialize |   5.128 us | 0.2951 us |  0.8607 us |   4.926 us |  4.023 us |   7.357 us |  0.5798 |     - |     - |    1232 B |
|            XmlSerialize |  71.736 us | 3.2386 us |  9.4981 us |  69.381 us | 56.751 us |  95.839 us | 13.5498 |     - |     - |   28500 B |
|          JilDeserialize |   8.084 us | 0.2983 us |  0.8702 us |   7.853 us |  6.660 us |  10.282 us |  0.7477 |     - |     - |    1576 B |
|         JsonDeserialize |  37.566 us | 1.6557 us |  4.7238 us |  36.875 us | 31.053 us |  51.269 us |  2.5024 |     - |     - |    5328 B |
|   Utf8DeserializeString |  10.870 us | 0.3043 us |  0.8924 us |  10.887 us |  9.307 us |  13.277 us |  0.8240 |     - |     - |    1736 B |
|    Utf8DeserializeBytes |  10.028 us | 0.3564 us |  1.0282 us |   9.890 us |  8.323 us |  12.986 us |  0.4272 |     - |     - |     904 B |
|     ProtobufDeserialize |   9.692 us | 0.4401 us |  1.2699 us |   9.493 us |  7.433 us |  13.053 us |  0.7172 |     - |     - |    1512 B |
|          XmlDeserialize | 124.819 us | 7.7805 us | 22.4486 us | 117.890 us | 92.684 us | 179.086 us |  8.3008 |     - |     - |   17546 B |
