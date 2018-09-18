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
  Job-RUVWTX : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

IterationCount=10000  RunStrategy=ColdStart

              Method |      Mean |      Error |       StdDev |    Median |        Min |          Max |
-------------------- |----------:|-----------:|-------------:|----------:|-----------:|-------------:|
        JilSerialize |  17.61 us |  0.3236 us |     9.830 us |  17.50 us |   7.658 us |     790.2 us |
       JsonSerialize |  45.03 us |  1.2070 us |    36.672 us |  41.57 us |  23.704 us |   3,296.6 us |
   ProtobufSerialize |  25.01 us |  0.3693 us |    11.221 us |  24.43 us |  11.305 us |     572.5 us |
        XmlSerialize | 193.82 us |  1.7405 us |    52.879 us | 181.61 us | 103.567 us |     847.9 us |
      JilDeserialize |  53.80 us | 97.4957 us | 2,962.045 us |  25.16 us |  12.034 us | 296,227.8 us |
     JsonDeserialize |  87.58 us | 26.9408 us |   818.497 us |  71.11 us |  46.678 us |  81,872.2 us |
 ProtobufDeserialize |  41.58 us |  6.3883 us |   194.086 us |  37.93 us |  19.328 us |  19,274.7 us |
      XmlDeserialize | 239.83 us |  7.4513 us |   226.379 us | 213.70 us | 134.929 us |  21,493.0 us |