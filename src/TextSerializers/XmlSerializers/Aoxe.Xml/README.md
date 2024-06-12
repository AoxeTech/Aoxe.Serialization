# Aoxe.Xml

Extension methods for xml serialize/deserialize

TestModel

```CSharp
testModel = new TestModel
{
    Id = Guid.NewGuid(),
    Age = new Random().Next(0, 100),
    CreateTime = new DateTime(2017, 1, 1),
    Name = "banana",
    Gender = Gender.Female
};

var xml = testModel.ToXml();
var xmlResult1 = xml.FromXml<TestModel>();
var xmlResult2 = xml.FromXml(typeof(TestModel));

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
