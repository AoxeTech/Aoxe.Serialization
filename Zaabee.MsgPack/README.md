# Mutuduxf.Protobuf

The wraps and extensions methods for MsgPack.Cli

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
```

ExtensionMethodTest

```CSharp
var testModel = GetTestModel();
var bytes = testModel.ToMsgPack();
var result = bytes.FromMsgPak<TestModel>();

Assert.Equal(testModel.Id, result.Id);
Assert.Equal(testModel.Age, result.Age);
Assert.Equal(testModel.CreateTime, result.CreateTime);
Assert.Equal(testModel.Name, result.Name);
Assert.Equal(testModel.Gender, result.Gender);
```
