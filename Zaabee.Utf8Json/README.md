# Zaabee.Utf8Json

Wrappers and extension methods by [Utf8Json](https://github.com/neuecc/Utf8Json)

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
[Fact]
public void ObjectString()
{
    var testModel = new TestModel
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = DateTimeOffset.Now,
        Name = "banana"
    };

    var jsonStr = testModel.Utf8JsonToString();
    var result1 = jsonStr.FromUtf8Json<TestModel>();

    Assert.Equal(testModel.Id, result1.Id);
    Assert.Equal(testModel.Age, result1.Age);
    Assert.Equal(testModel.CreateTime.Year, result1.CreateTime.Year);
    Assert.Equal(testModel.CreateTime.Month, result1.CreateTime.Month);
    Assert.Equal(testModel.CreateTime.Day, result1.CreateTime.Day);
    Assert.Equal(testModel.CreateTime.Hour, result1.CreateTime.Hour);
    Assert.Equal(testModel.CreateTime.Minute, result1.CreateTime.Minute);
    Assert.Equal(testModel.CreateTime.Second, result1.CreateTime.Second);
    Assert.Equal(testModel.CreateTime.Millisecond, result1.CreateTime.Millisecond);
    Assert.Equal(testModel.Name, result1.Name);
}

[Fact]
public void ObjectBytes()
{
    var testModel = new TestModel
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = DateTimeOffset.Now,
        Name = "banana"
    };

    var bytes = testModel.Utf8JsonToBytes();
    var result1 = bytes.FromUtf8Json<TestModel>();

    Assert.Equal(testModel.Id, result1.Id);
    Assert.Equal(testModel.Age, result1.Age);
    Assert.Equal(testModel.CreateTime.Year, result1.CreateTime.Year);
    Assert.Equal(testModel.CreateTime.Month, result1.CreateTime.Month);
    Assert.Equal(testModel.CreateTime.Day, result1.CreateTime.Day);
    Assert.Equal(testModel.CreateTime.Hour, result1.CreateTime.Hour);
    Assert.Equal(testModel.CreateTime.Minute, result1.CreateTime.Minute);
    Assert.Equal(testModel.CreateTime.Second, result1.CreateTime.Second);
    Assert.Equal(testModel.CreateTime.Millisecond, result1.CreateTime.Millisecond);
    Assert.Equal(testModel.Name, result1.Name);
}
```
