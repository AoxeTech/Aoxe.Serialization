namespace Zaabee.DataContractSerializer.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void XmlDictionaryWriterReaderTest()
    {
        var testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("XmlWriterReaderTest0.xml", FileMode.Create))
        {
            var writer = XmlDictionaryWriter.CreateDictionaryWriter(new XmlTextWriter(fs, Encoding.UTF8));
            writer.WriteXml(testModel);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderTest0.xml", FileMode.Open))
        {
            var reader = XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(fs));
            result0 = reader.ReadXml<TestModel>()!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("XmlWriterReaderTest1.xml", FileMode.Create))
        {
            var writer = XmlDictionaryWriter.CreateDictionaryWriter(new XmlTextWriter(fs, Encoding.UTF8));
            testModel.Serialize(writer);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderTest1.xml", FileMode.Open))
        {
            var reader = XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(fs));
            result1 = reader.ReadXml<TestModel>()!;
            reader.Close();
        }
        
        Assert.Equal(testModel, result0);
        Assert.Equal(testModel, result1);
    }

    [Fact]
    public void XmlDictionaryWriterReaderNullTest()
    {
        TestModel? testModel = null;
        XmlDictionaryWriter? write = null;
        XmlDictionaryReader? reader = null;
        testModel.Serialize(write);
        write.WriteXml(testModel);
        reader.ReadXml<TestModel>();
    }
}