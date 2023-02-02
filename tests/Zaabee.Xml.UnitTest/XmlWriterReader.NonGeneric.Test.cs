namespace Zaabee.Xml.UnitTest;

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
        
        TestModelHelper.AssertEqual(testModel, result0);
        TestModelHelper.AssertEqual(testModel, result1);
    }
}