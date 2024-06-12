# Aoxe.Jil

Wrappers and extension methods by [jil](https://github.com/kevin-montrose/Jil)

## Jil

A fast JSON (de)serializer, built on [Sigil](https://github.com/kevin-montrose/Sigil) with a number of somewhat crazy optimization tricks.

[Releases are available on Nuget](https://www.nuget.org/packages/Jil/) in addition to this repository.

TestModel

```CSharp
public class TestModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreateTime { get; set; }
}
```

TestMethod

```CSharp
var testModel = new TestModel
{
    Id = Guid.NewGuid(),
    Age = new Random().Next(0, 100),
    CreateTime = DateTimeOffset.Now,
    Name = "banana"
};

var json = testModel.ToJson();
var jsonResult1 = json.FromJson<TestModel>();
var jsonResult2 = json.FromJson(typeof(TestModel));

var bytes = testModel.ToBytes();
var bytesResult1 = bytes.FromBytes<TestModel>();
var bytesResult2 = bytes.FromBytes(typeof(TestModel));

var stream = testModel.Pack();
var streamResult1 = stream.Unpack<TestModel>();
var streamResult2 = stream.Unpack(typeof(TestModel));

var ms1 = new MemoryStream();
testModel.PackTo(ms1);
var msResult1 = ms1.Unpack<TestModel>();
var msResult2 = ms1.Unpack(typeof(TestModel));

var ms2 = new MemoryStream();
ms2.PackBy(testmodel);
var msResult1 = ms2.Unpack<TestModel>();
var msResult2 = ms2.Unpack(typeof(TestModel));
```
