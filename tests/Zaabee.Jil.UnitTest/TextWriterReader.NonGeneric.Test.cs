namespace Zaabee.Jil.UnitTest;

public partial class JilUnitTest
{
    [Fact]
    public void TextWriterReaderNonGenericTest()
    {
        object testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("TextWriterReaderNonGenericTest0.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            writer.WriteJson(testModel);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderNonGenericTest0.json", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result0 = (TestModel)reader.ReadJson(typeof(TestModel))!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("TextWriterReaderNonGenericTest1.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            testModel.Serialize(writer);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderNonGenericTest1.json", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result1 = (TestModel)reader.ReadJson(typeof(TestModel))!;
            reader.Close();
        }

        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result0));
        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result1));
    }

    [Fact]
    public void TextWriterReaderNonGenericNullTest()
    {
        object? testModel = TestModelHelper.Create();
        StreamWriter? writer = null;
        StreamReader? reader = null;
        testModel.Serialize(writer);
        writer.WriteJson(testModel);
        reader.ReadJson(typeof(TestModel));
    }
}