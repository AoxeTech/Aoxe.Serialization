namespace Zaabee.DataContractSerializer.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void XmlDictionaryWriterReaderNonGenericTest()
    {
        var testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Create))
        {
            var writer = XmlDictionaryWriter.CreateDictionaryWriter(new XmlTextWriter(fs, Encoding.UTF8));
            writer.WriteXml(typeof(TestModel), testModel);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Open))
        {
            var reader = XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(fs));
            result0 = (TestModel)reader.ReadXml(typeof(TestModel))!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Create))
        {
            var writer = XmlDictionaryWriter.CreateDictionaryWriter(new XmlTextWriter(fs, Encoding.UTF8));
            testModel.Serialize(typeof(TestModel), writer);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Open))
        {
            var reader = XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(fs));
            result1 = (TestModel)reader.ReadXml(typeof(TestModel))!;
            reader.Close();
        }

        Assert.Equal(testModel, result0);
        Assert.Equal(testModel, result1);
    }

    [Fact]
    public void XmlDictionaryWriterReaderNonGenericNullTest()
    {
        TestModel? testModel = null;
        XmlDictionaryWriter? write = null;
        XmlDictionaryReader? reader = null;
        testModel.Serialize(typeof(TestModel), write);
        write.WriteXml(typeof(TestModel), testModel);
        reader.ReadXml(typeof(TestModel));
    }
}