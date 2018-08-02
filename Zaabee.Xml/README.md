# Mutuduxf.Xml

Extension methods for xml serialize/deserialize

TestModel

    testModel = new TestModel
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2017, 1, 1),
        Name = "banana",
        Gender = Gender.Female
    };

ExtensionMethodTest

```CSharp
var xml = testModel.ToXml();
var deserializeModel = xml.FromXml<TestModel>();

Assert.Equal(deserializeModel.Id, testModel.Id);
Assert.Equal(deserializeModel.Age, testModel.Age);
Assert.Equal(deserializeModel.CreateTime, testModel.CreateTime);
Assert.Equal(deserializeModel.Name, testModel.Name);
Assert.Equal(deserializeModel.Gender, testModel.Gender);
```

The encoding param

```CSharp
var xml = testModel.ToXml(Encoding.UTF32);
var deserializeModel = xml.FromXml<TestModel>(Encoding.UTF32);
var deserializeModel2 = xml.FromXml(typeof(TestModel), Encoding.UTF32) as TestModel;
```