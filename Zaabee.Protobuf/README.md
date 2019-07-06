# Zaabee.Protobuf

The wraps and extensions methods for [protobuf-net](https://github.com/protobuf-net/protobuf-net)

Protobuf Attributes

```CSharp
public class TestModel
{
    public Guid Id { get; set; }

    public int Age { get; set; }

    public string Name { get; set; }

    public DateTime CreateTime { get; set; }

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
```

ExtensionMethodTest

```CSharp
var bytes = _testModelWithoutAttr.ToProtobuf();
var deserializeModel1 = bytes.FromProtobuf<TestModelWithoutAttr>();
var deserializeModel2 = bytes.FromProtobuf(typeof(TestModelWithoutAttr)) as TestModelWithoutAttr;

Assert.Equal(deserializeModel1.Id, _testModelWithoutAttr.Id);
Assert.Equal(deserializeModel1.Age, _testModelWithoutAttr.Age);
Assert.Equal(deserializeModel1.CreateTime, _testModelWithoutAttr.CreateTime);
Assert.Equal(deserializeModel1.Name, _testModelWithoutAttr.Name);
Assert.Equal(deserializeModel1.Gender, _testModelWithoutAttr.Gender);

Assert.Equal(deserializeModel2.Id, _testModelWithoutAttr.Id);
Assert.Equal(deserializeModel2.Age, _testModelWithoutAttr.Age);
Assert.Equal(deserializeModel2.CreateTime, _testModelWithoutAttr.CreateTime);
Assert.Equal(deserializeModel2.Name, _testModelWithoutAttr.Name);
Assert.Equal(deserializeModel2.Gender, _testModelWithoutAttr.Gender);
```
