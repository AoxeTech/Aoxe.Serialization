# Mutuduxf.Protobuf

The wraps and extensions methods for ZeroFormatter

Protobuf Attributes

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
```

ExtensionMethodTest

```CSharp
var testModel = GetTestModel();
var bytes = testModel.ToZeroFormatter();
var result = bytes.FromZeroFormatter<TestModel>();

Assert.Equal(testModel.Id, result.Id);
Assert.Equal(testModel.Age, result.Age);
Assert.Equal(testModel.CreateTime, result.CreateTime);
Assert.Equal(testModel.Name, result.Name);
Assert.Equal(testModel.Gender, result.Gender);
```
