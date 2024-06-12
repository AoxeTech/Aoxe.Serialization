# Aoxe.Protobuf

The wraps and extensions methods for [protobuf-net](https://github.com/protobuf-net/protobuf-net)

Protobuf Attributes

```CSharp
[ProtoContract]
public class TestModel
{
    [ProtoMember(1)]
    public Guid Id { get; set; }

    [ProtoMember(2)]
    public int Age { get; set; }

    [ProtoMember(3)]
    public string Name { get; set; }

    [ProtoMember(4)]
    public DateTime CreateTime { get; set; }

    [ProtoMember(5)]
    public Gender Gender { get; set; }
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
