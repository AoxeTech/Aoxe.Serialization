namespace Zaabee.DataContractSerializer.UnitTest;

public partial class XmlUnitTest
{
    [Fact]
    public void XmlWriterReaderNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
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
            result0 = (TestModel) reader.ReadXml(typeof(TestModel));
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
            result1 = (TestModel) reader.ReadXml(typeof(TestModel));
            reader.Close();
        }

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));
    }
}