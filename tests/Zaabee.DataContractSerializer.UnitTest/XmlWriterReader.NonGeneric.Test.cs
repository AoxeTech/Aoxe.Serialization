namespace Zaabee.DataContractSerializer.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void XmlWriterReaderNonGenericTest()
    {
        var testModel = TestModelHelper.Create();
        TestModel result0;
        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Create))
        {
            var writer = new XmlTextWriter(fs, Encoding.UTF8);
            writer.WriteXml(typeof(TestModel), testModel);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Open))
        {
            var reader = new XmlTextReader(fs);
            result0 = (TestModel)reader.ReadXml(typeof(TestModel))!;
            reader.Close();
        }

        TestModel result1;
        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Create))
        {
            var writer = new XmlTextWriter(fs, Encoding.UTF8);
            testModel.Serialize(typeof(TestModel), writer);
            writer.Close();
        }

        using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Open))
        {
            var reader = new XmlTextReader(fs);
            result1 = (TestModel)reader.ReadXml(typeof(TestModel))!;
            reader.Close();
        }
        
        Assert.True(TestModelHelper.CompareTestModel(testModel, result0));
        Assert.True(TestModelHelper.CompareTestModel(testModel, result1));
    }

    [Fact]
    public void XmlWriterReaderNonGenericNullTest()
    {
        TestModel? testModel = null;
        XmlWriter? write = null;
        XmlReader? reader = null;
        testModel.Serialize(typeof(TestModel), write);
        write.WriteXml(typeof(TestModel), testModel);
        reader.ReadXml(typeof(TestModel));
    }
}