# Zaabee.MsgPack

The wraps and extensions methods for [MsgPack.Cli](https://github.com/msgpack/msgpack-cli)

```CSharp
public class TestModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public DateTime CreateTime { get; set; }
    public Gender Gender { get; set; }
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
