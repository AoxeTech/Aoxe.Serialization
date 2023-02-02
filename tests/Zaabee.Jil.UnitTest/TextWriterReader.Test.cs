namespace Zaabee.Jil.UnitTest;

public partial class JilUnitTest
{
    [Fact]
    public void TextWriterReaderTest()
    {
        var testModel = TestModelHelper.Create();
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
            result0 = reader.ReadJson<TestModel>()!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("TextWriterReaderTest1.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            testModel.Serialize(writer);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderTest1.json", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result1 = reader.ReadJson<TestModel>()!;
            reader.Close();
        }

        TestModelHelper.AssertEqual(testModel, result0);
        TestModelHelper.AssertEqual(testModel, result1);

        using (var fs = new FileStream("TextWriterReaderTest.json", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            JilHelper.Serialize<TestModel>(null, writer);
            JilHelper.Serialize(null, writer);
            writer.Close();
        }
    }

    [Fact]
    public void TextWriterReaderNullTest()
    {
        var testModel = TestModelHelper.Create();
        StreamWriter? writer = null;
        StreamReader? reader = null;
        testModel.Serialize(writer);
        writer.WriteJson(testModel);
        reader.ReadJson<TestModel>();
    }
}