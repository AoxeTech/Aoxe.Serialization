namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractXmlNonGenericTest() =>
        XmlNonGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void XmlXmlNonGenericTest() =>
        XmlNonGenericTest(new Xml.Serializer());

    private static void XmlNonGenericTest(IXmlSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var type = typeof(TestModel);
        var xml = serializer.ToXml(type, model);
        var deserializeModel = (TestModel)serializer.FromXml(type, xml)!;
        
        Assert.Equal(model, deserializeModel);
    }
}