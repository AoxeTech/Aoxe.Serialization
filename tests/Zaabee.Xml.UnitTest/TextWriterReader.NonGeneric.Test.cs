namespace Zaabee.Xml.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void TextWriterReaderNonGenericTest()
    {
        var testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("TextWriterReaderNonGenericTest0.xml", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            writer.WriteXml(typeof(TestModel), testModel);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderNonGenericTest0.xml", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result0 = (TestModel)reader.ReadXml(typeof(TestModel))!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("TextWriterReaderNonGenericTest1.xml", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            testModel.Serialize(typeof(TestModel), writer);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderNonGenericTest1.xml", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result1 = (TestModel)reader.ReadXml(typeof(TestModel))!;
            reader.Close();
        }

        Assert.Equal(testModel, result0);
        Assert.Equal(testModel, result1);
    }
}
