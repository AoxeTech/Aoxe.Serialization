# Aoxe.ZeroFormatter

The wraps and extensions methods for [ZeroFormatter](https://github.com/neuecc/ZeroFormatter)

```CSharp
[ZeroFormattable]
public class TestModel
{
    [Index(0)]
    public virtual Guid Id { get; set; }
    [Index(1)]
    public virtual int Age { get; set; }
    [Index(2)]
    public virtual string Name { get; set; }
    [Index(3)]
    public virtual DateTime CreateTime { get; set; }
    [Index(4)]
    public virtual Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}
```

TestModel

```CSharp
var testModel = new TestModel
{
    Id = Guid.NewGuid(),
    Age = new Random().Next(0, 100),
    CreateTime = new DateTime(2017, 1, 1),
    Name = "banana",
    Gender = Gender.Female
};

var bytes = testModel.ToBytes();
var bytesResult1 = bytes.FromBytes<TestModel>();
var bytesResult2 = bytes.FromBytes(typeof(TestModel));

var stream = testModel.Pack();
var streamResult1 = stream.Unpack<TestModel>();
var streamResult2 = stream.Unpack(typeof(TestModel));

var ms = new MemoryStream();
testModel.PackTo(ms);
var msResult1 = ms.Unpack<TestModel>();
var msResult2 = ms.Unpack(typeof(TestModel));
```
