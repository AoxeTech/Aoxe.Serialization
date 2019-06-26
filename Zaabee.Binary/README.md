# NewtonsoftJson

The wraps and extensions methods base by BinaryFormatter

TestModel

```CSharp
[Serializable]
public class TestModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreateTime { get; set; }
}
```

Demo

```CSharp
var testModel = new TestModel
{
    Id = Guid.NewGuid(),
    Age = new Random().Next(0, 100),
    CreateTime = DateTimeOffset.Now,
    Name = "banana"
};

var bytes = testModel.ToBytes();
var result = bytes.FromBytes<TestModel>();

Assert.Equal(testModel.Id, result.Id);
Assert.Equal(testModel.Age, result.Age);
Assert.Equal(testModel.CreateTime.Year, result.CreateTime.Year);
Assert.Equal(testModel.CreateTime.Month, result.CreateTime.Month);
Assert.Equal(testModel.CreateTime.Day, result.CreateTime.Day);
Assert.Equal(testModel.CreateTime.Hour, result.CreateTime.Hour);
Assert.Equal(testModel.CreateTime.Minute, result.CreateTime.Minute);
Assert.Equal(testModel.CreateTime.Second, result.CreateTime.Second);
Assert.Equal(testModel.CreateTime.Millisecond, result.CreateTime.Millisecond);
Assert.Equal(testModel.Name, result.Name);
```
