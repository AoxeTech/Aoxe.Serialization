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

|              Method |      Mean |     Error |     StdDev |    Median |       Min |        Max |   Gen 0 | Allocated |
|-------------------- |----------:|----------:|-----------:|----------:|----------:|-----------:|--------:|----------:|
|        JilSerialize |  3.912 us | 0.1432 us |  0.4155 us |  3.746 us |  3.398 us |   4.972 us |  2.3346 |   4.79 KB |
|       JsonSerialize | 13.018 us | 0.4916 us |  1.4261 us | 12.544 us | 11.331 us |  16.323 us |  2.9907 |   6.18 KB |
|   ProtobufSerialize |  3.310 us | 0.1119 us |  0.3230 us |  3.208 us |  2.902 us |   4.082 us |  0.5417 |   1.12 KB |
|        XmlSerialize | 54.116 us | 1.7183 us |  5.0396 us | 52.528 us | 47.314 us |  67.135 us | 13.5498 |  27.83 KB |
|      JilDeserialize |  6.175 us | 0.2490 us |  0.7144 us |  5.906 us |  5.248 us |   8.311 us |  0.7477 |   1.54 KB |
|     JsonDeserialize | 29.489 us | 0.9342 us |  2.7399 us | 28.297 us | 25.972 us |  36.791 us |  2.5330 |    5.2 KB |
| ProtobufDeserialize |  8.531 us | 0.4940 us |  1.4331 us |  8.247 us |  5.995 us |  11.908 us |  0.6332 |    1.3 KB |
|      XmlDeserialize | 99.753 us | 5.7044 us | 16.2751 us | 96.147 us | 75.318 us | 146.592 us |  8.3008 |  17.15 KB |