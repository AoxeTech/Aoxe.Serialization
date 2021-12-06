using System;
using System.IO;
using System.Text;
using TestModels;
using Xunit;

namespace Zaabee.Jil.UnitTest;

public partial class JilUnitTest
{
    [Fact]
    public void TextWriterReaderTest()
    {
        var testModel = TestModelFactory.Create();
        TestModel result0;
        using (var fs = new FileStream("TextWriterReaderTest0.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            writer.WriteJson(testModel);
            writer.Close();
        }
        using (var fs = new FileStream("TextWriterReaderTest0.json", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result0 = reader.ReadJson<TestModel>();
            reader.Close();
        }
        TestModel result1;
        using (var fs = new FileStream("TextWriterReaderTest1.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            testModel.ToJson(writer);
            writer.Close();
        }
        using (var fs = new FileStream("TextWriterReaderTest1.json", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result1 = reader.ReadJson<TestModel>();
            reader.Close();
        }

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));


        using (var fs = new FileStream("TextWriterReaderTest.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            JilHelper.Serialize<TestModel>(null, writer);
            JilHelper.Serialize(null, writer);
            writer.Close();
        }
    }
}