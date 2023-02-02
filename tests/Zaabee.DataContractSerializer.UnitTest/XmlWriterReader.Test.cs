namespace Zaabee.DataContractSerializer.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void XmlWriterReaderTest()
    {
        var testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("XmlWriterReaderTest0.xml", FileMode.Create))
        {
            var writer = new XmlTextWriter(fs, Encoding.UTF8);
            writer.WriteXml(testModel);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderTest0.xml", FileMode.Open))
        {
            var reader = new XmlTextReader(fs);
            result0 = reader.ReadXml<TestModel>()!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("XmlWriterReaderTest1.xml", FileMode.Create))
        {
            var writer = new XmlTextWriter(fs, Encoding.UTF8);
            testModel.Serialize(writer);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderTest1.xml", FileMode.Open))
        {
            var reader = new XmlTextReader(fs);
            result1 = reader.ReadXml<TestModel>()!;
            reader.Close();
        }
        
        TestModelHelper.AssertEqual(testModel, result0);
        TestModelHelper.AssertEqual(testModel, result1);
    }

    [Fact]
    public void XmlWriterReaderNullTest()
    {
        TestModel? testModel = null;
        XmlWriter? write = null;
        XmlReader? reader = null;
        testModel.Serialize(write);
        write.WriteXml(testModel);
        reader.ReadXml<TestModel>();
    }
}