# Zaabee.Serializers

The wraps and extensions for json.net/protobuf/jil/xml

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

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.254 (1803/April2018Update/Redstone4)

Intel Core i7-6600U CPU 2.60GHz (Max: 0.80GHz) (Skylake), 1 CPU, 4 logical and 2 physical cores

Frequency=2742190 Hz, Resolution=364.6720 ns, Timer=TSC

.NET Core SDK=2.1.402

  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

|              Method |       Mean |      Error |     StdDev |    Median |       Min |        Max |
|-------------------- |-----------:|-----------:|-----------:|----------:|----------:|-----------:|
|        JilSerialize |   5.702 us |  0.1446 us |  0.4150 us |  5.649 us |  4.989 us |   6.828 us |
|       JsonSerialize |  14.486 us |  0.4098 us |  1.0796 us | 14.307 us | 12.971 us |  18.401 us |
|   ProtobufSerialize |   3.987 us |  0.2389 us |  0.6581 us |  3.799 us |  3.152 us |   6.017 us |
|        XmlSerialize |  55.075 us |  1.1933 us |  3.3264 us | 54.877 us | 48.931 us |  65.259 us |
|      JilDeserialize |   6.253 us |  0.1346 us |  0.3819 us |  6.221 us |  5.524 us |   7.136 us |
|     JsonDeserialize |  29.958 us |  0.8269 us |  2.4253 us | 29.675 us | 26.099 us |  36.429 us |
| ProtobufDeserialize |   6.833 us |  0.1366 us |  0.3874 us |  6.793 us |  6.137 us |   7.734 us |
|      XmlDeserialize | 114.487 us | 12.7054 us | 37.4621 us | 98.266 us | 77.358 us | 197.804 us |