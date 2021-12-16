namespace Zaabee.Jil.UnitTest;

public partial class JilUnitTest
{
    [Fact]
    public void TextWriterReaderNonGenericTest()
    {
        object testModel = TestModelFactory.Create();
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

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));
    }

    [Fact]
    public void TextWriterReaderNonGenericNullTest()
    {
        object? testModel = TestModelFactory.Create();
        StreamWriter? writer = null;
        StreamReader? reader = null;
        testModel.Serialize(writer);
        writer.WriteJson(testModel);
        reader.ReadJson(typeof(TestModel));
    }
}