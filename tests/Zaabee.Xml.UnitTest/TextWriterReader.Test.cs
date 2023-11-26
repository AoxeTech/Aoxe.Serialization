namespace Zaabee.Xml.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void TextWriterReaderTest()
    {
        var testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("TextWriterReaderTest0.xml", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            writer.WriteXml(testModel);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderTest0.xml", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result0 = reader.ReadXml<TestModel>()!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("TextWriterReaderTest1.xml", FileMode.Create))
        {
            var writer = new StreamWriter(fs, Encoding.UTF8);
            testModel.Serialize(writer);
            writer.Close();
        }

        using (var fs = new FileStream("TextWriterReaderTest1.xml", FileMode.Open))
        {
            var reader = new StreamReader(fs, Encoding.UTF8);
            result1 = reader.ReadXml<TestModel>()!;
            reader.Close();
        }

        Assert.Equal(testModel, result0);
        Assert.Equal(testModel, result1);

        XmlHelper.Serialize((XmlWriter?)null, testModel);
        XmlHelper.Serialize((TextWriter?)null, testModel);
        XmlHelper.Serialize(typeof(TestModel), (XmlWriter?)null, testModel);
        XmlHelper.Serialize(typeof(TestModel), (TextWriter?)null, testModel);
    }
}
